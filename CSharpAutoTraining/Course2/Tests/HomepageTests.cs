using CSharpAutoTraining.Course2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CSharpAutoTraining.Course2
{
    class HomepageTests : BaseTest
    {
        [Test]
        public void HeaderImageDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if header image is displayed");
            Assert.IsTrue(home.HomeHeaderImage.Displayed);                
        }


        [Test]
        public void HomeHeaderLinkDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Home header link is displayed");
            Assert.IsTrue(home.HomeHeaderLink.Displayed);
        }


        [Test]
        public void WikiHeaderLinkDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Wikipage header link is displayed");
            Assert.IsTrue(home.WikiPageHeaderLink.Displayed);
        }


        [Test]
        public void HomepageTitleCorrect()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            home.CheckHomepageTitle(TestData.ExpectedHomepageTitle);
        }


        [Test]
        public void HomepageHeadingCorrect()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Homepage heading is correct");
            Assert.AreEqual(TestData.ExpectedHomepageHeading, home.Heading1.Text);
        }


        [Test]
        public void DefaultEmailDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if default email is displayed on page");
            Assert.IsTrue(home.DefaultEmail.Displayed);
            Assert.AreEqual(TestData.ExpectedDefaultEmailDisplayed, home.DefaultEmail.Text);
        }


        [Test]
        public void DefaultPassDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if default password is displayed on page");
            Assert.IsTrue(home.DefaultPass.Displayed);
            Assert.AreEqual(TestData.ExpectedDefaultPasswordDisplayed, home.DefaultPass.Text);
        }


        [Test]
        public void LoginFieldsDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if username and password field are displayed");
            Assert.IsTrue(home.EmailField.Displayed);
            Assert.IsTrue(home.PasswordField.Displayed);
        }


        [Test]
        public void EmailCantBeNull()
        {
            HomePage home = new HomePage(WebDriver);
            
            home.GoToHomepage()
                .ClickLoginButton();
            Reporter.LogInfo("Check if email field can be null");
            Assert.IsTrue(home.EmailCantBeNullError.Displayed);
            Assert.AreEqual(TestData.ExpectedEmailNullError, home.EmailCantBeNullError.Text);
        }


        [Test]
        public void EmailFormatInvalid()
        {
            HomePage home = new HomePage(WebDriver);
            
            home.GoToHomepage()
                .FillInEmail(TestData.InvalidEmailFormat)
                .ClickLoginButton();
            Reporter.LogInfo("Check if invalid email format message is displayed");
            Assert.IsTrue(home.EmailFormatError.Displayed);
            Assert.AreEqual(TestData.ExpectedEmailFormatError, home.EmailFormatError.Text);
        }


        [Test]
        public void InvalidEmailEntered()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage()
                .FillInEmail(TestData.InvalidEmail)
                .FillInPassword(TestData.ValidPassword)
                .ClickLoginButton();
            Reporter.LogInfo("Check if invalid email or password error message is displayed");
            Assert.IsTrue(home.CredentialsInvalidError.Displayed);
            Assert.AreEqual(TestData.ExpectedInvalidCredentialsError, home.CredentialsInvalidError.Text);
        }


        [Test]
        public void InvalidPasswordEntered()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage()
                .FillInEmail(TestData.ValidEmail)
                .FillInPassword(TestData.InvalidPassword)
                .ClickLoginButton();
            Reporter.LogInfo("Check if invalid email or password error message is displayed");
            Assert.IsTrue(home.CredentialsInvalidError.Displayed);
            Assert.AreEqual(TestData.ExpectedInvalidCredentialsError, home.CredentialsInvalidError.Text);
        }


        [Test]
        public void LoginValidCredentials()
        {
            //can be done without variable declaration like below
            HomePage home = new HomePage(WebDriver);

            var dashboard = home.GoToHomepage()
                                .FillInEmail(TestData.ValidEmail)
                                .FillInPassword(TestData.ValidPassword)
                                .ClickLoginButton()
                                .LoginRedirectToDashboard();
            Reporter.LogInfo("Check if Login is successful and user redirect to Dashboard");
            dashboard.CheckDashboardTitle(TestData.ExpectedDashboardPageTitle);
        }

        
        [Test]
        public void RedirectToWikiPage()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage()
                .ClickOnWikiPage()
                .CheckWikiPageTitle(TestData.ExpectedWikiPageTitle);
        }


        [Test]
        public void HomeFooterLinkDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Home footer link is displayed");
            Assert.IsTrue(home.HomeFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedHomeFooterLinkHref, home.HomeFooterLink.GetAttribute("href"));
        }


        [Test]
        public void WikiFooterLinkDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Wiki footer link is displayed");
            Assert.IsTrue(home.WikiFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedWikiFooterLinkHref, home.WikiFooterLink.GetAttribute("href"));
        }


        [Test]
        public void ContactFooterLinkDisplayed()
        {
            HomePage home = new HomePage(WebDriver);

            home.GoToHomepage();
            Reporter.LogInfo("Check if Contacts footer link is displayed");
            Assert.IsTrue(home.ContactsFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedContactsFooterLinkHref, home.ContactsFooterLink.GetAttribute("href"));
        }
    }
}
