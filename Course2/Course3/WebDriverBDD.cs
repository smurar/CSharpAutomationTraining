using Course2.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Course2.Course3
{
    [Binding]
    class WebDriverBDD
    {
        public static IWebDriver WebDriver { get; set; }
        private static bool IsReportCreated = false;
        ScenarioContext _scenarioContext;
        FeatureContext _featureContext;

        public WebDriverBDD(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeTest()
        {
            if (!IsReportCreated)
            {
                Reporter.StartReporting();
                IsReportCreated = true;
            }
            Reporter.StartTest(_scenarioContext.ScenarioInfo.Title);
            WebDriver = new
            ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Url = System.Configuration.ConfigurationManager.AppSettings["URL"];
        }
        [AfterScenario]
        public void AfterTest()
        {
            WebDriver.Quit();
            Reporter.EndTest();
            Reporter.EndReporting();
        }
    }
}
