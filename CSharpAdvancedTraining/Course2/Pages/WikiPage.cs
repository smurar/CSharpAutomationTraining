using CSharpAdvancedTraining.Course2.Extensions;
using CSharpAdvancedTraining.Course2.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpAdvancedTraining.Course2.Pages
{
	public class WikiPage
	{

		[FindsBy(How = How.XPath, Using = "//h1")]
		private IWebElement PageHeadingTitle;

		[FindsBy(How = How.XPath, Using = "//form//select[@id='htmlversions']")]
		private IWebElement HtmlVersionsDropdown;

		private IWebDriver WebDriver;

		public WikiPage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			PageFactory.InitElements(WebDriver, this);
			WebDriver.WaitElementToBeDisplayed(HtmlVersionsDropdown, "html versions dropdown");
		}

		public WikiPage CheckLandingPageTitle(string expectedTitle)
		{
			Verifier.AssertThatAreEqual("Check page title is: '" + expectedTitle + "'", expectedTitle, PageHeadingTitle.Text);
			return this;
		}
	}
}
