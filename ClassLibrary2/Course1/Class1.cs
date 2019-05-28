using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Course1
{
	public class MyFirstTest
	{

		public IWebDriver driver;

		[SetUp]
		public void BeforeTest()
		{
			driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
			driver.Url = "file:///C:/Users/lgrecu/Desktop/Pages/homepage.html";
			driver.Manage().Window.Maximize();
		}

		//[Test]
		public void FirstSeleniumTest()
		{
			Assert.True(driver.Title.Equals("Home page"));
			driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
			driver.FindElement(By.Id("password")).SendKeys("111111");
			driver.FindElement(By.Id("Login")).Click();
			Assert.AreEqual(driver.Title.Contains("dashboardpage"), true);
			driver.Quit();
		}

		//[Test]
		public void HeaderLinksAndImageAreDisplayedTest()
		{
			//element paths
			var homepageLink = driver.FindElement(By.XPath("//ul/li/a[@href='homepage.html']"));
			var wikipediaLink = driver.FindElement(By.XPath("//ul/li/a[@href='wikipage.html']"));
			var image = driver.FindElement(By.XPath("//a/img[contains(@src,'upload.wikimedia')]"));
			///checks
			Assert.AreEqual(true, homepageLink.Displayed);
			Assert.AreEqual(true, wikipediaLink.Displayed);
			Assert.AreEqual(true, image.Displayed);
		}

		//[Test]
		public void PageTitleIsCorrectTest()
		{
			var pageTitle = driver.FindElement(By.XPath("//h1"));
			//Assert.AreEqual("HTML", pageTitle.Text);
		}

		[Test]
		public void PageHeadingTitleIsCorrectTest()
		{
			var pageHeadingTitle = driver.FindElement(By.XPath("//h1"));
			Assert.AreEqual("HTML", pageHeadingTitle.Text);
		}

		//[Test]
		public void DefaultEmailAndPasswordLabelChecksTest()
		{
			var emailLabelText = driver.FindElement(By.XPath("//*[@id='email']/.."));
			Assert.AreEqual(true, emailLabelText.Displayed);
			Assert.AreEqual(true, emailLabelText.Text.Contains("Email"));

			var passwordLabelText = driver.FindElement(By.XPath("//*[@id='password']/.."));
			Assert.AreEqual(true, passwordLabelText.Displayed);
			Assert.AreEqual(true, passwordLabelText.Text.Contains("Password"));
		}

		//[Test]
		public void LoginFieldsAreDisplayedTest()
		{
			var emailInputField = driver.FindElement(By.XPath("//*[@id='email']"));
			var passwordInputField = driver.FindElement(By.XPath("//*[@id='password']"));
			Assert.AreEqual(true, emailInputField.Displayed);
			Assert.AreEqual(true, passwordInputField.Displayed);
		}

		//[Test]
		public void EmailAddressErrorMessageTest()
		{
			var emailInputField = driver.FindElement(By.XPath("//*[@id='email']"));
			var loginButton = driver.FindElement(By.Id("Login"));
			loginButton.Click();
			var emailErrorMessage = driver.FindElement(By.Id("emailErrorText"));
			Assert.AreEqual("Email address can't be null", emailErrorMessage.Text);
		}

		//[Test]
		public void EmailAddressNotValidTest()
		{
			var emailInputField = driver.FindElement(By.XPath("//*[@id='email']"));
			var loginButton = driver.FindElement(By.Id("Login"));
			emailInputField.SendKeys("admin.domain.org");
			loginButton.Click();
			var emailErrorMessage = driver.FindElement(By.Id("emailErrorText"));
			Assert.AreEqual("Email address format is not valid", emailErrorMessage.Text);
		}

		//[Test]
		public void EmailAddressOrPasswordNotValidTest()
		{
			var emailInputField = driver.FindElement(By.XPath("//*[@id='email']"));
			var passwordInputField = driver.FindElement(By.XPath("//*[@id='password']"));
			var loginButton = driver.FindElement(By.Id("Login"));
			emailInputField.SendKeys("admin.domain.org");
			passwordInputField.SendKeys("111111");
			loginButton.Click();
			var passwordErrorMessage = driver.FindElement(By.Id("passwordErrorText"));
			Assert.AreEqual("Invalid password/email", passwordErrorMessage.Text);
		}

		//[Test]
		public void LoginSuccessfulTest()
		{
			var emailInputField = driver.FindElement(By.XPath("//*[@id='email']"));
			var passwordInputField = driver.FindElement(By.XPath("//*[@id='password']"));
			var loginButton = driver.FindElement(By.Id("Login"));
			emailInputField.SendKeys("admin@domain.org");
			passwordInputField.SendKeys("111111");
			loginButton.Click();
			Thread.Sleep(3000);
			//new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(c => c.FindElement(By.Id("firstname")));
			var dashboardPageTitle = driver.FindElement(By.XPath("//h1"));
			Assert.AreEqual("Dashboard page", dashboardPageTitle.Text);
		}

		//[Test]
		public void NavigateToWikiPageTest()
		{
			LoginSuccessfulTest();
			var wikiPageLink = driver.FindElement(By.XPath("//ul[@id='navHeader']//a[@href='wikipage.html']"));
			wikiPageLink.Click();
			var landingPageTitle = driver.FindElement(By.XPath("//h1"));
			Assert.AreEqual("WikiPage", landingPageTitle.Text);
		}

		//[Test]
		public void FooterLinksAreDisplayedTest()
		{
			var homeLink = driver.FindElement(By.XPath("//footer//a[@href='homepage.html']"));
			var wikiPageLink = driver.FindElement(By.XPath("//footer//a[@href='wikipage.html']"));
			var contactLink = driver.FindElement(By.XPath("//footer//a[@href='#']"));
			Assert.AreEqual(true, homeLink.Displayed);
			Assert.AreEqual(true, wikiPageLink.Displayed);
			Assert.AreEqual(true, contactLink.Displayed);
		}

		//[Test]
		public void DashboardHeaderLinksAndImageTest()
		{
			LoginSuccessfulTest();
			var homeLink = driver.FindElement(By.XPath("//header//a[@href='homepage.html']"));
			var wikiPageLink = driver.FindElement(By.XPath("//header//a[@href='wikipage.html']"));
			var image = driver.FindElement(By.XPath("//a/img[contains(@src,'upload.wikimedia')]"));
			Assert.AreEqual(true, homeLink.Displayed);
			Assert.AreEqual(true, wikiPageLink.Displayed);
			Assert.AreEqual(true, image.Displayed);
		}

	//	[Test]
		public void DashboardPageTitleIsCorrectTest()
		{
			LoginSuccessfulTest();
			var pageTitle = driver.FindElement(By.XPath("//p[contains(text(),'Welcome')]"));
			Assert.AreEqual("Welcome to dashboard page", pageTitle.Text);
		}

		//[Test]
		public void DasboardPageHeadingTitleIsCorrectTest()
		{
			LoginSuccessfulTest();
		}

	//	[Test]
		public void LogoutTest()
		{
			LoginSuccessfulTest();
			Thread.Sleep(3000);
			var pageTitle = driver.FindElement(By.XPath("//p[contains(text(),'Welcome')]"));
			Assert.AreEqual("Welcome to dashboard page", pageTitle.Text);
			var logoutButton = driver.FindElement(By.Id("Logout"));
			logoutButton.Click();
			var loginButton = driver.FindElement(By.Id("Login"));
			Assert.AreEqual(true, loginButton.Displayed);
		}

	//	[Test]
		public void DashboardFooterLinksTest()
		{
			LoginSuccessfulTest();
			var homeLink = driver.FindElement(By.XPath("//footer//a[@href='homepage.html']"));
			var wikiPageLink = driver.FindElement(By.XPath("//footer//a[@href='wikipage.html']"));
			var contactLink = driver.FindElement(By.XPath("//footer//a[@href='#']"));
			Assert.AreEqual(true, homeLink.Displayed);
			Assert.AreEqual(true, wikiPageLink.Displayed);
			Assert.AreEqual(true, contactLink.Displayed);
		}

		//[Test]
		public void EditUserInfoTest()
		{
			LoginSuccessfulTest();
			new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(c => c.FindElement(By.Id("firstname")));
			var firstNameInput = driver.FindElement(By.Id("firstname"));
			var lastNameInput = driver.FindElement(By.XPath("//input[2]"));
			var maleRadioBox = driver.FindElement(By.XPath("//input[@value='male']"));
			var femaleRadioBox = driver.FindElement(By.XPath("//input[@value='female']"));
			var birthdayInput = driver.FindElement(By.XPath("//input[@name='bday']"));
			var bikeCheckbox = driver.FindElement(By.XPath("//input[@value='Bike']"));
			var carCheckbox = driver.FindElement(By.XPath("//input[@value='Car']"));
			firstNameInput.Clear();
			firstNameInput.SendKeys("TestUser11");
			lastNameInput.Clear();
			lastNameInput.SendKeys("TestUser22");
			if (string.IsNullOrEmpty(maleRadioBox.GetAttribute("checked")))
			{
				maleRadioBox.Click();
			}
			else
			{
				femaleRadioBox.Click();
			}
			var saveButton = driver.FindElement(By.Id("SaveDetails"));
			saveButton.Click();
			Thread.Sleep(1000);
			var detailsSavedMessage = driver.FindElement(By.Id("detailsSavedMessage"));
			Assert.AreEqual("Details saved", detailsSavedMessage.Text);
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}
	}
}