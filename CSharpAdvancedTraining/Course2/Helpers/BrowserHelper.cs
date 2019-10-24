using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CSharpAdvancedTraining.Course2.Helpers
{
	public static class BrowserHelper
	{
		/// <summary>
		/// Check if element is Displayed or not on the page, this works only when element exists in HTML but it's not displayed/rendered.
		/// For case when element is not in HTML code use TryFindElement method
		/// </summary>
		/// <param name="element">WebElement</param>
		/// <returns>true or false</returns>
		public static bool IsElementDisplayed(this IWebDriver WebDriver, IWebElement element, string elementName)
		{
			bool isDisplayed = true;
			Reporter.LogInfo("Checking if element: '" + elementName + "' is displayed or not on the page");
			WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)DelayType.ShortDelay);
			try
			{
				isDisplayed = element.Displayed;
				Reporter.LogInfo("Element '" + elementName + "' is displayed on the page");
			}
			catch (Exception e)
			{
				isDisplayed = false;
				Reporter.LogInfo("Element '" + elementName + "' is not displayed on the page, exception: " + e.ToString());
			}
			finally
			{
				WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)DelayType.ImplicitWaitDefaultValue);
			}
			return isDisplayed;
		}

		public static bool TryFindElement(this IWebDriver WebDriver, By element, string elementName)
		{
			bool isElementFound = false;
			Reporter.LogInfo("Trying to find element: [" + elementName + "]");
			Reporter.LogInfo("Setting implicytly wait to: '" + TimeSpan.FromSeconds((int)DelayType.ShortDelay) + "'");
			WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)DelayType.ShortDelay);
			try
			{
				WebDriver.FindElement(element);
				isElementFound = true;
				Reporter.LogInfo("Element: [" + elementName + "] was found");
			}
			catch (NoSuchElementException e)
			{
				Reporter.LogInfo("Element: [" + elementName + "] not found");
				Reporter.LogInfo("Exception: " + e.ToString());
			}
			finally
			{
				Reporter.LogInfo("Reverting implicytly wait back to default value: '" + TimeSpan.FromSeconds((int)DelayType.ImplicitWaitDefaultValue) + "'");
				WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)DelayType.ImplicitWaitDefaultValue);
			}
			return isElementFound;
		}
	}
}
