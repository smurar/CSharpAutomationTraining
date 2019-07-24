using System.IO;
using System.Reflection;
using Course1.Course2;
using Course1.Course2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Course1
{
    public class TestBase
    {
        public IWebDriver WebDriver { get; set; }
        public IWebElement WebElement { get; set; }
        public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];

        [SetUp]
        public void BeforeTest()
        {
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
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