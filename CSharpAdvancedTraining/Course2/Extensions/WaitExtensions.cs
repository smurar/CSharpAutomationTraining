using System;
using System.Threading;
using CSharpAdvancedTraining.Course2.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAdvancedTraining.Course2.Extensions
{
	public static class WaitExtensions
	{

		/// <summary>
		/// Wait for an element to be displayed
		/// </summary>
		/// <param name="element"></param>
		/// <param name="elementName"></param>
		/// <param name="timeoutSeconds"></param>
		public static void WaitElementToBeDisplayed(this IWebDriver WebDriver, IWebElement element, string elementName, int timeoutSeconds = 30)
		{
			try
			{
				Reporter.LogInfo("Wait for element: ['" + elementName + "'] to be displayed");
				WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
				wait.Until(driver => element.Displayed);
			}
			catch
			{
				try
				{
					Reporter.LogInfo("Re-trying to wait for element: '" + elementName + "'  to be displayed");
					HardcodedWait(500);
					WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
					wait.Until(driver => element.Displayed);
				}
				catch (NoSuchElementException e2)
				{
					Reporter.LogFail("Element '" + elementName + "' was not displayed");
					Reporter.LogFail("Exception: " + e2);
				}
			}
		}

		/// <summary>
		/// Wait element to be visible
		/// </summary>
		/// <param name="element"></param>
		/// <param name="timeOutSeconds"></param>
		public static void WaitElementToBeVisible(this IWebDriver WebDriver, By element, string elementName, int timeOutSeconds = (int)DelayType.HalfMinuteDelay)
		{
			try
			{
				Reporter.LogInfo("Wait for element: [" + elementName + "] to be visible");
				new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
			}
			catch (Exception e)
			{
				try
				{
					HardcodedWait((int)DelayType.AverageDelay);
					new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
				}
				catch (Exception e2)
				{
					Reporter.LogFail("Element: [" + elementName + "]  is not visible");
					Reporter.LogFail("Exception: " + e2);
				}
			}
		}

		/// <summary>
		/// Wait element to not be displayed in page
		/// </summary>
		/// <param name="element"></param>
		/// <param name="timeOutSeconds"></param>
		public static void WaitForElementNotToBeDisplayed(this IWebDriver WebDriver, IWebElement element, string elementName, int timeInSeconds = 30)
		{
			Reporter.LogInfo("Wait for element '" + elementName + "' to not be displayed");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeInSeconds));
			wait.Until(driver => !element.Displayed);
		}

		public static void HardcodedWait(int miliseconds)
		{
			Reporter.LogInfo("Hardcoded wait(miliseconds): '" + miliseconds + "'");
			Thread.Sleep(TimeSpan.FromMilliseconds(miliseconds));
		}

		/// <summary>
		/// Wait element to not be displayed in HTML. This is required when element does not exist in page
		/// </summary>
		/// <param name="element"></param>
		/// <param name="timeOutSeconds"></param>
		public static void WaitElementToNotBeDisplayedInHTML(this IWebDriver WebDriver, By element, string elementName, int timeOutSeconds = 30)
		{
			Reporter.LogInfo("Wait for element to not be displayed in HTML");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds));

			wait.Until(driver => !BrowserHelper.TryFindElement(WebDriver, element, elementName));
		}


		/// <summary>
		/// Wait for number of open windows to be as expected
		/// </summary>
		/// <param name="windowsNumber"></param>
		/// <param name="timeOutSeconds"></param>
		public static void WaitWindowsNumberToBeEqualWith(this IWebDriver WebDriver, int windowsNumber, int timeOutSeconds)
		{
			Reporter.LogInfo("Wait for windows number to be equal with: '" + windowsNumber + "'");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds));
			wait.Until(WindowsNumberToBeEqualWith(WebDriver, windowsNumber));
		}

		/// <summary>
		/// Wait windows number to be equal with a specific value
		/// </summary>
		/// <param name="windowsNumber"></param>
		/// <returns></returns>
		private static Func<IWebDriver, bool> WindowsNumberToBeEqualWith(this IWebDriver WebDriver, int windowsNumber)
		{
			return driver => { return WebDriver.WindowHandles.Count == windowsNumber; };
		}
		/// <summary>
		/// Wait for element to contain a specific text
		/// </summary>
		/// <param name="WebDriver"></param>
		/// <param name="element"></param>
		/// <param name="textToCheck"></param>
		/// <param name="elementName"></param>
		/// <param name="timeOutSeconds"></param>
		public static void WaitElementToContainsText(this IWebDriver WebDriver, IWebElement element, string textToCheck, string elementName, int timeOutSeconds = 30)
		{
			Reporter.LogInfo("Wait for element: ['" + elementName + "'] to contains text: '" + textToCheck + "'");
			WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds));
			wait.Until(x => element.Text.Contains(textToCheck));
		}
	}
}
