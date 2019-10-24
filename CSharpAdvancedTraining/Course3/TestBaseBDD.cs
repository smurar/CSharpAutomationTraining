using System.IO;
using System.Reflection;
using CSharpAdvancedTraining.Course2;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace CSharpAdvancedTraining
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
