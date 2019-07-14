using Course2.Data;
using Course2.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Course2.Tests
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void HomePage_ElementVisibility()
        {
            _homePage = GoToHomePage();

            Assert.IsTrue(_homePage.HeaderItemVisibilityVerification());
            Assert.IsTrue(_homePage.PageBodyItemVisibilityVerification());
            Assert.IsTrue(_homePage.FooterItemVisibilityVerification());
        }

        [Test]
        public void HomePage_Title_Verification()
        {
            _homePage = GoToHomePage()
                .VerifyPageTitle(MyResources.HomePageTitle);
        }

        [Test]
        public void HomePage_ValidLogin()
        {
            _homePage = GoToHomePage();
            _dashboardPage = _homePage.SuccessfulLogin("admin@domain.org", "111111")
                .VerifyPageTitle(MyResources.DashboardPageTitle);
        }

        [Test]
        public void HomePage_NoLoginData_ErrorMSG()
        {
            _homePage = GoToHomePage()
                .UnsuccessfulLogin("", "");

            Assert.IsTrue(_homePage.EmailErrorValidation("Email address can't be null"));
        }

        [Test]
        public void HomePage_InvalidEmail_Password_ValidationMsg()
        {
            _homePage = GoToHomePage()
                .UnsuccessfulLogin("admindomain.org", "111111");

            Assert.IsTrue(_homePage.EmailErrorValidation("Email address format is not valid"));                                 
            Assert.IsTrue(_homePage.PasswordErrorValidation("Invalid password/email"));

            _homePage.UnsuccessfulLogin("admin@domain.org", "11111");
            Assert.IsTrue(_homePage.PasswordErrorValidation("Invalid password/email"));
        }

        [Test]
        public void Homepage_GoTOWikiPage()
        {
            _homePage = GoToHomePage();
            _wikiPage = _homePage.GoToWikiPaheByClickOnLink()
                .VerifyPageTitle(MyResources.WikipageTitle);
        }
    }
}
