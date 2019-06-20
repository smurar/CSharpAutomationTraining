using NUnit.Framework;
using TestProject.Resources.POM;
using TestProject.Resources.Reports;
using TestProject.Resources.Class;


namespace TestProject.Course2.Base
{
    public class BasePage 
    {                  
        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Driver.ConfigureDriver();
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
            Driver.DriverInstance.Quit();        
            Reporter.EndTest();
            ImageHelper.ResetScreenShotNumber();
        }              

        public HomePagePOM GoToHomePage()
        {
            Driver.DriverInstance.Navigate().GoToUrl(Paths.HomePageUrl);
            Driver.DriverInstance.Url = Paths.HomePageUrl;

            return new HomePagePOM(Driver.DriverInstance);
        }

        public DashboardPagePOM GoToDashboardPage()
        {
            GoToHomePage()
                .LogInSuccesful();

            return new DashboardPagePOM(Driver.DriverInstance);
        }
    }
}
