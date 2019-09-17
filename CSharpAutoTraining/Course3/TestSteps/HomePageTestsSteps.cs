using CSharpAutoTraining.Course3.Pages;
using CSharpAutoTraining.Properties;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining.Course3.TestSteps
{
    [Binding]
    public class HomePageTestsSteps : WebDriverBDD
    {
        private HomePage homePage;
        private DashboardPage dashboardPage;

        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            homePage = GoToHomePage();
        }

        [Then(@"the header links are displayed")]
        public void ThenTheHeaderLinksAreDisplayed()
        {
            Assert.True(homePage.HeaderImageIsDisplayed());
        }

        [Then(@"the image in the header is displayed")]
        public void ThenTheImageInTheHeaderIsDisplayed()
        {
            Assert.True(homePage.HeaderLinksAreAllDisplayed());
        }

        [Then(@"the page title is correct")]
        public void ThenThePageTitleIsCorrect()
        {
            Assert.AreEqual(DataHomePage.PageTitle, GoToHomePage().GetPageTitle());
        }

        [Then(@"the page heading title is correct")]
        public void ThenThePageHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataHomePage.HomePageHeadingTitle, GoToHomePage().GetPageHeadingTitle());
        }

        [Then(@"the default e-mail is correct")]
        public void ThenTheDefaultE_MailIsCorrect()
        {
            Assert.AreEqual(DataHomePage.DefaultEmail, GoToHomePage().GetDefaultEmail());
        }

        [Then(@"the default password is correct")]
        public void ThenTheDefaultPasswordIsCorrect()
        {
            Assert.AreEqual(DataHomePage.DefaultPassword, GoToHomePage().GetDefaultPassword());
        }

        [When(@"I type in the credentials and click the login button")]
        public void GivenITypedInTheCredentials(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            homePage = homePage.Authenticate(credentialsFirstRow[0], credentialsFirstRow[1]);
        }

        [Then(@"I am redirected to '(.*)'")]
        public void ThenIAmRedirectedTo(string p0)
        {
            dashboardPage = GoToDashboardPage();
        }

        [Then(@"I should remain on 'Homepage'")]
        public void ThenIShouldRemainOnHomepage()
        {
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.HomepageURL],
                homePage.GetUrl());
        }

        [Then(@"a null email error should be displayed")]
        public void ThenANullEmailErrorShouldBeDisplayed()
        {
            Assert.AreEqual(homePage.GetEmailErrorMessage(), DataHomePage.EmailErrorMessage);
        }

        [Then(@"an invalid email error should be displayed")]
        public void ThenAnInvalidEmailErrorShouldBeDisplayed()
        {
            Assert.AreEqual(homePage.GetEmailErrorMessage(), "Email address format is not valid");
        }

        [Then(@"a null password error should be displayed")]
        public void ThenANullPasswordErrorShouldBeDisplayed()
        {
            Assert.AreEqual(homePage.GetPasswordErrorMessage(), "Password can't be null");
        }

        [Then(@"an invalid password error should be displayed")]
        public void ThenAnInvalidPasswordErrorShouldBeDisplayed()
        {
            Assert.AreEqual(homePage.GetPasswordErrorMessage(), "Invalid password/email");
        }

        [Then(@"the footer links are displayed")]
        public void ThenTheFooterLinksAreDisplayed()
        {
            Assert.True(homePage.FooterLinksAreDisplayed());
        }
    }
}
