using NUnit.Framework;
using OpenQA.Selenium;

namespace TestProject.Course2.POM
{
    public class WikiPagePOM
    {
        IWebDriver driver;

        public WikiPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WikiPagePOM CheckPageTitle()
        {
            StringAssert.AreEqualIgnoringCase("Wiki page", driver.Title, "Page title is not correct");

            return this;
        }
    }
}
