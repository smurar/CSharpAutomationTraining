using System.Collections.Generic;
using System.Linq;
using ClassLibrary2.Course2;
using OpenQA.Selenium;

namespace ClassLibrary2.Course33
{
	public class WindowsAndFramesHelper
	{

		private IWebDriver WebDriver;

		public WindowsAndFramesHelper(IWebDriver driver)
		{
			WebDriver = driver;
		}

		/// <summary>
		/// Switch to window by position
		/// </summary>
		/// <param name="position"></param>

		public void SwitchToWindowByPosition(int position)
		{
			IReadOnlyCollection<string> Windows = WebDriver.WindowHandles;
			Reporter.LogInfo("There are " + Windows.Count + " windows. Switch to window number: " + position);
			WebDriver.SwitchTo().Window(Windows.ElementAt(position));
		}

		/// <summary>
		/// Switch to initial window by name
		/// </summary>
		/// <param name="intialWindow"></param> 
		public void SwitchToInitialWindow(string intialWindow)
		{
			Reporter.LogInfo("Switch to window with name: " + intialWindow);
			WebDriver.SwitchTo().Window(intialWindow);
		}

		/// <summary>
		/// Get the name of the current window
		/// </summary>
		/// <returns></returns>
		public string GetCurrentWindow()
		{
			Reporter.LogInfo("Get current window");
			return WebDriver.CurrentWindowHandle;
		}

		/// <summary>
		/// Close the current window
		/// </summary>
		public void CloseCurrentWindow()
		{
			Reporter.LogInfo("Close current window");
			WebDriver.Close();
		}

		/// <summary>
		/// Switch to a specific webelement frame
		/// </summary>
		/// <param name="frame"></param>
		public void SwitchToFrame(IWebElement frame)
		{
			Reporter.LogInfo("Switch to specific frame");
			WebDriver.SwitchTo().Frame(frame);
		}

		/// <summary>
		/// Switch to default content from a frame
		/// </summary>
		public void SwitchToDefaultContent()
		{
			Reporter.LogInfo("Switch back to default content");
			WebDriver.SwitchTo().DefaultContent();
		}

	}
}
