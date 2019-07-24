using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

//!!!!!!!!!!!!!! namespace Courses.Course2.Pages
namespace Course1.Course2.Pages
{
    public class DashboardPage
    {
        #region header
        private IWebElement HomeHeaderLink { get { return WebDriver.FindElement(By.LinkText("Home")); } }
        private IWebElement WikiPageHeaderLink { get { return WebDriver.FindElement(By.LinkText("WikiPage")); } }
        private IWebElement HeaderImage { get { return WebDriver.FindElement(By.XPath("//div[@id='header']//img")); } }
        #endregion header

        #region user data
        private IWebElement FemaleRadioButton { get { return WebDriver.FindElement(By.XPath("//input[@value='female']")); } }
        private IWebElement BikeRadioButton { get { return WebDriver.FindElement(By.XPath("//input[@value='Bike']")); } }
        private IWebElement CarRadioButton { get { return WebDriver.FindElement(By.XPath("//input[@value='Car']")); } }
        private IWebElement SaveButton { get { return WebDriver.FindElement(By.Id("SaveDetails")); } }

        #endregion user data

        #region footer
        private IWebElement HomeFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='Home']")); } }
        private IWebElement WikiPageFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='WikiPage']")); } }
        private IWebElement ContactFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='Contact (NA)']")); } }
        #endregion footer

        private IWebElement LogoutButton { get { return WebDriver.FindElement(By.XPath("//button[@id='Logout']")); } }

        private IWebDriver WebDriver;

        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            WaitForPageToLoad();
        }

        private void WaitForPageToLoad()
        {
            Thread.Sleep(2000);//will be replaced with wait method
        }

        public DashboardPage CheckPageTitle(string expectedTitle)
        {
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));

            return this;
        }

        public DashboardPage CheckHomeHeaderLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'Home' header link is displayed.", HomeHeaderLink.Displayed);

            return this;
        }

        public DashboardPage CheckWikiPageHeaderLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'WikiPage' header link is displayed.", WikiPageHeaderLink.Displayed);

            return this;
        }

        public DashboardPage CheckHeaderImageIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check header image is displayed.", HeaderImage.Displayed);

            return this;
        }

        public DashboardPage ClickFemaleRadioButton()
        {
            Reporter.LogInfo("Click 'female' radio button");
            FemaleRadioButton.Click();

            return this;
        }

        public DashboardPage ClickBikeRadioButton()
        {
            Reporter.LogInfo("Click 'bike' radio button");
            BikeRadioButton.Click();

            return this;
        }

        public DashboardPage ClickCarRadioButton()
        {
            Reporter.LogInfo("Click 'car' radio button");
            CarRadioButton.Click();

            return this;
        }

        public DashboardPage ClickSaveButton()
        {
            Reporter.LogInfo("Click 'Save' button");
            SaveButton.Click();

            return this;
        }

        public HomePage ClickLogoutButton()
        {
            Reporter.LogInfo("Click 'Login' button");
            LogoutButton.Click();

            return new HomePage(WebDriver);
        }

        public DashboardPage CheckHomeFooterLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'Home' footer link is displayed.", HomeFooterLink.Displayed);

            return this;
        }

        public DashboardPage CheckWikiPageFooterLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'WikiPage' footer link is displayed.", WikiPageFooterLink.Displayed);

            return this;
        }

        public DashboardPage CheckFooterContactNALinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'Contact (NA)' footer link is displayed.", ContactFooterLink.Displayed);

            return this;
        }
    }
}
