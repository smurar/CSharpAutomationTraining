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

        public HomePage(IWebDriver WebDriver)
        { this.WebDriver = WebDriver; }

        public HomePage CheckPageTitle(string expectedTitle)
        {
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));
            return this;
        }

        public HomePage FillInEmail ( string email)
        {
            Email.SendKeys(email);

            return this;
        }

        public HomePage FillInPassword ( string password)
        {
            Password.SendKeys(password);

            return this;
        }

        
    }
}
