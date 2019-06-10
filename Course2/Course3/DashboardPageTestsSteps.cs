using Course2.PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Course2.Course3
{
    [Binding]
    public class DashboardPageTestsSteps
    {
        private DashboardPage dashboardPage;

        [Given(@"I login successfully to dashboard page")]
        public void GivenILoginSuccessfullyToDashboardPage(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            var homePage = new HomePage(WebDriverBDD.WebDriver);
            homePage.FillInEmail(credentialsFirstRow[0]);
            homePage.FillInPassword(credentialsFirstRow[1]);
            dashboardPage = homePage.ClickLogin<DashboardPage>();
        }

        [Given(@"I update my personal information")]
        public void GivenIUpdateMyPersonalInformation(Table table)
        {
            var credentialsFirstRow = table.Rows[0].Values.ToArray();
            dashboardPage.FillInFirstName(credentialsFirstRow[0]);
            dashboardPage.FillInLastName(credentialsFirstRow[1]);
            dashboardPage.FillInBirthday(credentialsFirstRow[2]);
        }

        [Given(@"I select a gender")]
        public void GivenISelectAGender()
        {
            dashboardPage.SelectGender();
        }

        [Given(@"I select Car checkbox")]
        public void GivenISelectCarCheckbox()
        {
            dashboardPage.SelectCarCheckBox();
        }

        [Given(@"I upload an image of a car")]
        public void GivenIUploadAnImageOfACar()
        {
            dashboardPage.UploadFile();
        }

        [When(@"I press the save button")]
        public void WhenIPressTheSaveButton()
        {
            dashboardPage.Save();
        }

        [When(@"I press logout button")]
        public void WhenIPressLogoutButton()
        {
            
            dashboardPage.LogOut();
        }


        [Then(@"I should see the details save message ""(.*)""")]
        public void ThenIShouldSeeTheDetailsSaveMessage(string p0)
        {
            dashboardPage.CheckSaveDetailsMessage(p0);
        }




        [Then(@"I should be redirected to Dashboard page '(.*)'")]
        public void ThenIShouldBeRedirectedToDashboardPage(string p0)
        {
            dashboardPage = new DashboardPage(WebDriverBDD.WebDriver);
            dashboardPage.CheckPageTitle(p0);
        }

        [Then(@"I should see the dashboard header links")]
        public void ThenIShouldSeeTheDashboardHeaderLinks()
        {
            dashboardPage.CheckHomePageLink();
            dashboardPage.CheckWikiPageLink();
        }

        [Then(@"I should see the dashboard header image")]
        public void ThenIShouldSeeTheDashboardHeaderImage()
        {
            dashboardPage.CheckHeaderImage();
        }

        [Then(@"I should see the dashboard page heading title '(.*)'")]
        public void ThenIShouldSeeTheDashboardPageHeadingTitle(string p0)
        {
            dashboardPage.CheckHeadingTitle(p0);
        }





    }
}
