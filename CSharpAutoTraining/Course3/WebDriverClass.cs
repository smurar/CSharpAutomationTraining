using CSharpAutoTraining.Course3.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining.Course3
{
    /// <summary>
    /// WebDriver class.
    /// </summary>
    [Binding]
    public class WebDriverClass
    {
        public static IWebDriver WebDriver { get; set; }
        public static bool IsReportCreated = false;
        private string Browser { get; set; } = System.Configuration.ConfigurationManager.AppSettings["Browser"];

        /// <summary>
        /// Calls StartReporting() and creates new WebDriver object
        /// </summary>
        [BeforeScenario]
        public void BeforeTest()
        {
            if (!IsReportCreated)
            {
                ReporterBDD.StartReporting();

                IsReportCreated = true;
            }

            ReporterBDD.StartTest(ScenarioContext.Current.ScenarioInfo.Title);

            switch(Browser)
            {
                case "Firefox":
                    {
                        ReporterBDD.LogInfo("Starting Mozilla Firefox browser");
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
                        WebDriver = new FirefoxDriver(service);
                        break;
                    }
                case "Edge":
                    {
                        ReporterBDD.LogInfo("Starting Microsoft Edge browser");
                        WebDriver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
                        break;
                    }
                case "HeadlessChrome":
                    {
                        ReporterBDD.LogInfo("Starting Headless Chrome browser");
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--headless");
                        chromeOptions.AddArguments("--start-maximized");
                        WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers", chromeOptions);
                        break;
                    }
                default:
                    {
                        ReporterBDD.LogInfo("Starting Chrome browser");
                        WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
                        break;
                    }
            }
                                    
            WebDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Logs screenshot after test is run, quits Webdriver and calls EndTest() and EndReporting()
        /// </summary>
        [AfterScenario]
        public void AfterTest()
        {
            ReporterBDD.LogScreenshot("Screenshot", ImageHelperBDD.CaputeScreen(WebDriver));

            WebDriver.Quit();
                        
            ReporterBDD.EndTest();
            ReporterBDD.EndReporting();
        }
    }
}
