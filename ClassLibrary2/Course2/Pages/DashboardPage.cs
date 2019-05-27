using ClassLibrary2.Course2.Extensions;
using ClassLibrary2.Course2.Helpers;
using OpenQA.Selenium;

namespace ClassLibrary2.Course2.Pages
{
	public class DashboardPage
	{

		private IWebDriver WebDriver;
		private WaitConditions wait;

		private IWebElement DashboardPageTitle { get { return WebDriver.FindElement(By.XPath("//h1")); } }
		private IWebElement FirstNameInput { get { return WebDriver.FindElement(By.Id("firstname")); } }
		private IWebElement HomeLink { get { return WebDriver.FindElement(By.XPath("//header//a[@href='homepage.html']")); } }
		private IWebElement WikiPageLink { get { return WebDriver.FindElement(By.XPath("//header//a[@href='wikipage.html']")); } }
		private IWebElement Image { get { return WebDriver.FindElement(By.XPath("//a/img[contains(@src,'upload.wikimedia')]")); } }
		private IWebElement LogoutButton { get { return WebDriver.FindElement(By.Id("Logout")); } }
		//footer links
		private IWebElement FooterWikiPageLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='wikipage.html']")); } }
		private IWebElement FooterHomeLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='homepage.html']")); } }
		private IWebElement FooterContactLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='#']")); } }



		public DashboardPage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			wait = new WaitConditions(WebDriver);
			wait.WaitElementToBeDisplayed(FirstNameInput, "first name textbox", 5);
		}

		public DashboardPage CheckPageTitle(string expectedTitle)
		{
			AssertExtensions.AssertThatAreEqual("Check page title is: '" + expectedTitle + "'", expectedTitle, DashboardPageTitle.Text);
			return this;
		}

		public WikiPage ClickWikiPageLink()
		{

			WebElementExtensions.Click(WikiPageLink, "wikipage link");
			return new WikiPage(WebDriver);
		}

		public DashboardPage CheckHomeLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that home link is displayed", true, HomeLink.Displayed);
			return this;
		}

		public DashboardPage CheckWikipageLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that wikipage link is displayed", true, WikiPageLink.Displayed);
			return this;
		}

		public DashboardPage CheckImageIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that image is displayed", true, Image.Displayed);
			return this;
		}

		public HomePage ClickLogoutButton()
		{
			WebElementExtensions.Click(LogoutButton, "logout button");
			return new HomePage(WebDriver);
		}

		public DashboardPage CheckFooterContactLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer contact link is displayed", true, FooterContactLink.Displayed);
			return this;
		}

		public DashboardPage CheckFooterHomeLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer home link is displayed", true, FooterHomeLink.Displayed);
			return this;
		}

		public DashboardPage CheckFooterWikipageLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer wikipage link is displayed", true, FooterWikiPageLink.Displayed);
			return this;
		}

	}
}
