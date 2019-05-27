using Course2.Reports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Course2.PageObjects
{
    public class WikiPage
    {
        private IWebDriver WebDriver;

        public WikiPage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }
        public WikiPage CheckPageTitle(string title)
        {
            Reporter.LogInfo("Check that the page title is: " + title);
            Assert.AreEqual(title, WebDriver.Title, "You are not on the WikiPage");
            return this;
        }
    }
}