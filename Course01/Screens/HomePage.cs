using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Course02
{
    public class HomePage
    {
        private IWebDriver WebDriver;
        private IWebElement Email { get { return WebDriver.FindElement(By.Id("email")); } }

        private IWebElement Password { get { return WebDriver.FindElement(By.Id("password")); } }

        private IWebElement Image { get { return WebDriver.FindElement(By.XPath("//a/img")); } }

        private IWebElement Header { get { return WebDriver.FindElement(By.XPath("//ul[@id='navHeader']")); } }

        private IWebElement H1Title { get { return WebDriver.FindElement(By.XPath("//h1[contains(text(),'HTML')]")); } }

        private IWebElement DefaultEmailText { get { return WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")); } }

        private IWebElement DefaultPasswordText { get { return WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default password: 111111')]")); } }

        private IWebElement LoginButton { get { return WebDriver.FindElement(By.Id("Login")); } }

        public HomePage(IWebDriver WebDriver)
        { this.WebDriver = WebDriver; }


        public DashBoardPage LoginWithValidCredentials()
        {
            SendKeysToField(Email, "admin@domain.org", "Email field");
            SendKeysToField(Password, "111111", "Password field");
            ClickElement(LoginButton, "Login button");
            return new DashBoardPage(WebDriver);
        }

        public HomePage SendKeysToField(IWebElement element, string textToWrite, string elementName)
        {
            Reporter.LogInfo("Write text '" + textToWrite + "' to elemet: " + elementName);
            element.SendKeys(textToWrite);
            return this;
        }
        public HomePage VerifyEmailErrorMessage()
        {
            FillInEmail("Hasiubogdan2.gmail.com");
            ClickElement(LoginButton, "Login Button");
            CheckElementIsDisplayed(WebDriver.FindElement(By.Id("emailErrorText")));
            CheckElementContainsText(WebDriver.FindElement(By.Id("emailErrorText")), "Email address format is not valid");
            return this;
        }

        public HomePage VerifyPasswordErrorMessage()
        {
            FillInPassword("aaaaaaaa");
            ClickElement(LoginButton, "Login Button");
            CheckElementIsDisplayed(WebDriver.FindElement(By.Id("passwordErrorText")));
            CheckElementContainsText(WebDriver.FindElement(By.Id("passwordErrorText")), "Invalid password/email");
            return this;
        }
        public HomePage ClickElement(IWebElement element,string elementName)
        {
            Reporter.LogInfo("Click element: " + elementName);
            element.Click();
            return this;
        }

        
        public HomePage CheckElementIsDisplayed ( IWebElement element)
        {
            Assert.AreEqual(true, element.Displayed);
            return this;
        }

        public HomePage CheckElementContainsText( IWebElement element, string TextContained)
        {
            Assert.IsTrue(element.Text.Contains(TextContained));
            return this;
        }
        public HomePage CheckPageTitle(string expectedTitle)
        {
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));
            return this;
        }

        public HomePage CheckImageDisplayed()
        {
            Assert.AreEqual(true, Image.Displayed);
            return this;
        }

        public HomePage VerifyHomePageTitleIsCorrect()
        {
            Assert.True(WebDriver.Title.Equals("Home page"));
            return this;
        }

        public HomePage CheckHeaderDisplayed()
        {
            Assert.AreEqual(true, Header.Displayed);
            return this;
        }

        public HomePage CheckH1Title()
        {
            Assert.IsTrue(H1Title.Text.Contains("HTML"));
            return this;
        }

        public HomePage FillInEmail ( string email)
        {
            Email.SendKeys(email);
            Reporter.LogInfo("Keys introduced");
            return this;
        }

        public HomePage FillInPassword ( string password)
        {
            Password.SendKeys(password);
            Reporter.LogInfo("Keys introduced");
            return this;
        }

        
    }
}
