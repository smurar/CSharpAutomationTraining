﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TestProject.Course2.POM;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Class;

namespace TestProject.Course2.Base
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }             

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            ConfigureDriver();
            Reporter.StartTest(Helpers.GetCurrentTestName());
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            Reporter.EndReporting();            
        }

        [TearDown]
        public void AfterEachTest()
        {            
            Driver.Quit();        
            Reporter.EndTest();
            ImageHelper.ResetScreenShotNumber();
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

        public HomePagePOM GoToHomePage()
        {
            Driver.Navigate().GoToUrl(Paths.HomePageUrl);
            Driver.Url = Paths.HomePageUrl;

            return new HomePagePOM(Driver);
        }

        public DashboardPagePOM GoToDashboardPage()
        {
            GoToHomePage()
                .LogInSuccesful();

            return new DashboardPagePOM(Driver);
        }
    }
}
