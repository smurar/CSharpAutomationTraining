using Course2.Reports;
using Course2.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.PageObjects
{
    public class HomePage
    {
        private IWebDriver WebDriver;
        private IWebElement HeaderImage => WebDriver.FindElement(By.XPath("//div[@id='header']//img"));
        private IWebElement HomeLink => WebDriver.FindElement(By.XPath("//ul[@id='navHeader']//a[1]"));
        private IWebElement WikiPageLink => WebDriver.FindElement(By.XPath("//ul[@id='navHeader']//a[2]"));
        private IWebElement HeadingTitle => WebDriver.FindElement(By.XPath("//h1"));
        private IWebElement DefaultEmail => WebDriver.FindElement(By.XPath("//b//p[contains(text() , 'Default email: admin@domain.org')]"));
        private IWebElement DefaultPassword => WebDriver.FindElement(By.XPath("//b//p[contains(text() , 'Default password: 111111')]"));
        private IWebElement Email => WebDriver.FindElement(By.Id("email"));
        private IWebElement Password => WebDriver.FindElement(By.Id("password"));
        private IWebElement EmailValidationText => WebDriver.FindElement(By.Id("emailErrorText"));
        private IWebElement LoginButton => WebDriver.FindElement(By.Id("Login"));
        private IWebElement PasswordValidationText => WebDriver.FindElement(By.Id("passwordErrorText"));




        public HomePage (IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public HomePage CheckPageTitle(string title)
        {
            Reporter.LogInfo("Check that the page title is: " + title);
            Assert.AreEqual(title, WebDriver.Title, "You are not on Home Page");
            return this;
        }

        public HomePage CheckHeaderImage()
        {
            Reporter.LogInfo("Check the header iamge");
            Assert.IsTrue(HeaderImage.Displayed, "The header image is not displayed");
            return this;
        }

        public HomePage CheckHomePageLink()
        {
            Reporter.LogInfo("Check that Home Page link is displayed");
            Assert.IsTrue(HomeLink.Displayed, "The Home Page link is not displayed");
            
            return this;
        }

        public HomePage CheckWikiPageLink()
        {
            Reporter.LogInfo("Check that Wiki Page link is displayed");
            Assert.IsTrue(WikiPageLink.Displayed, "The Wiki Page link is not displayed");
            return this;
        }

        public HomePage CheckHeadingTitle(string expectedHeadingTitle)
        {
            Reporter.LogInfo("Check that the Heading Title is: " + expectedHeadingTitle);
            Assert.AreEqual(expectedHeadingTitle, HeadingTitle.Text, "The heading title is not correct");
            return this;
        }

        public HomePage CheckDefaultEmail(string defaultEmailText)
        {
            Reporter.LogInfo("Check that the Default Email field is displayed");
            Assert.IsTrue(DefaultEmail.Displayed, "Default Email field is not displayed");
            Reporter.LogInfo("Check that the Default Email text is: " + defaultEmailText);
            Assert.AreEqual(defaultEmailText, DefaultEmail.Text,"Default Email text is not correct");
            return this;

        }

        public HomePage CheckDefaultPassword(string defaultPasswordText)
        {
            Reporter.LogInfo("Check that the Default Password field is displayed");
            Assert.IsTrue(DefaultPassword.Displayed, "Default Password field is not displayed");
            Reporter.LogInfo("Check that the Default Password text is: " + defaultPasswordText);
            Assert.AreEqual(defaultPasswordText, DefaultPassword.Text, "Default Password text is not correct");
            return this;

        }

        public HomePage CheckLoginFieldsAreDisplayed()
        {
            Reporter.LogInfo("Check that Email field is displayed");
            Assert.IsTrue(Email.Displayed, "The Email field is not displayed");
            Reporter.LogInfo("Check that Password field is displayed");
            Assert.IsTrue(Password.Displayed, "The Password field is not displayed");
            return this;
        }

        public HomePage CheckNullEmailValidationText(string nullEmailValidation)
        {
            LoginButton.Click("Login Button");
            Reporter.LogInfo("Check that the valadation message displayed for null email is: " + nullEmailValidation);
            Assert.AreEqual(nullEmailValidation, EmailValidationText.Text, "The null email validation message is not correct");
            return this;
        }

        public HomePage CheckFormatEmailValidationText(string formatEmailValidation)
        {
            Email.SendKeys("Test", "Email Field");
            LoginButton.Click("Login Button");
            Reporter.LogInfo("Check that the valadation message displayed for incorrect email is: " + formatEmailValidation);
            Assert.AreEqual(formatEmailValidation, EmailValidationText.Text, "The format email validation message is not correct");
            return this;
        }

        public HomePage CheckInvalidPasswordValidation(string passwordValidationMessage)
        {
            Email.SendKeys("Test@test.com", "Email Field");
            Password.SendKeys("test", "Password Field");
            LoginButton.Click("Login Button");
            Reporter.LogInfo("Check that the password validation message is: " + passwordValidationMessage);
            Assert.AreEqual(passwordValidationMessage, PasswordValidationText.Text, "The password validation message is not correct");
            return this;
        }

        public DashboardPage Login(string validEmail, string validPassword)
        {
            Email.SendKeys(validEmail, "Email Field");
            Password.SendKeys(validPassword, "Password Field");
            LoginButton.Click("Login Button");
            return new DashboardPage(WebDriver);
        }

        public WikiPage GoToWikiPage()
        {
            WikiPageLink.Click("Wiki Page Link");
            return new WikiPage(WebDriver);
        }
    }
}
