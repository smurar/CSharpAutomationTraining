using CSharpAutoTraining.Course3.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining.Course3.TestSteps
{
    [Binding]
    public class HomepageTestsSteps
    {
        private HomePage homePage;

        [Given(@"I am on Homepage")]
        public void GivenIAmOnHomepage()
        {            
            homePage = new HomePage(WebDriverClass.WebDriver);
            homePage.GoToHomepage();
        }
        
        [Then(@"The Header image is displayed")]
        public void ThenTheHeaderImageIsDisplayed()
        {
            Assert.IsTrue(homePage.HomeHeaderImage.Displayed);
        }
        
        [Then(@"Home Header Link is Displayed")]
        public void ThenHomeHeaderLinkIsDisplayed()
        {
            Assert.IsTrue(homePage.HomeHeaderLink.Displayed);
        }

        [Then(@"Wiki Header Link is Displayed")]
        public void ThenWikiHeaderLinkIsDisplayed()
        {
            Assert.IsTrue(homePage.WikiPageHeaderLink.Displayed);
        }

        [Then(@"Homepage Title is correct")]
        public void ThenHomepageTitleIsCorrect()
        {
            homePage.CheckHomepageTitle(TestData.ExpectedHomepageTitle);
        }

        [Then(@"Homepage Heading is correct")]
        public void ThenHomepageHeadingIsCorrect()
        {
            Assert.AreEqual(TestData.ExpectedHomepageHeading, homePage.Heading1.Text);
        }

        [Then(@"Default email is displayed")]
        public void ThenDefaultEmailIsDisplayed()
        {
            Assert.IsTrue(homePage.DefaultEmail.Displayed);
            Assert.AreEqual(TestData.ExpectedDefaultEmailDisplayed, homePage.DefaultEmail.Text);
        }

        [Then(@"Default password is displayed")]
        public void ThenDefaultPasswordIsDisplayed()
        {
            
            Assert.IsTrue(homePage.DefaultPass.Displayed);
            Assert.AreEqual(TestData.ExpectedDefaultPasswordDisplayed, homePage.DefaultPass.Text);
        }

        [Then(@"Login fields are displayed")]
        public void ThenLoginFieldsAreDisplayed()
        {
            Assert.IsTrue(homePage.EmailField.Displayed);
            Assert.IsTrue(homePage.PasswordField.Displayed);
        }

        [When(@"Login with no email entered")]
        public void WhenLoginWithNoEmailEntered()
        {
            homePage.ClickLoginButton();
        }

        [Then(@"Email can't be null error is displayed")]
        public void ThenEmailCanTBeNullErrorIsDisplayed()
        {
            Assert.IsTrue(homePage.EmailCantBeNullError.Displayed);
            Assert.AreEqual(TestData.ExpectedEmailNullError, homePage.EmailCantBeNullError.Text);
        }

        [When(@"I Login with invalid email format")]
        public void WhenILoginWithInvalidEmailFormat(Table table)
        {
            string invalidEmail = table.Rows[0][1].ToString();

            homePage.FillInEmail(invalidEmail)
                    .ClickLoginButton();
        }

        [Then(@"Email format error is displayed")]
        public void ThenEmailFormatErrorIsDisplayed()
        {
            
        }
              
        [When(@"I Login with valid email and password")]
        public void WhenILoginWithValidEmailAndPassword()
        {
            homePage.FillInEmail(TestData.ValidEmail)
                    .FillInPassword(TestData.ValidPassword)
                    .ClickLoginButton();
        }

        [Then(@"Login is successful")]
        public void ThenLoginIsSuccessful()
        {
            var dashboard = homePage.LoginRedirectToDashboard();
            dashboard.CheckDashboardTitle(TestData.ExpectedDashboardPageTitle);
        }

        [When(@"I enter an invalid email and a valid password")]
        public void WhenIEnterAnInvalidEmailAndAValidPassword()
        {
            homePage.GoToHomepage()
                    .FillInEmail(TestData.InvalidEmail)
                    .FillInPassword(TestData.ValidPassword)
                    .ClickLoginButton();
        }

        [Then(@"Invalid email/password error is displayed")]
        public void ThenInvalidEmailPasswordErrorIsDisplayed()
        {
            Assert.IsTrue(homePage.CredentialsInvalidError.Displayed);
            Assert.AreEqual(TestData.ExpectedInvalidCredentialsError, homePage.CredentialsInvalidError.Text);
        }

        [When(@"I enter a valid email and an invalid password")]
        public void WhenIEnterAValidEmailAndAnInvalidPassword()
        {
            homePage.GoToHomepage()
                    .FillInEmail(TestData.ValidEmail)
                    .FillInPassword(TestData.InvalidPassword)
                    .ClickLoginButton();
        }

        [When(@"I click on Wiki page title link")]
        public void WhenIClickOnWikiPageTitleLink()
        {
            homePage.ClickOnWikiPage();
        }

        //[Then(@"I am redirected to the Wiki page")]
        //public void ThenIAmRedirectedToTheWikiPage()
        //{
        //    homePage.RedirectToWikiPage()
        //            .CheckWikiPageTitle(TestData.ExpectedWikiPageTitle);
        //}

        [Then(@"Home footer link is displayed")]
        public void ThenHomeFooterLinkIsDisplayed()
        {
            Assert.IsTrue(homePage.HomeFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedHomeFooterLinkHref, homePage.HomeFooterLink.GetAttribute("href"));
        }

        [Then(@"Wiki footer link is displayed")]
        public void ThenWikiFooterLinkIsDisplayed()
        {
            Assert.IsTrue(homePage.WikiFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedWikiFooterLinkHref, homePage.WikiFooterLink.GetAttribute("href"));
        }

        [Then(@"Contacts footer link is displayed")]
        public void ThenContactsFooterLinkIsDisplayed()
        {
            Assert.IsTrue(homePage.ContactsFooterLink.Displayed);
            Assert.AreEqual(TestData.ExpectedContactsFooterLinkHref, homePage.ContactsFooterLink.GetAttribute("href"));
        }

    }

}

