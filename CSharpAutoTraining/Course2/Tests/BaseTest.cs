﻿using NUnit.Framework;
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
        public void BeforeTest()
        {
            // init driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [OneTimeTearDown]
        public void EndTests()
        {
            driver.Quit();
        }

        protected HomePage GoToHomePage()
        {
            driver.Url = System.Configuration.ConfigurationManager.AppSettings["HOME_PAGE_URL"];

            return new HomePage(driver);
        }

        protected DashboardPage GoToDashboardPage()
        {
            driver.Url = System.Configuration.ConfigurationManager.AppSettings["DASHBOARD_PAGE_URL"];

            return new DashboardPage(driver);
        }
    }
}
