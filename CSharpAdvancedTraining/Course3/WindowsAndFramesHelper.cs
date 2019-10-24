using System.Collections.Generic;
using System.Linq;
using CSharpAdvancedTraining.Course2;
using OpenQA.Selenium;

namespace CSharpAdvancedTraining.Course33
{
	public static class WindowsAndFramesHelper
	{

		/// <summary>
		/// Switch to window by position
		/// </summary>
		/// <param name="position"></param>

		public static void SwitchToWindowByPosition(this IWebDriver WebDriver, int position)
		{
			IReadOnlyCollection<string> Windows = WebDriver.WindowHandles;
			Reporter.LogInfo("There are " + Windows.Count + " windows. Switch to window number: " + position);
			WebDriver.SwitchTo().Window(Windows.ElementAt(position));
		}

		/// <summary>
		/// Switch to initial window by name
		/// </summary>
		/// <param name="intialWindow"></param> 
		public static void SwitchToInitialWindow(this IWebDriver WebDriver,string intialWindow)
		{
			Reporter.LogInfo("Switch to window with name: " + intialWindow);
			WebDriver.SwitchTo().Window(intialWindow);
		}

		/// <summary>
		/// Get the name of the current window
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentWindow(this IWebDriver WebDriver)
		{
			Reporter.LogInfo("Get current window");
			return WebDriver.CurrentWindowHandle;
		}

		/// <summary>
		/// Close the current window
		/// </summary>
		public static void CloseCurrentWindow(this IWebDriver WebDriver)
		{
			Reporter.LogInfo("Close current window");
			WebDriver.Close();
		}

		/// <summary>
		/// Switch to a specific webelement frame
		/// </summary>
		/// <param name="frame"></param>
		public static void SwitchToFrame(this IWebDriver WebDriver,IWebElement frame)
		{
			Reporter.LogInfo("Switch to specific frame");
			WebDriver.SwitchTo().Frame(frame);
		}

		/// <summary>
		/// Switch to default content from a frame
		/// </summary>
		public static void SwitchToDefaultContent(this IWebDriver WebDriver)
		{
			Reporter.LogInfo("Switch back to default content");
			WebDriver.SwitchTo().DefaultContent();
		}

	}
}
