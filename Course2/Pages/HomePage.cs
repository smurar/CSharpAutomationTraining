using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    public class HomePage
    {
        private IWebDriver WebDriver;
        private IWebElement HeaderImg => WebDriver.FindElement(By.XPath("//*[@id='header']/a/img"));
        private IWebElement HeaderHomePageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='Home']"));
        private IWebElement HeaderWikiPageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']"));
        private IWebElement HeadingTitle => WebDriver.FindElement(By.XPath("//html/body/h1"));
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
            if(headerHomeLink)
            {
                HeaderHomePageLink.Click();
            } else
            {
                FooterLinkHome.Click();
            }
            return this;
        }

        public WikiPage GoToWikiPaheByClickOnLink(bool headerWikiLink = true)
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

        public bool HeaderItemVisibilityVerification()            
        {
            if(HeaderImg.Displayed.Equals(false) || 
                HeaderHomePageLink.Displayed.Equals(false) ||
                HeaderWikiPageLink.Displayed.Equals(false))
            {
                Console.WriteLine("Header does not contain all necessary fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FooterItemVisibilityVerification()
        {
            if(FooterLinkHome.Displayed.Equals(false) ||
                FooterLinkWikiPage.Displayed.Equals(false) ||
                FooterLinkContact.Displayed.Equals(false))
            {
                Console.WriteLine("Footer does not contain all necessary fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool PageBodyItemVisibilityVerification()
        {
            if (HeadingTitle.Displayed.Equals(false) ||
                EmailField.Displayed.Equals(false) ||
                PasswordField.Displayed.Equals(false) ||
                LoginButton.Displayed.Equals(false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EmailErrorValidation(string ErrorMsg)
        {
            if (EmailLoginError.Text.Contains(ErrorMsg))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool PasswordErrorValidation(string ErrorMsg)
        {
            if (PasswordLoginError.Text.Contains(ErrorMsg))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
