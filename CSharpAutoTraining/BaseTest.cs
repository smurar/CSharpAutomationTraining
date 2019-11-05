using CSharpAutoTraining.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace CSharpAutoTraining
{
    public class BaseTest
    {
        private IWebDriver Driver { get; set; }

        private string Browser { get; set; } = ConfigurationManager.AppSettings["Browser"];
        public string URL { get; set; } = ConfigurationManager.AppSettings["URL"];
        


        [OneTimeSetUp]
        public void beforeTestClass()
        {
            Reporter.StartReporting(TestContext.CurrentContext.Test.MethodName);
        }

        [OneTimeTearDown]
        public void afterTestClass()
        {
            Reporter.EndReporting();
        }

        [SetUp]
        public void SetUp()
        {
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
            StartBrowser();

        }

        [TearDown]
        public void TearDown()
        {
            Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(Driver));
            Reporter.EndTest();
            Driver.Quit();

        }

        private void StartBrowser()
        {
            switch(Browser)
            {
                case "CH":
                    Reporter.LogInfo("Starting Chrome browser");
                    ChromeOptions chOptions = new ChromeOptions();
                    chOptions.AddArgument("--headless");
                    Driver = new ChromeDriver(ConfigurationManager.AppSettings["WebDriver"]);
                    break;
                case "FF":
                    Reporter.LogInfo("Starting Firefox browser");
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(ConfigurationManager.AppSettings["WebDriver"]);
                    FirefoxOptions ffOption = new FirefoxOptions();
                    Driver = new FirefoxDriver(service);
                    break;
                case "ME":
                    Reporter.LogInfo("Starting Microsoft Edge browser");
                    Driver = new EdgeDriver(ConfigurationManager.AppSettings["WebDriver"]);
                    break;
            }
            Driver.Manage().Window.Maximize();
            
        }

        public HomePage GoToHomePage()
        {
            Driver.Url = URL;

            return new HomePage(Driver);
        }

        public DashboardPage GoToDashboardPage()
        {
            GoToHomePage()
                .SuccessfulLogin(Constants.EmailValid, Constants.PasswordValid)
                .WaitForPageToLoad();

            return new DashboardPage(Driver);
        }
    }
}