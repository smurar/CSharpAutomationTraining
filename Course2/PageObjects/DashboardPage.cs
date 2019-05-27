using Course2.Reports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Course2.PageObjects
{
    public class DashboardPage
    {
        private IWebDriver WebDriver;

        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public DashboardPage CheckPageTitle(string title)
        {
            Reporter.LogInfo("Check that the page title is: " + title);
            Assert.AreEqual(title, WebDriver.Title, "You are not on the DashboardPage");
            return this;
        }
    }
}