using Course2.Pages;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Course2.Test_steps
{
    [Binding]
    public class HomePageTestsSteps
    {
        private HomePage homePage;
        private DashboardPage dashboardPage;
        private WikiPage wikiPage;
 
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);
        }
        
        [Given(@"I have typed in email")]
        public void GivenIHaveTypedInEmail(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            homePage = homePage.FillInEmail(credentialsFirstRow[0], "email");
        }
        
        [Then(@"I should remain on homepage '(.*)'")]
        public void ThenIShouldRemainOnHomepage(string p0)
        {
            homePage.CheckHomeTitle(MyResource.HomeTitle);
        }

        [Given(@"I click the Wiki link")]
        public void GivenIClickTheWikiLink()
        {
            homePage.GoToWiki();
        }

        [Then(@"I should see the header links and image")]
        public void ThenIShouldSeeTheHeaderLinksAndImage()
        {
            homePage.CheckHeaderLinks();
        }

        [Then(@"I should see the heading title '(.*)'")]
        public void ThenIShouldSeeTheHeadingTitle(string p0)
        {
            homePage.CheckHeadingTitle(MyResource.HomeHeading);
        }

        [Then(@"I should see the default email and password texts '(.*)', '(.*)'")]
        public void ThenIShouldSeeTheDefaultEmailAndPasswordTexts(string p0, string p1)
        {
            homePage.CheckDefaultEmailPassText(MyResource.DefaultEmail, MyResource.DefaultPassword);
        }

        [Then(@"I should see the Login fields")]
        public void ThenIShouldSeeTheLoginFields()
        {
            homePage.CheckLoginFields();
        }

        [Then(@"Email address cannot be null error should be displayed '(.*)'")]
        public void ThenEmailAddressCannotBeNullErrorShouldBeDisplayed(string p0)
        {
            homePage.CheckEmailError(MyResource.EmptyEmailError);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            homePage.ClickLogin<HomePage>();
        }

        [Given(@"I have not typed in email")]
        public void GivenIHaveNotTypedInEmail()
        {
            homePage.FillInEmail("", "Email");
        }

        [Given(@"I have typed in email with wrong format")]
        public void GivenIHaveTypedInEmailWithWrongFormat()
        {
            homePage.FillInEmail(MyResource.InvalidEmail, "Email");
        }

        [Then(@"I should see the Email format error '(.*)'")]
        public void ThenIShouldSeeTheEmailFormatError(string p0)
        {
            homePage.CheckEmailError(MyResource.InvalidEmailFormatError);
        }

        [Given(@"I have typed in incorrect password")]
        public void GivenIHaveTypedInIncorrectPassword()
        {
            homePage.FillInPassword(MyResource.InvalidPassword, "Password");
        }

        [Then(@"I should the Invalid email/password error '(.*)'")]
        public void ThenIShouldTheInvalidEmailPasswordError(string p0)
        {
            homePage.CheckPasswordError(MyResource.InvalidLoginError);
        }

        [Given(@"I have typed in password")]
        public void GivenIHaveTypedInPassword()
        {
            homePage.FillInPassword(MyResource.Password, "Password");
        }

        [Then(@"I should land on the Dashboard page")]
        public void ThenIShouldLandOnTheDashboardPage()
        {
            dashboardPage = new DashboardPage(WebDriverBDD.WebDriver);
            dashboardPage.CheckDashboardTitle(MyResource.DashboardTitle);
        }

        [Then(@"I should see the footer links")]
        public void ThenIShouldSeeTheFooterLinks()
        {
            homePage.CheckFooterLinks();
        }

        [Then(@"I should be redirected to WikiPage '(.*)'")]
        public void ThenIShouldBeRedirectedToWikiPage(string p0)
        {
            wikiPage = new WikiPage(WebDriverBDD.WebDriver);
            wikiPage.CheckWikiTitle(MyResource.WikiTitle);
        }
    }
}
