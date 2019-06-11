using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using TestProject.Course2.Base;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Class;

namespace TestProject.Course3
{
    [Binding]
    public class WebDriverBDD
    {
        public static IWebDriver Driver { get; set; }
        private static bool IsReportCreated = false;

        [BeforeScenario]
        public void BeforeTest()
        {
            if (!IsReportCreated)
            {
                Reporter.StartReporting();
                IsReportCreated = true;
            }

            Reporter.StartTest(Helpers.GetCurrentTestName());
            ConfigureDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
            Reporter.EndTest();
            Reporter.EndReporting();
        }

        public void ConfigureDriver()
        {
            switch (Helpers.GetBrowserType("BrowserType"))
            {
                case "Chrome":
                    Driver = new ChromeDriver(Paths.Driver);
                    break;

                case "Firefox":
                    Driver = new FirefoxDriver(Paths.Driver);
                    break;
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
    }
}
