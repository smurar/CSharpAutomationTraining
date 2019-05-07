using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Course2.Base;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Resx;

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
            StringAssert.AreEqualIgnoringCase(HomePageResx.PageTitle , driver.Title, AssertMessages.WrongPageTitle);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public HomePagePOM CheckPageHeaderElements()
        {       
            Assert.IsTrue(HeaderPhoto.IsDisplayed("Header photo"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderHomeLink.IsDisplayed("Header Home link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderWikiPageLink.IsDisplayed("Header WikiPage link"), AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }       

        public HomePagePOM CheckHeadlingTitle()
        {
            StringAssert.AreEqualIgnoringCase(HomePageResx.HeadlingTitle, HeadlingTitle.Text, AssertMessages.WrongHeadlingTitle);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public HomePagePOM CheckDefaultLogInCredentials()
        {
            StringAssert.Contains(HomePageResx.User, DefaultUser.Text, AssertMessages.InvalidValue);
            StringAssert.Contains(HomePageResx.Password, DefaultPassword.Text, AssertMessages.InvalidValue);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public HomePagePOM CheckLogInFields()
        {
            Assert.IsTrue(EmailField.IsDisplayed("Email field"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(PasswordField.IsDisplayed("Password field"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(LogInButton.IsDisplayed("Login button"), AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }            

        public HomePagePOM CheckEmailFieldError(string expectedErrorMessage) 
        {
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, EmailErrorText.Text, AssertMessages.WrongErrorDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public HomePagePOM CheckPasswrodFieldError(string expectedErrorMessage)
        {
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, PasswordErrorText.Text, AssertMessages.WrongErrorDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public HomePagePOM ChecLogInWithEmptyCredentialsError()
        {
            CheckEmailFieldError(HomePageResx.NullEmailError);
            CheckPasswrodFieldError(HomePageResx.NullPasswordError);

            return this;
        }

        public HomePagePOM CheckFooterElements()
        {
            Assert.IsTrue(FooterHomeLink.IsDisplayed("Footer Home link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterWikiLink.IsDisplayed("Footer WikiPage link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterContactLink.IsDisplayed("Footer Contact link"), AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }
        #endregion
        #region Action Methods
        public HomePagePOM EnterUser(string user)
        {
            EmailField.SendText(user , "Email field");

            return this;
        }        

        public HomePagePOM EnterPassword(string password)
        {
            PasswordField.SendText(password , "Password field");

            return this;
        }   

        public HomePagePOM ClickLogInButton()
        {            
            LogInButton.ClickElement("LogIn Button");

            return this;
        }

        public HomePagePOM EnterInvalidLogInCredentials()
        {
            EnterUser(HomePageResx.InvalidUser);
            EnterPassword(HomePageResx.InvalidPassword);
            
            return this;
        }
        #endregion
        #region Navigation Methods
        public DashboardPagePOM LogInSuccesful()
        {
            EnterUser(HomePageResx.User)
                .EnterPassword(HomePageResx.Password)
                .ClickLogInButton();

            return new DashboardPagePOM(driver);
        }

        public WikiPagePOM GoToWikiPage()
        {
            HeaderWikiPageLink.ClickElement("Header WikiPage link");

            return new WikiPagePOM(driver);
        }
        #endregion
    }
}



