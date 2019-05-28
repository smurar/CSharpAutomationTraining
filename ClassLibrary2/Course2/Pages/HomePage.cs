using ClassLibrary2.Course2.Extensions;
using ClassLibrary2.Course2.Helpers;
using ClassLibrary2.Course2.Pages;
using OpenQA.Selenium;

namespace ClassLibrary2.Course2
{
	public class HomePage
	{
		private IWebDriver WebDriver;
		private WaitConditions wait;

		//header
		private IWebElement HomepageLink { get { return WebDriver.FindElement(By.XPath("//ul/li/a[@href='homepage.html']")); } }
		private IWebElement WikipediaLink { get { return WebDriver.FindElement(By.XPath("//ul/li/a[@href='wikipage.html']")); } }
		private IWebElement Image { get { return WebDriver.FindElement(By.XPath("//a/img[contains(@src,'upload.wikimedia')]")); } }
		private IWebElement PageHeadingTitle { get { return WebDriver.FindElement(By.XPath("//h1")); } }
		private IWebElement LoginButton { get { return WebDriver.FindElement(By.Id("Login")); } }
		private IWebElement EmailLabelText { get { return WebDriver.FindElement(By.XPath("//*[@id='email']/..")); } }
		private IWebElement PasswordLabelText { get { return WebDriver.FindElement(By.XPath("//*[@id='password']/..")); } }
		private IWebElement EmailInputField { get { return WebDriver.FindElement(By.XPath("//*[@id='email']")); } }
		private IWebElement PasswordInputField { get { return WebDriver.FindElement(By.XPath("//*[@id='password']")); } }
		private IWebElement PasswordErrorMessage { get { return WebDriver.FindElement(By.Id("passwordErrorText")); } }
		private IWebElement EmailErrorMessage { get { return WebDriver.FindElement(By.Id("emailErrorText")); } }
		//footer
		private IWebElement FooterHomeLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='homepage.html']")); } }
		private IWebElement FooterWikipageLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='wikipage.html']")); } }
		private IWebElement FooterContactLink { get { return WebDriver.FindElement(By.XPath("//footer//a[@href='#']")); } }


		//or
		//private IWebElement Email_ExpressionBodiedMember =>WebDriver.FindElement(By.Id("Email"));


		public HomePage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			wait = new WaitConditions(WebDriver);
			wait.WaitElementToBeDisplayed(EmailInputField, "email textbox", 5);
		}

		public HomePage CheckHomePageLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that homepage link is displayed", true, HomepageLink.Displayed);
			return this;
		}

		public HomePage CheckWikipediaLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that wikipedia link is displayed", true, WikipediaLink.Displayed);
			return this;
		}

		public HomePage CheckFooterContactLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer contact link is displayed", true, FooterContactLink.Displayed);
			return this;
		}

		public HomePage CheckFooterHomeLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer home link is displayed", true, FooterHomeLink.Displayed);
			return this;
		}

		public HomePage CheckFooterWikipageLinkIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that footer wikipage link is displayed", true, FooterWikipageLink.Displayed);
			return this;
		}

		public HomePage CheckImageIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check that image is displayed", true, Image.Displayed);
			return this;
		}

		public HomePage FillInEmail(string email)
		{
			EmailInputField.SendKeys(email, "email textbox");
			return this;
		}

		public HomePage FillInPassword(string password)
		{
			PasswordInputField.SendKeys(password, "password textbox");
			return this;
		}

		public HomePage CheckPageHeadingTitle(string expectedTitle)
		{
			AssertExtensions.AssertThatAreEqual("Check page heading title", expectedTitle, PageHeadingTitle.Text);
			return this;
		}

		public HomePage CheckDefaultEmailLabelText(string expectedText)
		{
			AssertExtensions.AssertThatContains("Check default email label text", expectedText, EmailLabelText.Text);
			return this;
		}

		public HomePage CheckDefaultPasswordLabelText(string expectedText)
		{
			AssertExtensions.AssertThatContains("Check default password label text", expectedText, PasswordLabelText.Text);
			return this;
		}

		public HomePage CheckEmailFieldIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check email login field is displayed", true, EmailInputField.Displayed);
			return this;
		}

		public HomePage CheckPasswordFieldIsDisplayed()
		{
			AssertExtensions.AssertThatAreEqual("Check password login field is displayed", true, PasswordInputField.Displayed);
			return this;
		}

		public HomePage CheckPasswordErrorMesssage(string expectedMessage)
		{
			AssertExtensions.AssertThatAreEqual("Check password error message is: '" + expectedMessage + "'", expectedMessage, PasswordErrorMessage.Text);
			return this;
		}

		public HomePage CheckEmailErrorMesssage(string expectedMessage)
		{
			AssertExtensions.AssertThatAreEqual("Check email error message is: '" + expectedMessage + "'", expectedMessage, EmailErrorMessage.Text);
			return this;
		}

		public DashboardPage ClickLoginButton()
		{
			LoginButton.Click("login button");
			return new DashboardPage(WebDriver);
		}

		public HomePage ClickLoginButtonWithError()
		{
			LoginButton.Click("login button");
			return this;
		}

		public DashboardPage LoginWithSuccess(string email, string password)
		{
			FillInEmail(email);
			FillInPassword(password);
			ClickLoginButton();
			return new DashboardPage(WebDriver);
		}
	}
}
