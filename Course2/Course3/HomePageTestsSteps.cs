using Course2.PageObjects;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Course2.Course3
{
    [Binding]
    public class HomePageTestsSteps
    {
        private HomePage homePage;
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);
        }
        
        [Given(@"I have typed in email")]
        public void GivenIHaveTypedInEmail(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray(); //work with Tables
            homePage.FillInEmail(credentialsFirstRow[0]);
        }

        [Given(@"I have typed in email and Password")]
        public void GivenIHaveTypedInEmailAndPassword(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            GivenIHaveTypedInEmail(table);
            homePage.FillInPassword(credentialsFirstRow[1]);
        }
        



        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            homePage.ClickLogin<HomePage>();
        }

        [When(@"I click on WikiPagelink")]
        public void WhenIClickOnWikiPagelink()
        {
            homePage.GoToWikiPage();
        }

        

        [Then(@"I should be redirected to HomePage'(.*)'")]
        public void ThenIShouldBeRedirectedToHomePage(string p0)
        {
            homePage.CheckPageTitle(p0);
        }



        [Then(@"I should remain on homepage '(.*)'")]
        public void ThenIShouldRemainOnHomepage(string p0)
        {
            homePage.CheckPageTitle(p0);
        }

        [Then(@"I should see the header links")]
        public void ThenIShouldSeeTheHeaderLinks()
        {
            homePage.CheckHomePageLink();
            homePage.CheckWikiPageLink();
        }

        [Then(@"I should see the header image")]
        public void ThenIShouldSeeTheHeaderImage()
        {
            homePage.CheckHeaderImage();
        }

        [Then(@"I should see the page heading title '(.*)'")]
        public void ThenIShouldSeeThePageHeadingTitle(string p0)
        {
            homePage.CheckHeadingTitle(p0);
        }

        [Then(@"I should see the default email text '(.*)'")]
        public void ThenIShouldSeeTheDefaultEmailText(string p0)
        {
            homePage.CheckDefaultEmail(p0);
            
        }

        [Then(@"I should see the default password text '(.*)'")]
        public void ThenIShouldSeeTheDefaultPasswordText(string p0)
        {
            homePage.CheckDefaultPassword(p0);
        }

        [Then(@"I should see the email and password fields")]
        public void ThenIShouldSeeTheEmailAndPasswordFields()
        {
            homePage.CheckLoginFieldsAreDisplayed();
        }



        [Then(@"I should see the validation message ""(.*)""")]
        public void ThenIShouldSeeTheValidationMessage(string p0)
        {
            homePage.CheckNullEmailValidationText(p0);
        }

        [Then(@"I should see the password validation message ""(.*)""")]
        public void ThenIShouldSeeThePasswordValidationMessage(string p0)
        {
            homePage.CheckInvalidPasswordValidationMessage(p0);
        }




    }
}
