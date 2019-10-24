using CSharpAdvancedTraining.Course2.Extensions;
using CSharpAdvancedTraining.Course2.Helpers;
using CSharpAdvancedTraining.Course33;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpAdvancedTraining.Course2.Pages
{
	public class FramePage
	{
		private IWebDriver WebDriver;

		[FindsBy(How = How.XPath, Using = "//*[@name='frame_a']")]
		private IWebElement FrameA;

		[FindsBy(How = How.XPath, Using = "//*[@src='frame_b.html']")]
		private IWebElement FrameB;

		[FindsBy(How = How.XPath, Using = "//*[@id='htmlVersion']")]
		private IWebElement FrameTextArea;


		public FramePage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			PageFactory.InitElements(WebDriver, this);
			WebDriver.WaitWindowsNumberToBeEqualWith(2, 5);
		}

		public FramePage CheckFrameParentURL(string partialURL)
		{
			WebDriver.SwitchToWindowByPosition(1);
			Verifier.AssertThatAreEqual("Check frame parent page URL contains: " + partialURL, true, WebDriver.Url.Contains(partialURL));
			return this;
		}

		public FramePage CloseFramePageAndSwitchToParentWindow(string parentWindow)
		{
			WebDriver.CloseCurrentWindow();
			WebDriver.SwitchToInitialWindow(parentWindow);
			return this;
		}

		public HomePage LoadHomePage()
		{
			return new HomePage(WebDriver);
		}

		public FramePage SwitchToFrameA()
		{
			WebDriver.SwitchToFrame(FrameA);
			return this;
		}

		public FramePage SwitchToFrameB()
		{
			WebDriver.SwitchToFrame(FrameB);
			return this;
		}

		public FramePage FillInFrameTextArea(string text)
		{
			FrameTextArea.SendKeys(text, "frame input");
			WebDriver.SwitchToDefaultContent();
			return this;
		}

	}
}
