using Course2.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    public class BaseTest
    {

        public IWebDriver WebDriver { get; set; }
        public HomePage _homePage;
        public DashboardPage _dashboardPage;
        public WikiPage _wikiPage;

        public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];
               

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
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

        }

        [TearDown]
        public void TearDown()
        {
            Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(WebDriver));
            Reporter.EndTest();
            WebDriver.Quit();

        }

        public HomePage GoToHomePage()
        {
            WebDriver.Url = URL;

            return new HomePage(WebDriver);
        }

        public void GoToDashboardPage()
        {
            _homePage = GoToHomePage();
            _dashboardPage = _homePage.SuccessfulLogin("admin@domain.org", "111111");
        }
    }
}
