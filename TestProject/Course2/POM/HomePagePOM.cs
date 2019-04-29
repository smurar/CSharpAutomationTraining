using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Course2.Base;
using TestProject.Course2.Resources;

namespace TestProject.Course2.POM
{
    public class HomePagePOM : BasePage
    {
        private IWebDriver driver;

        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region WebElements
        #region Header Elements
        private IWebElement HeaderPhoto { get { return driver.FindElement(By.XPath("//img")); } }
        private IWebElement HeaderHomeLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")); } }
        private IWebElement HeaderWikiPageLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")); } }
        #endregion
        #region Body Elements
        private IWebElement HeadlingTitle { get { return driver.FindElement(By.XPath("//h1")); } }
        private IWebElement DefaultUser { get { return driver.FindElement(By.XPath("//b/p[contains(text(),'admin@domain.org')]")); } }
        private IWebElement DefaultPassword { get { return driver.FindElement(By.XPath("//b/p[contains(text(),'111111')]")); } }
        private IWebElement EmailField { get { return driver.FindElement(By.Id("email")); } }
        private IWebElement PasswordField { get { return driver.FindElement(By.Id("password")); } }
        private IWebElement LogInButton { get { return driver.FindElement(By.Id("Login")); } }
        private IWebElement EmailErrorText { get { return driver.FindElement(By.Id("emailErrorText")); } }
        private IWebElement PasswordErrorText { get { return driver.FindElement(By.Id("passwordErrorText")); } }
        #endregion
        #region Footer Elements
        private IWebElement FooterHomeLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")); } }
        private IWebElement FooterWikiLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")); } }
        private IWebElement FooterContactLink { get { return driver.FindElement(By.LinkText("Contact (NA)")); } }
        #endregion
        #endregion

        #region Validation Methods
        public HomePagePOM CheckPageTitle()
        {
            StringAssert.AreEqualIgnoringCase(HomePageResources.PageTitle , driver.Title, AssertMessages.WrongPageTitle);

            return this;
        }

        public HomePagePOM CheckPageHeaderElements()
        {
            Assert.IsTrue(HeaderPhoto.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderHomeLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderWikiPageLink.Displayed, AssertMessages.ElementNotDisplayed);

            return this;
        }       

        public HomePagePOM CheckHeadlingTitle()
        {
            StringAssert.AreEqualIgnoringCase(HomePageResources.HeadlingTitle, HeadlingTitle.Text, AssertMessages.WrongHeadlingTitle);

            return this;
        }

        public HomePagePOM CheckDefaultLogInCredentials()
        {
            StringAssert.Contains(HomePageResources.User, DefaultUser.Text, AssertMessages.InvalidValue);
            StringAssert.Contains(HomePageResources.Password, DefaultPassword.Text, AssertMessages.InvalidValue);

            return this;
        }

        public HomePagePOM CheckLogInFields()
        {
            Assert.IsTrue(EmailField.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(PasswordField.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(LogInButton.Displayed, AssertMessages.ElementNotDisplayed);

            return this;
        }            

        public HomePagePOM CheckEmailFieldError(string expectedErrorMessage)
        {
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, EmailErrorText.Text, AssertMessages.WrongErrorDisplayed);

            return this;
        }

        public HomePagePOM CheckPasswrodFieldError(string expectedErrorMessage)
        {
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, PasswordErrorText.Text, AssertMessages.WrongErrorDisplayed);

            return this;
        }

        public HomePagePOM CheckEmptyLogInError()
        {
            CheckEmailFieldError("Email address can't be null");
            CheckPasswrodFieldError("Password can't be null");

            return this;
        }

        public HomePagePOM CheckFooterElements()
        {
            Assert.IsTrue(FooterHomeLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterWikiLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterContactLink.Displayed, AssertMessages.ElementNotDisplayed);

            return this;
        }
        #endregion
        #region Action Methods
        public HomePagePOM EnterLogInUser(string user)
        {
            EmailField.SendKeys(user);

            return this;
        }        

        public HomePagePOM EnterLogInPassword(string password)
        {
            PasswordField.SendKeys(password);

            return this;
        }   

        public HomePagePOM ClickLogInButton()
        {
            LogInButton.Click();

            return this;
        }

        public HomePagePOM EnterInvalidLogInCredentials()
        {
            EnterLogInUser("testUser");
            EnterLogInPassword("testPassword");
            
            return this;
        }
        #endregion
        #region Navigation Methods
        public DashboardPagePOM GoToDashboarPage()
        {
            EnterLogInUser(HomePageResources.User)
                .EnterLogInPassword(HomePageResources.Password)
                .ClickLogInButton();

            return new DashboardPagePOM(driver);
        }

        public WikiPagePOM GoToWikiPage()
        {
            HeaderWikiPageLink.Click();

            return new WikiPagePOM(driver);
        }
        #endregion
    }
}



