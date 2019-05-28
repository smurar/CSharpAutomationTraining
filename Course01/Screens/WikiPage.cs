using Course01.Course02;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Screens
{
    public class WikiPage 
    {
        private IWebDriver WebDriver;

        Waiters wait;
        public WikiPage(IWebDriver WebDriver)
        {
            wait = new Waiters(WebDriver);
            this.WebDriver = WebDriver;
        }
        public WikiPage CheckPageTitle(string expectedTitle)
        {
            wait.WaitElementToBeDisplayed(WebDriver.FindElement(By.Id("htmlVersion")), "Wiki field", 10);
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));
            return this;
        }

        public WikiPage CheckElementIsDisplayed(IWebElement element)
        {
            Assert.AreEqual(true, element.Displayed);
            return this;
        }
    }
}
