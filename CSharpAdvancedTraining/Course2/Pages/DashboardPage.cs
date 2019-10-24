using CSharpAdvancedTraining.Course2.Extensions;
using CSharpAdvancedTraining.Course2.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpAdvancedTraining.Course2.Pages
{
	public class DashboardPage
	{
		private IWebDriver WebDriver;

		[FindsBy(How = How.Id, Using = "loader")]
		private IWebElement LoadingSpinner;

		[FindsBy(How = How.Id, Using = "firstname")]
		private IWebElement FirstNameInput;

		[FindsBy(How = How.XPath, Using = "//h1")]
		private IWebElement DashboardPageTitle;

		[FindsBy(How = How.XPath, Using = "//header//a[@href='homepage.html']")]
		private IWebElement HomeLink;

		[FindsBy(How = How.XPath, Using = "//header//a[@href='wikipage.html']")]
		private IWebElement WikiPageLink;

		[FindsBy(How = How.XPath, Using = "//a/img[contains(@src,'upload.wikimedia')]")]
		private IWebElement Image;

		[FindsBy(How = How.Id, Using = "Logout")]
		private IWebElement LogoutButton;

		[FindsBy(How = How.XPath, Using = "//input[2]")]
		private IWebElement LastNameInput;

		[FindsBy(How = How.XPath, Using = "//input[@value='male']")]
		private IWebElement MaleRadioBox;

		[FindsBy(How = How.XPath, Using = "//input[@value='female']")]
		private IWebElement FemaleRadioBox;

		[FindsBy(How = How.XPath, Using = "//input[@name='bday']")]
		private IWebElement BirthdayInput;

		[FindsBy(How = How.XPath, Using = "//input[@value='Bike']")]
		private IWebElement BikeCheckbox;

		[FindsBy(How = How.XPath, Using = "//input[@value='Car']")]
		private IWebElement CarCheckbox;

		[FindsBy(How = How.Id, Using = "SaveDetails")]
		private IWebElement SaveButton;

		[FindsBy(How = How.Id, Using = "detailsSavedMessage")]
		private IWebElement DetailsSavedMessage;



		//footer links
		[FindsBy(How = How.XPath, Using = "//footer//a[@href='wikipage.html']")]
		private IWebElement FooterWikiPageLink;

		[FindsBy(How = How.XPath, Using = "//footer//a[@href='homepage.html']")]
		private IWebElement FooterHomeLink;

		[FindsBy(How = How.XPath, Using = "//footer//a[@href='#']")]
		private IWebElement FooterContactLink;

		private IWebElement Loader => WebDriver.FindElement(By.Id("loader"));


		public DashboardPage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			PageFactory.InitElements(WebDriver, this);
			if (WebDriver.TryFindElement(By.Id("loader"), "spinner loader"))
			{
				WebDriver.WaitForElementNotToBeDisplayed(Loader, "loader spinner");
			}
			//or
			//WebDriver.WaitElementToBeDisplayed(FirstNameInput, "first name input");
		}


		public DashboardPage CheckPageTitle(string expectedTitle)
		{
			Verifier.AssertThatAreEqual("Check page title is: '" + expectedTitle + "'", expectedTitle, DashboardPageTitle.Text);
			return this;
		}

		public WikiPage ClickWikiPageLink()
		{
			WikiPageLink.Click("wikipage link");
			return new WikiPage(WebDriver);
		}

		public DashboardPage CheckHomeLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that home link is displayed", true, HomeLink.Displayed);
			return this;
		}

		public DashboardPage CheckWikipageLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that wikipage link is displayed", true, WikiPageLink.Displayed);
			return this;
		}

		public DashboardPage CheckImageIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that image is displayed", true, Image.Displayed);
			return this;
		}

		public HomePage ClickLogoutButton()
		{
			LogoutButton.Click("logout button");
			return new HomePage(WebDriver);
		}

		public DashboardPage CheckFooterContactLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer contact link is displayed", true, FooterContactLink.Displayed);
			return this;
		}

		public DashboardPage CheckFooterHomeLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer home link is displayed", true, FooterHomeLink.Displayed);
			return this;
		}

		public DashboardPage CheckFooterWikipageLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer wikipage link is displayed", true, FooterWikiPageLink.Displayed);
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
			Verifier.AssertThatAreEqual("Check details saved message is: '" + expectedMessage + "'", expectedMessage, DetailsSavedMessage.Text);
			return this;
		}

	}
}
