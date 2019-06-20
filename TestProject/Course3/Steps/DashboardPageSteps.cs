using TechTalk.SpecFlow;
using TestProject.Resources.Class;
using TestProject.Resources.POM;

namespace TestProject.Course3.Steps
{
    [Binding]
    public class DashboardPageSteps
    {
        private HomePagePOM homaPage;
        private DashboardPagePOM dashboarPage;

        [StepDefinition(@"The user lands succesfully on DashboardPage")]
        public void ThenTheUserLandsSuccesfullyOnDashboardPage()
        {
            dashboarPage = new DashboardPagePOM(Driver.DriverInstance);
            dashboarPage.CheckPageTitle();           
        }

        [Then(@"All the DashboarPage header items are displayed")]
        public void ThenAllTheHeaderItemsAreDisplayed()
        {
            dashboarPage.CheckPageHeaderElements();            
        }

        [Then(@"The DashboardPage headling title is displayed")]
        public void ThenTheHeadlingTitleIsDisplayed()
        {
            dashboarPage.CheckHeadlingTitle();           
        }

        [Then(@"All the DashboardPage footer items are displayed")]
        public void ThenAllTheDashboardPageFooterItemsAreDisplayed()
        {
            dashboarPage.CheckFooterElements();          
        }

        [Given(@"The user clicks on log out button")]
        public void GivenTheUserClicksOnLogOutButton()
        {
            homaPage = dashboarPage.GoToHomePage();
        }

        [Given(@"The user completes all fields")]
        public void GivenTheUserCompletesAllFields()
        {
            dashboarPage.CompleteAllFields();
        }

        [When(@"The user click the save button")]
        public void WhenTheUserClickTheSaveButton()
        {
            dashboarPage.ClickSaveButton();
        }

        [Then(@"A confirmation message is displayed")]
        public void ThenAConfirmationMessageIsDisplayed()
        {
            dashboarPage.CheckMessageAfterSave();
        }
    }
}
