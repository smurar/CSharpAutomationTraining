using Course01.Course02;
using Course01.Course03;
using System;
using TechTalk.SpecFlow;

namespace Course01
{
    [Binding]

    public class DashboardPageSteps
    {

        private DashBoardPage dashboardPage;

        private HomePage homePage;

        [Then(@"I should be on DashboardPage '(.*)'")]
        public void ThenIShouldBeOnDashboardPage(string title)
        {
            dashboardPage = new DashBoardPage(WebDriverBDD.WebDriver);

            dashboardPage.CheckPageTitle(title);
        }

        [When(@"I click login button to Dashboard Page")]
        public void ClickLoginButtonPositiveFlow()
        {
            homePage = new HomePage(WebDriverBDD.WebDriver);

            dashboardPage = new DashBoardPage(WebDriverBDD.WebDriver);

            dashboardPage = homePage.LoginWithValidCredentials();
        }
    }
}
