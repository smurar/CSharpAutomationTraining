using Course01.Course02;
using Course01.Course03;
using Course01.Screens;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Course01
{
    [Binding]
    public class HomePageTestsSteps
    {
        private HomePage homePage;

        private WikiPage wikiPage;

        [Then(@"I verify that header and image are displayed")]
        public void GivenIVerifyThatHeaderAndImageAreDisplayed()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);

            homePage.CheckPageTitle(Resource.PageTitle).CheckImageDisplayed().CheckHeaderDisplayed();
        }


        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);
        }
        
        [Given(@"I have typed in email")]
        public void GivenIHaveTypedInEmail(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            homePage = homePage.FillInEmail(credentialsFirstRow[0]);
        }

        [Given(@"I have typed in email and the password")]
        public void GivenIHaveTypedInEmailAndThePassword(Table table)
        {
           
        }


        [When(@"I click login button")]
        public void ClickLoginButtonNegativeFlow()
        {
            homePage = homePage.ClickLogin<HomePage>();
        }
        
        [Then(@"I should remain on homepage '(.*)'")]
        public void ThenIShouldRemainOnHomepage(string p0)
        {
           homePage.AssertPageTitleIs(p0);
        }

        [When(@"I click on WikiPage link")]
        public void WhenIClickOnWikiPageLink()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);

            wikiPage = new WikiPage(WebDriverBDD.WebDriver);

            wikiPage = homePage.ClickOnWikiPage();
        }
    }

}
