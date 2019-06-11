using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Course01.Course02;

namespace Course01
{
    public class TestsClass : TestBase
    {
        [Test]
        public void FirstTest()
        {
            GoToHomePage().CheckPageTitle("Home page").FillInEmail(Resource.Email).FillInPassword(Resource.Password);
        }

        [Test]
        public void HeaderLinksAndImageDisplayedHomePageTest()
        {
            GoToHomePage().CheckPageTitle(Resource.PageTitle).CheckImageDisplayed().CheckHeaderDisplayed();     
        }

        [Test]
        public void HomePageTitleIsCorrectTest()
        {
            GoToHomePage().VerifyHomePageTitleIsCorrect();
        }

        [Test]
        public void HomePageH1TitleIsCorrectTest()
        {
            GoToHomePage().CheckH1Title(); 
        }

        [Test]
        public void DefaultValuesAreDisplayedAndCorrectTest()
        {
            GoToHomePage()
                .CheckElementIsDisplayed(WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")))
                .CheckElementIsDisplayed(WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default password: 111111')]")))
                .CheckElementContainsText(WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")), "Default email: admin@domain.org")
                .CheckElementContainsText(WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default password: 111111')]")), "Default password: 111111");
        }


        [Test]
        public void LoginFieldsDisplayedTest()
        {
            GoToHomePage()
                .CheckElementIsDisplayed(WebDriver.FindElement(By.Id("email")))
                .CheckElementIsDisplayed(WebDriver.FindElement(By.Id("password")));
        }

        [Test]
        public void ErrorMessageVerifyNoCredentialsTest()
        {
            GoToHomePage().ClickElement(WebDriver.FindElement(By.Id("Login")), "Login Button")
                .CheckElementIsDisplayed(WebDriver.FindElement(By.Id("emailErrorText")))
                .CheckElementContainsText(WebDriver.FindElement(By.Id("emailErrorText")), "Email address can't be null");
        }

        [Test]
        public void ErrorMessageVerifyWrongEmailFormatTest()
        {

            GoToHomePage().VerifyEmailErrorMessage();
        }

        [Test]
        public void ErrorMessageVerifyInvalidPasswordTest()
        {
            GoToHomePage().VerifyPasswordErrorMessage();
        }


        [Test]
        public void LoginValidCredentialsTest()
        {
            GoToHomePage().LoginWithValidCredentials().CheckPageTitle(Resource.DashboardPageTitle);
        }

        [Test]
        public void NavigateToWikiPage()
        {
            GoToHomePage()
                .LoginWithValidCredentials()
                .CheckPageTitle(Resource.DashboardPageTitle)
                .NavigateToWiki();

        }

        [Test]
        public void WikiFootersDisplayedTest()
        {
            GoToHomePage()
                .LoginWithValidCredentials()
                .CheckPageTitle(Resource.DashboardPageTitle)
                .NavigateToWiki()
                .CheckPageTitle("Wiki page")
                .CheckElementIsDisplayed(WebDriver.FindElement(By.Id("nav")));
        }

        [Test]
        public void HeaderLinksAndImageDisplayedDashboardPageTest()
        {
            GoToHomePage()
               .LoginWithValidCredentials()
               .CheckPageTitle(Resource.DashboardPageTitle)
               .CheckElementIsDisplayed(WebDriver.FindElement(By.XPath("//a[@href='wikipage.html'][@style='padding-left:5em'][contains(text(),'WikiPage')]")))
               .CheckElementIsDisplayed(WebDriver.FindElement(By.XPath("//a[@href='homepage.html'][@style='padding-left:5em'][contains(text(),'Home')]")));              
        }

        [Test]
        public void DashboardPageTitleIsCorrectTest()
        {
            GoToHomePage()
            .LoginWithValidCredentials()
            .CheckPageTitle(Resource.DashboardPageTitle);
        }

        [Test]
        public void DashboardPageTitleH1IsCorrectTest()
        {
            GoToHomePage()
           .LoginWithValidCredentials()
           .CheckPageTitle(Resource.DashboardPageTitle)
           .CheckH1Title();
        }

        [Test]
        public void DashboardPageEditPersonalInfoTest()
        {
            GoToHomePage()
           .LoginWithValidCredentials()
           .CheckPageTitle(Resource.DashboardPageTitle)
           .CheckH1Title()
           .EditPersonalInfoAndSave();
        }

        [Test]
        public void LogOutTest()
        {
            GoToHomePage()
           .LoginWithValidCredentials()
           .CheckPageTitle(Resource.DashboardPageTitle)
           .CheckH1Title()
           .EditPersonalInfoAndSave()
           .Logout();        
        }

        [Test]
        public void WindowsFrameTest_WriteInBothFrames()
        {
            OpenHomePageAndGoToWindowsFrame()
                .ClickWindowsFrameLink()
                .WriteToFrame1TextArea();
        }
    }
}
