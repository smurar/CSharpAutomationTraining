using CSharpAutoTraining.Course2.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2.PageObjects
{
    public class HomePage: BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement HeaderImage { get { return driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img")); } }
        //private IWebElement HeaderImage => driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img"));

        private ICollection<IWebElement> HeaderLinks { get { return driver.FindElements(By.XPath("//*[@id=\"navHeader\"]")); } }

        private IWebElement PageHeadingTitle { get { return driver.FindElement(By.CssSelector("body > h1")); } }
        
        private IWebElement DefaultEmail { get { return driver.FindElement(By.XPath("/html/body/b/p[1]")); } }

        private IWebElement DefaultPassword { get { return driver.FindElement(By.XPath("/html/body/b/p[2]")); } }

        private IWebElement EmailField { get { return driver.FindElement(By.XPath("//*[@id=\"email\"]")); } }

        private IWebElement PasswordField { get { return driver.FindElement(By.XPath("//*[@id=\"password\"]")); } }
        
        private IWebElement LoginButton { get { return driver.FindElement(By.Id("Login")); } }

        private IWebElement EmailErrorText { get { return driver.FindElement(By.Id("emailErrorText")); } }

        private ICollection<IWebElement> FooterLinks { get { return driver.FindElements(By.XPath("//*[@id=\"nav\"]")); } }

        public bool HeaderImageIsDisplayed()
        {
            return HeaderImage.Displayed;
        }

        public bool HeaderLinksAreAllDisplayed()
        {
            foreach (IWebElement headerLink in HeaderLinks) {
                if (!headerLink.Displayed) {
                    return false;
                }
            }

            return true;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingTitle()
        {
            return PageHeadingTitle.Text;
        }

        public string GetDefaultEmail()
        {
            return DefaultEmail.Text;
        }

        public string GetDefaultPassword()
        {
            return DefaultPassword.Text;
        }

        public bool AuthenticationFieldsDisplayed()
        {
            return EmailField.Displayed && PasswordField.Displayed;
        }

        public BasePage Authenticate(string email, string password)
        {
            EmailField.Clear();
            PasswordField.Clear();

            if (email != null)
            {
                EmailField.SendKeys(email);
            }
            
            if (password != null)
            {
                PasswordField.SendKeys(password);
            }

            Reporter.LogInfo("Click login button.");
            LoginButton.Click();

            return this;
        }

        public string GetEmailErrorMessage()
        {
            return EmailErrorText.Text;
        }

        public bool FooterLinksAreDisplayed()
        {
            foreach (IWebElement footerLink in FooterLinks)
            {
                if (!footerLink.Displayed)
                {
                    return false;
                }
            }

            return true;
        }      
    }
}
