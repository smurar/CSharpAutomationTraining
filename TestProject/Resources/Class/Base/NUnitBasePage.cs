using NUnit.Framework;
using TestProject.Resources.POM;
using TestProject.Resources.Reports;
using TestProject.Resources.Class;


namespace TestProject.Resources.Base
{
    public class NUnitBasePage : Driver
    {                  
        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            ConfigureDriver();
            Reporter.StartTest(Helpers.GetCurrentTestName());
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            Reporter.EndReporting();             
        }

        [TearDown]
        public void AfterEachTest()
        {            
            DriverInstance.Quit();        
            Reporter.EndTest();
            ImageHelper.ResetScreenShotNumber();
        }              

        public HomePagePOM GoToHomePage()
        {
            DriverInstance.Navigate().GoToUrl(Paths.HomePageUrl);
            DriverInstance.Url = Paths.HomePageUrl;

            return new HomePagePOM(DriverInstance);
        }

        public DashboardPagePOM GoToDashboardPage()
        {
            GoToHomePage()
                .LogInSuccesful();

            return new DashboardPagePOM(DriverInstance);
        }
    }
}
