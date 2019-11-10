using TechTalk.SpecFlow;
using TestProject.Resources.Class;
using TestProject.Resources.POM;

namespace TestProject.Courses.Course3.Steps
{
    [Binding]
    public class DashboardPageSteps
    {
        private HomePagePOM homePage;
        private DashboardPagePOM dashboardPage;

        [StepDefinition(@"The user lands succesfully on DashboardPage")]
        public void ThenTheUserLandsSuccesfullyOnDashboardPage()
        {
            dashboardPage = new DashboardPagePOM(Driver.DriverInstance);
            dashboardPage.CheckPageTitle();           
        }

        [Then(@"All the DashboarPage header items are displayed")]
        public void ThenAllTheHeaderItemsAreDisplayed()
        {
            dashboardPage.CheckPageHeaderElements();            
        }

        [Then(@"The DashboardPage headling title is displayed")]
        public void ThenTheHeadlingTitleIsDisplayed()
        {
            dashboardPage.CheckHeadlingTitle();           
        }

        [Then(@"All the DashboardPage footer items are displayed")]
        public void ThenAllTheDashboardPageFooterItemsAreDisplayed()
        {
            dashboardPage.CheckFooterElements();          
        }

        [StepDefinition(@"The user clicks on log out button")]
        public void GivenTheUserClicksOnLogOutButton()
        {
            homePage = dashboardPage.GoToHomePage();
        }

        [Given(@"The user completes all fields")]
        public void GivenTheUserCompletesAllFields()
        {
            dashboardPage.CompleteAllFields();
        }

        [When(@"The user click the save button")]
        public void WhenTheUserClickTheSaveButton()
        {
            dashboardPage.ClickSaveButton();
        }

        [Then(@"A confirmation message is displayed")]
        public void ThenAConfirmationMessageIsDisplayed()
        {
            dashboardPage.CheckMessageAfterSave();
        }
    }
}
