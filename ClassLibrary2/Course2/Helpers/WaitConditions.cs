using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary2.Course2.Helpers
{
	public class WaitConditions
	{

		private IWebDriver WebDriver;

		public WaitConditions(IWebDriver driver)
		{
			WebDriver = driver;
		}

		public void WaitElementToBeDisplayed(IWebElement element, string elementName, int timeoutSeconds)
		{
			Reporter.LogInfo("Wait for element: ['" + elementName + "'] to be displayed");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
			wait.Until(driver => element.Displayed);
		}
	}
}
