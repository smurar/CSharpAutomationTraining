using CSharpAutoTraining.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining
{
    public class BaseTest
    {
        private IWebDriver Driver { get; set; }

        public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];


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
        public void SetUp()
        {
            Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
            Driver = new ChromeDriver(System.Configuration.ConfigurationManager.AppSettings["ChromeDriver"]);

        }

        [TearDown]
        public void TearDown()
        {
            Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(Driver));
            Reporter.EndTest();
            Driver.Quit();

        }

        public HomePage GoToHomePage()
        {
            Driver.Url = URL;

            return new HomePage(Driver);
        }

        public DashboardPage GoToDashboardPage()
        {
            GoToHomePage()
                .SuccessfulLogin(Constants.EmailValid, Constants.PasswordValid)
                .WaitForPageToLoad();

            return new DashboardPage(Driver);
        }
    }
}