using ClassLibrary2.Course2.Extensions;
using ClassLibrary2.Course2.Helpers;
using OpenQA.Selenium;

namespace ClassLibrary2.Course2.Pages
{
	public class WikiPage
	{
		private IWebElement PageHeadingTitle { get { return WebDriver.FindElement(By.XPath("//h1")); } }
		private IWebElement HtmlVersionsDropdown { get { return WebDriver.FindElement(By.XPath("//form//select[@id='htmlversions']")); } }

		private IWebDriver WebDriver;
		private WaitConditions wait;

		public WikiPage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			wait = new WaitConditions(WebDriver);
			wait.WaitElementToBeDisplayed(HtmlVersionsDropdown, "html versions dropdown", 5);
		}

		public WikiPage CheckLandingPageTitle(string expectedTitle)
		{
			AssertExtensions.AssertThatAreEqual("Check page title is: '" + expectedTitle + "'", expectedTitle, PageHeadingTitle.Text);
			return this;
		}
	}
}
