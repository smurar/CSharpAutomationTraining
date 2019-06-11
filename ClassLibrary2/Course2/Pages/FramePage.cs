using System.Threading;
using ClassLibrary2.Course2.Extensions;
using ClassLibrary2.Course2.Helpers;
using ClassLibrary2.Course33;
using OpenQA.Selenium;

namespace ClassLibrary2.Course2.Pages
{
	public class FramePage
	{
		private IWebDriver WebDriver;
		private WaitConditions wait;
		public WindowsAndFramesHelper windowsAndFrames;

		private IWebElement FrameA { get { return WebDriver.FindElement(By.XPath("//*[@name='frame_a']")); } }
		private IWebElement FrameB { get { return WebDriver.FindElement(By.XPath("//*[@src='frame_b.html']")); } }
		private IWebElement FrameTextArea { get { return WebDriver.FindElement(By.XPath("//*[@id='htmlVersion']")); } }

		public FramePage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			wait = new WaitConditions(WebDriver);
			wait.WaitWindowsNumberToBeEqualWith(2, 5);
			windowsAndFrames = new WindowsAndFramesHelper(WebDriver);
		}

		public FramePage CheckFrameParentURL(string partialURL)
		{
			windowsAndFrames.SwitchToWindowByPosition(1);
			AssertExtensions.AssertThatAreEqual("Check frame parent page URL contains: " + partialURL, true, WebDriver.Url.Contains(partialURL));
			return this;
		}

		public FramePage CloseFramePageAndSwitchToParentWindow(string parentWindow)
		{
			windowsAndFrames.CloseCurrentWindow();
			windowsAndFrames.SwitchToInitialWindow(parentWindow);
			return this;
		}

		public HomePage LoadHomePage()
		{
			return new HomePage(WebDriver);
		}

		public FramePage SwitchToFrameA() {
			windowsAndFrames.SwitchToFrame(FrameA);
			return this;
		}

		public FramePage SwitchToFrameB()
		{
			windowsAndFrames.SwitchToFrame(FrameB);
			return this;
		}

		public FramePage FillInFrameTextArea(string text) {
			FrameTextArea.SendKeys(text, "frame input");
			windowsAndFrames.SwitchToDefaultContent();
			return this;
		}

	}
}
