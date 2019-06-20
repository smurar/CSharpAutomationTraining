using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Resources.Reports;
using TestProject.Resources.Resx;

namespace TestProject.Resources.POM
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
