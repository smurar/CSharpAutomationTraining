using CSharpAutoTraining.Course3.Helpers;
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

namespace CSharpAutoTraining.Course3
{
    [Binding]
    public class WebDriverClass
    {
        public static IWebDriver WebDriver { get; set; }
        public static bool IsReportCreated = false;


        [BeforeScenario]
        public void BeforeTest()
        {
            if (!IsReportCreated)
            {
                ReporterBDD.StartReporting();

                IsReportCreated = true;
            }

            ReporterBDD.StartTest(ScenarioContext.Current.ScenarioInfo.Title);

            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            WebDriver.Manage().Window.Maximize();
        }

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
