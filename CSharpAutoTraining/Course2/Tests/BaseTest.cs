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

namespace CSharpAutoTraining.Course2
{
    class BaseTest
    {
        public IWebDriver WebDriver { get;  private set; }

        
        [OneTimeSetUp]
        public void beforeTestClass()
        {
            Reporter.StartReporting();
        }
        


        [OneTimeTearDown]
        public void afterTestClass()
        {
            Reporter.EndReporting();
        }



        [SetUp]
        public void InitializeTest()
        {
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            WebDriver.Manage().Window.Maximize();

            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
        }



        [TearDown]
        public void CloseTest()
        {
            Reporter.LogScreenshot("Screenshot", ImageHelper.CaputeScreen(WebDriver));

            WebDriver.Close();

            Reporter.EndTest();                        
        }
    }
}
