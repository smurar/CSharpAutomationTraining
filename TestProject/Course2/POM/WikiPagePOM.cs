using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Resx;

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
            StringAssert.AreEqualIgnoringCase(WikiPageResx.PageTitle, driver.Title, AssertMessages.WrongPageTitle);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }
    }
}
