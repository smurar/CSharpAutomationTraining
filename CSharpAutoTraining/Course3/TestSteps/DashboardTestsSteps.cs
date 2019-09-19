using CSharpAutoTraining.Course3.Pages;
using CSharpAutoTraining.Properties;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining.Course3.TestSteps
{
    [Binding]
    public class DashboardTestsSteps : WebDriverBDD
    {
        //private HomePage homePage;
        private DashboardPage dashboardPage;

        [Given(@"I am on dashboard page")]
        public void GivenIAmOnDashboardPage()
        {
            dashboardPage = GoToDashboardPage();
        }

        [Then(@"the dashboard page title is correct")]
        public void TheDashboardPageTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardTitle, GoToDashboardPage().GetPageTitle());
        }

        [Then(@"the dashboard header links and image are displayed")]
        public void TheDashboardHeaderLinksAndImageAreDisplayed()
        {
            Assert.True(dashboardPage.HeaderImageIsDisplayed());
            Assert.True(dashboardPage.HeaderLinksAreAllDisplayed());
        }

        [Then(@"the dashboard page heading title is correct")]
        public void TheDashboardPageHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardPageHeadingTitle, GoToDashboardPage().GetPageHeadingTitle());
        }

        [When(@"I fill in the firstName and lastName")]
        public void IFillInTheName(Table table)
        {

        }
    }
}
