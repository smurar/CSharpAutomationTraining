using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary2.Course2
{
	public class BaseTest
	{
		public IWebDriver WebDriver { get; set; }
		public string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];

		[SetUp]
		public void BeforeTest()
		{
			WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
			WebDriver.Manage().Window.Maximize();
			Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
		}

		public HomePage GoToHomepage()
		{
			WebDriver.Url = URL;
			return new HomePage(WebDriver);
		}

		[TearDown]
		public void TearDown()
		{
			WebDriver.Quit();
			Reporter.EndTest();
		}

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
	}


}
