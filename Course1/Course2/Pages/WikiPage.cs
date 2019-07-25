using NUnit.Framework;
using OpenQA.Selenium;

namespace Course1.Course2.Pages
{
    public class WikiPage
    {
        private IWebDriver WebDriver;

        public WikiPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public WikiPage CheckPageTitle(string expectedTitle)
        {
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));

            return this;
        }
    }
}
