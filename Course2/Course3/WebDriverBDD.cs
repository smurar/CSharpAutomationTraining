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

namespace Course2
{
    [Binding]
    public class WebDriverBDD
    {
        public static IWebDriver WebDriver { get; set; }
        public static bool IsReportCreated = false;

        [BeforeScenario]
        public void BeforeTest()
        {
            if (!IsReportCreated)
            {
                Reporter.StartReporting();
                IsReportCreated = true;
            }

            Reporter.StartTest(ScenarioContext.Current.ScenarioInfo.Title);
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers\")
            {
                Url = System.Configuration.ConfigurationManager.AppSettings["homeURL"]
            };

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
