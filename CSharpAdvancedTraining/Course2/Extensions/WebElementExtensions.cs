using OpenQA.Selenium;

namespace CSharpAdvancedTraining.Course2.Extensions
{
	public static class WebElementExtensions
	{
		/// <summary>
		/// Click a webelement
		/// </summary>
		/// <param name="element"></param>
		/// <param name="elementName"></param>
		public static void Click(this IWebElement element, string elementName)
		{
			Reporter.LogInfo("Click element: " + elementName);
			element.Click();
			Reporter.LogInfo("Clicked element with name: '" + elementName + "'");
		}

		/// <summary>
		/// Send text to a input webelement
		/// </summary>
		/// <param name="element"></param>
		/// <param name="textToWrite"></param>
		/// <param name="elementName"></param>
		public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
		{
			Reporter.LogInfo("Write text '" + textToWrite + "' to element: " + elementName);
			element.SendKeys(textToWrite);
		}
	}
}
