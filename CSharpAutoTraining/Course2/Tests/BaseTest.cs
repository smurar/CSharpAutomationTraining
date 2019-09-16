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
using System.Configuration;
using CSharpAutoTraining.Course2.PageObjects;

namespace CSharpAutoTraining.Course2.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            // init driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            Reporter.StartReporting();
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            driver.Quit();

            Reporter.EndReporting();
        }

        [SetUp]
        public void SetUp()
        {
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
            Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(driver));
        }

        [TearDown]
        public void TearDown()
        {
            Reporter.EndTest();
        }

        protected HomePage GoToHomePage()
        {
            driver.Url = ConfigurationManager.AppSettings["HOME_PAGE_URL"];

            return new HomePage(driver);
        }

        protected DashboardPage GoToDashboardPage()
        {
            driver.Url = ConfigurationManager.AppSettings["DASHBOARD_PAGE_URL"];

            return new DashboardPage(driver);
        }
    }
}
