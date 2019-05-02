using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Course2.POM;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Class;

namespace TestProject.Course2.Base
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }             

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Driver = new ChromeDriver(Paths.Driver);
            Driver.Manage().Window.Maximize();
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            Reporter.EndReporting();            
        }

        [TearDown]
        public void AfterEachTest()
        {            
            Driver.Quit();
            Reporter.EndTest();
            ImageHelper.ResetScreenShotNumber();
        }

        public HomePagePOM GoToHomePage()
        {
            Driver.Url = Paths.HomePageUrl;

            return new HomePagePOM(Driver);
        }        

        public DashboardPagePOM GoToDashboardPage()
        {
            GoToHomePage()
                .LogInSuccesful();
               
            return new DashboardPagePOM(Driver);
        }        
    }
}
