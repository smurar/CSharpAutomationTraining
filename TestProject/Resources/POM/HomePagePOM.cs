﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TestProject.Resources.Class;
using TestProject.Resources.Reports;
using TestProject.Resources.Resx;

namespace TestProject.Resources.POM
{
    public class HomePagePOM
    {
        private IWebDriver driver;

        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region WebElements
        #region Header Elements
        public IWebElement HeaderPhoto { get { return driver.FindElement(By.XPath("//img")); } }
        public IWebElement HeaderHomeLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")); } }
        public IWebElement HeaderWikiPageLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")); } }
        #endregion
        #region Body Elements
        public IWebElement HeadlingTitle { get { return driver.FindElement(By.XPath("//h1")); } }
        public IWebElement DefaultUser { get { return driver.FindElement(By.XPath("//b/p[contains(text(),'admin@domain.org')]")); } }
        public IWebElement DefaultPassword { get { return driver.FindElement(By.XPath("//b/p[contains(text(),'111111')]")); } }
        public IWebElement EmailField { get { return driver.FindElement(By.Id("email")); } }
        public IWebElement PasswordField { get { return driver.FindElement(By.Id("password")); } }
        public IWebElement LogInButton { get { return driver.FindElement(By.Id("Login")); } }
        public IWebElement EmailErrorText { get { return driver.FindElement(By.Id("emailErrorText")); } }
        public IWebElement PasswordErrorText { get { return driver.FindElement(By.Id("passwordErrorText")); } }
        #endregion
        #region Footer Elements
        public IWebElement FooterHomeLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")); } }
        public IWebElement FooterWikiLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")); } }
        public IWebElement FooterContactLink { get { return driver.FindElement(By.LinkText("Contact (NA)")); } }
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

        public T ClickLogin<T>()
        {
            LogInButton.ClickElement("LogIn Button");
            return (T)Activator.CreateInstance(typeof(T), new object[1] { Driver.DriverInstance });
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



