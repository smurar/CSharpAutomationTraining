using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CSharpAdvancedTraining.Course2
{
	public class BaseTest
	{
		public IWebDriver WebDriver { get; set; }
		private string URL { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL"];
		private string URL_FRAMES { get; set; } = System.Configuration.ConfigurationManager.AppSettings["URL_FRAMES"];
		private string Browser { get; set; } = System.Configuration.ConfigurationManager.AppSettings["Browser"];

		[SetUp]
		public void BeforeTest()
		{
			Reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
			StartBrowser();
			WebDriver.Manage().Window.Maximize();
		}

		private void StartBrowser()
		{
			switch (Browser) {
				case "FF":
					{
						Reporter.LogInfo("Starting Firefox browser");
						FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
						WebDriver = new FirefoxDriver(service);
						break;
					}
				case "ME":
					{
						Reporter.LogInfo("Starting Microsoft Edge browser");
						WebDriver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
						break;
					}
				default:
					{
						Reporter.LogInfo("Starting Chrome driver");
						WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
						break;
					}

			}
		}

		public HomePage GoToHomepage()
		{
			WebDriver.Url = URL;
			return new HomePage(WebDriver);
		}

		public HomePage GoToHomepageWithFrames()
		{
			WebDriver.Url = URL_FRAMES;
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
