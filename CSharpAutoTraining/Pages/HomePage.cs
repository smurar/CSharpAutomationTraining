
using CSharpAutoTraining.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CSharpAutoTraining
{
    public class HomePage :  BaseTest
    {
        private IWebDriver WebDriver;
        private IWebElement HeaderImg => WebDriver.FindElement(By.XPath("//*[@id='header']/a/img"));
        private IWebElement HeaderHomePageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='Home']"));
        private IWebElement HeaderWikiPageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']"));
        private IWebElement HeadingTitle => WebDriver.FindElement(By.XPath("//html/body/h1"));
        private IWebElement DefaultEmail => WebDriver.FindElement(By.XPath("/html/body/b/p[1]"));
        private IWebElement DefaultPassword => WebDriver.FindElement(By.XPath("/html/body/b/p[2]"));
        private IWebElement EmailField => WebDriver.FindElement(By.Id("email"));
        private IWebElement PasswordField => WebDriver.FindElement(By.Id("password"));
        private IWebElement EmailLoginError => WebDriver.FindElement(By.Id("emailErrorText"));
        private IWebElement PasswordLoginError => WebDriver.FindElement(By.Id("passwordErrorText"));
        private IWebElement LoginButton => WebDriver.FindElement(By.Id("Login"));
        private IWebElement FooterLinkHome => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[1]/a"));
        private IWebElement FooterLinkWikiPage => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[2]/a"));
        private IWebElement FooterLinkContact => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[3]/a"));

        public HomePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public HomePage VerifyPageTitle(string expected)
        {
            Assert.IsTrue(condition: object.Equals(WebDriver.Title, expected));
            return this;
        }

        public HomePage VerifyHeadingH1(string expected)
        {
            Assert.AreEqual(expected, HeadingTitle.Text);
            return this;
        }

        public HomePage DefaultEmailFieldValidation(string defaulEmail)
        {
            Assert.IsTrue(DefaultEmail.Text.Contains(defaulEmail));
            return this;
        }
        public HomePage DefaultPasswordFieldValidation(string defaulPassword)
        {
            Assert.IsTrue(DefaultPassword.Text.Contains(defaulPassword));
            return this;
        }

        public HomePage CompleteUserEmailField(string email)
        {
            EmailField.Clear();
            EmailField.SendKeys(email);
            return this;
        }

        public HomePage CompleteUserPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            return this;
        }

        public DashboardPage SuccessfulLogin(string email, string password)
        {
            CompleteUserEmailField(email);
            CompleteUserPassword(password);
            LoginButton.Click();

            return new DashboardPage(WebDriver);
        }

        public HomePage UnsuccessfulLogin(string email, string password)
        {
            CompleteUserEmailField(email);
            CompleteUserPassword(password);
            LoginButton.Click();

            return this;
        }

        public HomePage GoToHomePageByClickOnLink(bool headerHomeLink = true)
        {
            if (headerHomeLink)
            {
                HeaderHomePageLink.Click();
            }
            else
            {
                FooterLinkHome.Click();
            }
            return this;
        }

        public WikiPage GoToWikiPageByClickOnLink(bool headerWikiLink = true)
        {
            if (headerWikiLink)
            {
                HeaderWikiPageLink.Click();
            }
            else
            {
                FooterLinkWikiPage.Click();
            }
            return new WikiPage(WebDriver);
        }

        public HomePage HeaderItemVisibilityVerification()
        {
            try
            {
                Assert.IsTrue(HeaderImg.Displayed);
                Assert.IsTrue(HeaderHomePageLink.Displayed);
                Assert.IsTrue(HeaderWikiPageLink.Displayed);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Header Element not found");
                Reporter.LogFail("Header Element not found");
            }
            return this;
        }

        public HomePage FooterItemVisibilityVerification()
        {
            try
            {
                Assert.IsTrue(FooterLinkHome.Displayed);
                Assert.IsTrue(FooterLinkWikiPage.Displayed);
                Assert.IsTrue(FooterLinkContact.Displayed);
            }
            catch (NoSuchElementException)
            {

                Reporter.LogFail("Header Element not found");
                throw;
            }
            return this;
        }

        public HomePage PageBodyItemVisibilityVerification()
        {
            try
            {
                Assert.IsTrue(EmailField.Displayed);
                Assert.IsTrue(PasswordField.Displayed);
                Assert.IsTrue(LoginButton.Displayed);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Element not found");
                Reporter.LogFail("Element not found");               
            }
            return this;
        }

        public HomePage EmailErrorValidation(string ErrorMsg)
        {
            Assert.AreEqual(ErrorMsg, EmailLoginError.Text);
            return this;
        }

        public HomePage PasswordErrorValidation(string ErrorMsg)
        {
            Assert.AreEqual(ErrorMsg, PasswordLoginError.Text);
            return this;
        }
    }
}
