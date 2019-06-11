using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Course2;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ClassLibrary2
{
	[Binding]
	public class TestBaseBDD
	{
		public static IWebDriver WebDriver { get; set; }
		private static bool IsReportCreated = false;

		[BeforeScenario]
		public void BeforeTest()
		{
			if (!IsReportCreated)
			{
				Reporter.StartReporting();
				IsReportCreated = true;
			}
			Reporter.StartTest(ScenarioContext.Current.ScenarioInfo.Title);
			WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\");
			WebDriver.Url = System.Configuration.ConfigurationManager.AppSettings["URL"];
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
