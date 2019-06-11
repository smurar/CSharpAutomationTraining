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

		/// <summary>
		/// Wait for an element to be displayed
		/// </summary>
		/// <param name="element"></param>
		/// <param name="elementName"></param>
		/// <param name="timeoutSeconds"></param>
		public void WaitElementToBeDisplayed(IWebElement element, string elementName, int timeoutSeconds)
		{
			Reporter.LogInfo("Wait for element: ['" + elementName + "'] to be displayed");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
			wait.Until(driver => element.Displayed);
		}

		/// <summary>
		/// Wait for number of open windows to be as expected
		/// </summary>
		/// <param name="windowsNumber"></param>
		/// <param name="timeOutSeconds"></param>
		public void WaitWindowsNumberToBeEqualWith(int windowsNumber, int timeOutSeconds)
		{
			Reporter.LogInfo("Wait for windows number to be equal with: '" + windowsNumber + "'");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds));
			wait.Until(WindowsNumberToBeEqualWith(windowsNumber));
		}

		/// <summary>
		/// Wait windows number to be equal with a specific value
		/// </summary>
		/// <param name="windowsNumber"></param>
		/// <returns></returns>
		private Func<IWebDriver, bool> WindowsNumberToBeEqualWith(int windowsNumber)
		{
			return driver => { return WebDriver.WindowHandles.Count == windowsNumber; };
		}
	}
}
