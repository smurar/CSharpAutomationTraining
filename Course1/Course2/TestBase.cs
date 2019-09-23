using System.IO;
using System.Reflection;
using Course1.Course2;
using Course1.Course2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Course1
{
    public class TestBase
    {
        public IWebDriver WebDriver { get; set; }
        public IWebElement WebElement { get; set; }
        public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];
        private string Browser { get; set; } = System.Configuration.ConfigurationManager.AppSettings["Browser"];

        [SetUp]
        public void BeforeTest()
        {
            //WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
            StartBrowser();
        }

        private void StartBrowser()
        {
            switch (Browser)
            {
                case "FF":
                    {
                        Reporter.LogInfo("Starting Firefox browser");
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
                        WebDriver = new FirefoxDriver(service);
                        break;
                    }
                case "ME":
                    {
                        Reporter.LogInfo("Starting Microsoft Edge browser");
                        WebDriver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
                        break;
                    }
                default:
                    {
                        Reporter.LogInfo("Starting Chrome browser");
                        WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
                        break;
                    }
            }
        }

        [TearDown]
        public void AfterTest()
        {
            WebDriver.Quit();
        }

        public HomePage GoToHomePage()
        {
            WebDriver.Url = URL;
            return new HomePage(WebDriver);
        }

        [OneTimeSetUp]
        public void beforeTestClass()
        {
            Reporter.StartReporting();
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
        }

        [TearDown]
        public void TearDown()
        {
            Reporter.EndTest();
        }
    }
}