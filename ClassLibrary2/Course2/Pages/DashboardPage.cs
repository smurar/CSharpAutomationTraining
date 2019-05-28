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
		private IWebElement LastNameInput { get { return WebDriver.FindElement(By.XPath("//input[2]")); } }
		private IWebElement MaleRadioBox { get { return WebDriver.FindElement(By.XPath("//input[@value='male']")); } }
		private IWebElement FemaleRadioBox { get { return WebDriver.FindElement(By.XPath("//input[@value='female']")); } }
		private IWebElement BirthdayInput { get { return WebDriver.FindElement(By.XPath("//input[@name='bday']")); } }
		private IWebElement BikeCheckbox { get { return WebDriver.FindElement(By.XPath("//input[@value='Bike']")); } }
		private IWebElement CarCheckbox { get { return WebDriver.FindElement(By.XPath("//input[@value='Car']")); } }
		private IWebElement SaveButton { get { return WebDriver.FindElement(By.Id("SaveDetails")); } }
		private IWebElement DetailsSavedMessage { get { return WebDriver.FindElement(By.Id("detailsSavedMessage")); } }


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
			WikiPageLink.Click("wikipage link");
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
			LogoutButton.Click("logout button");
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

		public DashboardPage FillInFirstNameInput(string firstName)
		{
			FirstNameInput.Clear();
			FirstNameInput.SendKeys(firstName, "First name textbox");
			return this;
		}

		public DashboardPage FillInLastNameInput(string lastName)
		{
			LastNameInput.Clear();
			LastNameInput.SendKeys(lastName, "Last name textbox");
			return this;
		}

		public DashboardPage ClickSaveButton()
		{
			SaveButton.Click("Save button");
			return this;
		}

		public DashboardPage CheckDetailsSavedMessage(string expectedMessage)
		{
			AssertExtensions.AssertThatAreEqual("Check details saved message is: '" + expectedMessage + "'", expectedMessage, DetailsSavedMessage.Text);
			return this;
		}

	}
}
