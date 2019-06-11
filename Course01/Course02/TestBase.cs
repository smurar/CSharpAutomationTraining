using Course01.Screens;
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

namespace Course01.Course02
{
    public class TestBase
    {
        public IWebDriver WebDriver { get; set; }
        public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];
        public string WindowsFrame { get; set; } = System.Configuration.ConfigurationManager.AppSettings["WindowsFrameURL"];

        [OneTimeSetUp]
        public void beforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeTest()
        {
          WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
          Reporter.StartTEST(TestContext.CurrentContext.Test.MethodName);
        }

        public WindowsHomePageHandling OpenHomePageAndGoToWindowsFrame()
        {
            WebDriver.Url = WindowsFrame;

            return new WindowsHomePageHandling(WebDriver);
        }

        [TearDown]
        public void AfterTest()
        {
            WebDriver.Quit();
            Reporter.EndTest();
        }
        [OneTimeTearDown]
        public void afterTestClass()
        {
            Reporter.EndReporting();
        }

        public HomePage GoToHomePage()
        {
            WebDriver.Url = WindowsFrame;
            return new HomePage(WebDriver);
        }
    }
}

