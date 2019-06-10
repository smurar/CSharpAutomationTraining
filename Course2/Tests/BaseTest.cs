using NUnit.Framework;
using Course2.BrowserFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course2.PageObjects;
using OpenQA.Selenium;
using Course2.Reports;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using Course2.Resources;

namespace Course2.Tests
{
    class BaseTest
    {
       
        
        public string HomePageURL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];
        public string WindowsHandlingUrl { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL2"];

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
           Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeTest()
        {
            Reporter.StartTest(TestContext.CurrentContext.Test.ClassName+": "+ TestContext.CurrentContext.Test.MethodName);
            Browser.InitBrowser(System.Configuration.ConfigurationManager.AppSettings["BrowserName"]);
            Browser.Maximize();
             
        }

        public HomePage GoToHomePage()
        {
            Browser.GoToUrl(HomePageURL);
         
            return new HomePage(Browser.GetDriver());
        }

        public WindowsHandlingHomePage GoToHomePageForWindowsAndFramesHandling()
        {
            Browser.GoToUrl(WindowsHandlingUrl);

            return new WindowsHandlingHomePage(Browser.GetDriver());
        }

        public DashboardPage GoToDashboardPage()
        {
            GoToHomePage()
                .FillInEmail(DataHomePage.ValidEmail)
                .FillInPassword(DataHomePage.ValidPassword)
                .ClickLogin<DashboardPage>();
            return new DashboardPage(Browser.GetDriver());
        }

        [TearDown]
        public void AfterTest()
        {
           Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(Browser.GetDriver()));
            Browser.CloseAllDrivers();
            
            Reporter.EndTest();
        }


        [OneTimeTearDown]
        public void AfterTestClass()
        {
          Reporter.EndReporting();
        }
    }
}
