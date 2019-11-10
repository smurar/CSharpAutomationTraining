using TechTalk.SpecFlow;
using TestProject.Resources.POM;
using TestProject.Resources.Class;
using TestProject.Resources.Resx;

namespace TestProject.Courses.Course3.Steps
{
    [Binding]
    public class HomePageFeatureSteps
    {
        public HomePagePOM homePage;
        public DashboardPagePOM dashboardPage;
        public WikiPagePOM wikiPage;
        public FramesPagePOM framesPage;

        [Given(@"The user navigates to HomePage")]
        public void GivenTheUserNavigatesToHomePage()
        {
            Driver.DriverInstance.Navigate().GoToUrl(Paths.HomePageUrl);
            Driver.DriverInstance.Url = Paths.HomePageUrl;
            homePage = new HomePagePOM(Driver.DriverInstance);
        }
        
        [StepDefinition(@"The user lands succesfully on HomePage")]       
        public void WhenTheUserLandsSuccesfullyOnHomePage()
        {
            homePage.CheckPageTitle();      
        }
        
        [Then(@"All the header items are displayed")]
        public void ThenAllTheHeaderItemsAreDisplayed()
        {
            homePage.CheckPageHeaderElements();           
        }

        [Then(@"The Headling title is displayed")]
        public void ThenTheHeadlingTitleIsDisplayed()
        {
            homePage.CheckHeadlingTitle();            
        }

        [Then(@"The corect log in credentials are displayed")]
        public void ThenTheCorectLogInCredentialsAreDisplayed()
        {
            homePage.CheckDefaultLogInCredentials();            
        }

        [Then(@"The log in fiels are displayed")]
        public void ThenTheLogInFielsAreDisplayed()
        {
            homePage.CheckLogInFields();           
        }

        [When(@"The user clicks on log in button")]
        public void AndUserClicksOnLogInButton()
        {            
            homePage.ClickLogin<HomePagePOM>();
        }

        [Then(@"An empty credentisls warning message is displayed")]
        public void ThenAnEmptyCredentislsWarningMessageIsDisplayed()
        {
            homePage.ChecLogInWithEmptyCredentialsError();            
        }

        [When(@"The user enters an invalid email")]
        public void WhenTheUserEntersAnInvalitEmail()
        {
            homePage.EnterUser(HomePageResx.InvalidUser);
        }

        [Then(@"An invalid email error message is displayed")]
        public void ThenAnInvalidEmailErrorMessageIsDisplayed()
        {
           homePage.CheckEmailFieldError(HomePageResx.EmailFormatError);
        }

        [When(@"The user enters invalid log in credentials")]
        public void WhenTheUserEntersInvalidLogInCredentials()
        {
            homePage.EnterInvalidLogInCredentials();
        }

        [Then(@"An invalid password or email error message is displayed")]
        public void ThenAnInvalidPasswordOrEmailErrorMessageIsDisplayed()
        {
           homePage.CheckPasswrodFieldError(HomePageResx.InvalidPasswordEmailError);
        }

        [Then(@"All the footer items are displayed")]
        public void ThenAllTheFooterItemsAreDisplayed()
        {
            homePage.CheckFooterElements();
        }

        [When(@"The user navigates to WikiPage")]
        public void WhenTheUserNavigatesToWikiPage()
        {
            wikiPage = homePage.GoToWikiPage();
        }

        [StepDefinition(@"The user logs in with success")]
        public void WhenTheUserEntersCorectUresnameAndPassword()
        {
            homePage.EnterUser(HomePageResx.User)
                .EnterPassword(HomePageResx.Password);
            dashboardPage = homePage.ClickLogin<DashboardPagePOM>();
        }

        [StepDefinition(@"The user clicks the frames page link")]
        public void GivenTheUserClicksTheFramesPageLink()
        {
            framesPage = homePage.GoToFramesPage();
        }

    }
}
