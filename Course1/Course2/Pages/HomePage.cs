using NUnit.Framework;
using OpenQA.Selenium;

namespace Course1.Course2.Pages
{
    public class HomePage
    {
        #region header
        private IWebElement HomeHeaderLink { get { return WebDriver.FindElement(By.LinkText("Home")); } }
        private IWebElement WikiPageHeaderLink { get { return WebDriver.FindElement(By.LinkText("WikiPage")); } }
        private IWebElement HeaderImage { get { return WebDriver.FindElement(By.XPath("//div[@id='header']//img")); } }
        #endregion header

        #region login
        private IWebElement EmailTextField { get { return WebDriver.FindElement(By.Id("email")); } }
        private IWebElement PasswordTextField { get { return WebDriver.FindElement(By.Id("password")); } }
        private IWebElement LoginButton { get { return WebDriver.FindElement(By.Id("Login")); } }
        #endregion login

        #region footer
        private IWebElement HomeFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='Home']")); } }
        private IWebElement WikiPageFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='WikiPage']")); } }
        private IWebElement ContactFooterLink { get { return WebDriver.FindElement(By.XPath("//a[text()='Contact (NA)']")); } }
        #endregion footer

        private IWebElement HTMLPageTitle { get { return WebDriver.FindElement(By.XPath("//h1[text()='HTML']")); } }

        private IWebDriver WebDriver;

        public HomePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public HomePage CheckPageTitle(string expectedTitle)
        {
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));

            return this;
        }

        public HomePage CheckPageHeadingTitle(string expectedTitle)
        {
            Reporter.LogInfo("Check home page 'HTML' title is displayed.");
            Assert.AreEqual(expectedTitle, HTMLPageTitle.Text);

            return this;
        }

        public HomePage FillInEmail(string email)
        {
            Reporter.LogInfo("Fill in e-mail address: '" + email + "'");
            EmailTextField.SendKeys(email);

            return this;
        }

        public HomePage FillInPassword(string password)
        {
            Reporter.LogInfo("Fill in password: '" + password + "'");
            PasswordTextField.SendKeys(password);

            return this;
        }

        public DashboardPage ClickLogin()
        {
            Reporter.LogInfo("Click 'Login' button");
            LoginButton.Click();

            return new DashboardPage(WebDriver);
        }

        public HomePage CheckHomeHeaderLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'Home' header link is displayed.", HomeHeaderLink.Displayed);

            return this;
        }

        public HomePage CheckWikiPageHeaderLinkIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check 'WikiPage' header link is displayed.", WikiPageHeaderLink.Displayed);

            return this;
        }

        public HomePage CheckHeaderImageIsDisplayed(bool expected)
        {
            Assert.True(expected, "Check header image is displayed.", HeaderImage.Displayed);

            return this;
        }
    }
}
