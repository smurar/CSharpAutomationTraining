using Course2.Pages;
using System;
using TechTalk.SpecFlow;

namespace Course2    
{
    [Binding]
    public class DashboardPageTestsSteps
    {
        private DashboardPage dashboardPage;
        private HomePage homePage;

        [Given(@"I am on the Dashboard page")]
        public void GivenIAmOnTheDashboardPage()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);
            homePage.LoginPositiveFlow();
            dashboardPage = new DashboardPage(WebDriverBDD.WebDriver);
        }
        
        [Then(@"I should see the header links&image, page title and heading")]
        public void ThenIShouldSeeTheHeaderLinksImagePageTitleAndHeading()
        {
            dashboardPage.CheckHeaderLinks();
            dashboardPage.CheckDashboardTitle(MyResource.DashboardTitle);
            dashboardPage.CheckHeadingTitle(MyResource.DashboardHeading);
        }

        [Given(@"I edit personal information")]
        public void GivenIEditPersonalInformation()
        {
            dashboardPage.Wait();
            dashboardPage.FillInName(MyResource.FirstName, "FirstName", MyResource.LastName, "LastName");
            dashboardPage.SelectGender(MyResource.Gender);
            dashboardPage.SelectVehicle(MyResource.Vehicle);
            dashboardPage.SelectBirthDate(MyResource.Birthday, "Birthdate");
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            dashboardPage.ClickSave();
        }

        [Then(@"I should see the Details saved message")]
        public void ThenIShouldSeeTheDetailsSavedMessage()
        {
            dashboardPage.CheckDetailsSavedMessage();
        }

        [Then(@"I should see the footer links too\.")]
        public void ThenIShouldSeeTheFooterLinksToo_()
        {
            dashboardPage.CheckFooterLinks();
        }
    }
}
