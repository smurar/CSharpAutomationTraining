using System;
using CSharpAdvancedTraining.Course2.Extensions;
using CSharpAdvancedTraining.Course2.Helpers;
using CSharpAdvancedTraining.Course2.Pages;
using CSharpAdvancedTraining.Course33;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpAdvancedTraining.Course2
{
	public class HomePage
	{
		private IWebDriver WebDriver;

		//header
		[FindsBy(How = How.XPath, Using = "//ul/li/a[@href='homepage.html']")]
		private IWebElement HomepageLink;

		[FindsBy(How = How.XPath, Using = "//ul/li/a[@href='wikipage.html']")]
		private IWebElement WikipediaLink;

		[FindsBy(How = How.XPath, Using = "//ul[@id='navHeader']/a[@href='frame_parent.html']")]
		private IWebElement WindowsFrameLink;

		[FindsBy(How = How.XPath, Using = "//a/img[contains(@src,'upload.wikimedia')]")]
		private IWebElement Image;

		[FindsBy(How = How.XPath, Using = "//h1")]
		private IWebElement PageHeadingTitle;

		[FindsBy(How = How.Id, Using = "Login")]
		private IWebElement LoginButton;

		[FindsBy(How = How.XPath, Using = "//*[@id='email']/..")]
		private IWebElement EmailLabelText;

		[FindsBy(How = How.XPath, Using = "//*[@id='password']/..")]
		private IWebElement PasswordLabelText;

		[FindsBy(How = How.XPath, Using = "//*[@id='email']")]
		private IWebElement EmailInputField;

		[FindsBy(How = How.XPath, Using = "//*[@id='password']")]
		private IWebElement PasswordInputField;

		[FindsBy(How = How.Id, Using = "passwordErrorText")]
		private IWebElement PasswordErrorMessage;

		[FindsBy(How = How.Id, Using = "emailErrorText")]
		private IWebElement EmailErrorMessage;


		//footer
		[FindsBy(How = How.XPath, Using = "//footer//a[@href='homepage.html']")]
		private IWebElement FooterHomeLink;

		[FindsBy(How = How.XPath, Using = "//footer//a[@href='wikipage.html']")]
		private IWebElement FooterWikipageLink;

		[FindsBy(How = How.XPath, Using = "//footer//a[@href='#']")]
		private IWebElement FooterContactLink;

		[FindsBy(How = How.Id, Using = "firstname")]
		private IWebElement FirstNameInput;



		public HomePage(IWebDriver WebDriver)
		{
			this.WebDriver = WebDriver;
			PageFactory.InitElements(WebDriver, this);
			WebDriver.WaitElementToBeDisplayed(EmailInputField, "email textbox");
		}

		public HomePage CheckHomePageLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that homepage link is displayed", true, HomepageLink.Displayed);
			return this;
		}

		public HomePage CheckWikipediaLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that wikipedia link is displayed", true, WikipediaLink.Displayed);
			return this;
		}

		public HomePage CheckFooterContactLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer contact link is displayed", true, FooterContactLink.Displayed);
			return this;
		}

		public HomePage CheckFooterHomeLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer home link is displayed", true, FooterHomeLink.Displayed);
			return this;
		}

		public HomePage CheckFooterWikipageLinkIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that footer wikipage link is displayed", true, FooterWikipageLink.Displayed);
			return this;
		}

		public HomePage CheckImageIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check that image is displayed", true, Image.Displayed);
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
			Verifier.AssertThatAreEqual("Check page heading title", expectedTitle, PageHeadingTitle.Text);
			return this;
		}

		public HomePage CheckDefaultEmailLabelText(string expectedText)
		{
			Verifier.AssertThatContains("Check default email label text", expectedText, EmailLabelText.Text);
			return this;
		}

		public HomePage CheckDefaultPasswordLabelText(string expectedText)
		{
			Verifier.AssertThatContains("Check default password label text", expectedText, PasswordLabelText.Text);
			return this;
		}

		public HomePage CheckEmailFieldIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check email login field is displayed", true, EmailInputField.Displayed);
			return this;
		}

		public HomePage CheckPasswordFieldIsDisplayed()
		{
			Verifier.AssertThatAreEqual("Check password login field is displayed", true, PasswordInputField.Displayed);
			return this;
		}

		public HomePage CheckPasswordErrorMesssage(string expectedMessage)
		{
			Verifier.AssertThatAreEqual("Check password error message is: '" + expectedMessage + "'", expectedMessage, PasswordErrorMessage.Text);
			return this;
		}

		public HomePage CheckEmailErrorMesssage(string expectedMessage)
		{
			Verifier.AssertThatAreEqual("Check email error message is: '" + expectedMessage + "'", expectedMessage, EmailErrorMessage.Text);
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

		public FramePage ClickWindowAndFrameLink()
		{
			WindowsFrameLink.Click("window_frame link");
			return new FramePage(WebDriver);
		}

		public string GetParentWindow()
		{
			var currentWindow = WebDriver.GetCurrentWindow();
			Reporter.LogInfo("Current window is: " + currentWindow);
			return currentWindow;
		}

		public T ClickLogin<T>()
		{
			LoginButton.Click("login button");
			return (T)Activator.CreateInstance(typeof(T), new object[1] { WebDriver });

		}
	}
}
