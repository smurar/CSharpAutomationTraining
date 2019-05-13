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

namespace Course2
{
   public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public string homeURL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["homeURL"];

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            Reporter.EndReporting();
        }

        [SetUp]
        public void BeforeTest()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
            Reporter.EndTest();
        }

        public HomePage GoToHomePage()
        {
            Driver.Url = homeURL;
            return new HomePage(Driver);
        }
    }
}
