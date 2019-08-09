using Course2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    /// <summary>
    /// HomePage page object
    /// </summary>
    public class HomePage
    {
        private IWebDriver Driver;
        
        private IWebElement HeaderWikiLink => Driver.FindElement(By.XPath("//div[@id='header']/a"));
        private IWebElement HeaderWikiImg => Driver.FindElement(By.XPath("//div[@id='header']/a/img"));
        private IWebElement MyHomeLink => Driver.FindElement(By.XPath("//ul[@id='navHeader']/a[1]"));
        private IWebElement MyWikiLink => Driver.FindElement(By.XPath("//ul[@id='navHeader']/a[2]"));
        private IWebElement PageTitle => Driver.FindElement(By.TagName("title"));
        private IWebElement HeadingTitle => Driver.FindElement(By.TagName("h1"));
        private IWebElement DefaultEmail => Driver.FindElement(By.XPath("html/body/b/p[1]"));
        private IWebElement DefaultPassword => Driver.FindElement(By.XPath("html/body/b/p[2]"));
        private IWebElement EmailField => Driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("Login"));
        private IWebElement FooterHomeLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[1]/a"));
        private IWebElement FooterWikiLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[2]/a"));
        private IWebElement FooterContactLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[3]/a"));
        private IWebElement EmailError => Driver.FindElement(By.Id("emailErrorText"));
        private IWebElement PasswordError => Driver.FindElement(By.Id("passwordErrorText"));

        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        /// <summary>
        /// Check page title
        /// </summary>
        /// <param name="ExpectedTitle">Expected page title</param>
        /// <returns>HomePage object</returns>
        public HomePage CheckHomeTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking page title");
            Assert.True(Driver.Title.Equals(ExpectedTitle));
            return this;
        }

        /// <summary>
        /// Waiting for the page to fully load - used in the Logout test
        /// </summary>
        /// <returns>HomePage tests</returns>
        public HomePage Wait()
        {
            Reporter.LogInfo("Waiting for 'email' to be displayed");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));
            return this;
        }

        /// <summary>
        /// Check links and image in the header
        /// </summary>
        /// <returns>HomePage object</returns>
        public HomePage CheckHeaderLinks()
        {
            Reporter.LogInfo("Checking page header links");
            Assert.True(HeaderWikiLink.Displayed);
            Assert.True(HeaderWikiImg.Displayed);
            Assert.True(MyHomeLink.Displayed);
            Assert.True(MyWikiLink.Displayed);
            Reporter.LogScreenshot("Home page screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        /// <summary>
        /// Check title of page heading
        /// </summary>
        /// <param name="ExpectedHeading">Expected heading title</param>
        /// <returns>HomePage object</returns>
        public HomePage CheckHeadingTitle(string ExpectedHeading)
        {
            Reporter.LogInfo("Checking heading title");
            Assert.True(HeadingTitle.Text.Equals(ExpectedHeading));
            return this;
        }

        /// <summary>
        /// Check the default text for email and password
        /// </summary>
        /// <param name="EmailText">Default email text</param>
        /// <param name="PasswordText">Default password text</param>
        /// <returns>HomePage object</returns>
        public HomePage CheckDefaultEmailPassText(string EmailText, string PasswordText)
        {
            Reporter.LogInfo("Checking default email and password are displayed");
            Assert.True(DefaultEmail.Displayed);
            Assert.True(DefaultPassword.Displayed);
            Assert.True(DefaultEmail.Text.Equals(EmailText));
            Assert.True(DefaultPassword.Text.Equals(PasswordText));
            return this;
        }

        /// <summary>
        /// Check that the login fields are displayed
        /// </summary>
        /// <returns>HomePage object</returns>
        public HomePage CheckLoginFields()
        {
            Reporter.LogInfo("Checking login fields are displayed");
            Assert.True(EmailField.Displayed);
            Assert.True(PasswordField.Displayed);
            return this;
        }

        /// <summary>
        /// Navigating to the Wiki page
        /// </summary>
        /// <param name="ExpectedTitle">WikiPage title</param>
        /// <returns>WikiPage object</returns>
        public WikiPage GoToWiki()
        {
            MyWikiLink.ClickIt("Wiki link");
            Assert.True(Driver.Title.Equals(MyResource.WikiTitle));
            Reporter.LogScreenshot("Wiki page screenshot", ImageHelper.CaptureScreen(Driver));
            return new WikiPage(Driver);
        }

        /// <summary>
        /// Check the page footer links
        /// </summary>
        /// <returns>HomePage object</returns>
        public HomePage CheckFooterLinks()
        {
            Reporter.LogInfo("Checking the footer links");
            Assert.True(FooterHomeLink.Displayed);
            Assert.True(FooterWikiLink.Displayed);
            Assert.True(FooterContactLink.Displayed);
            Assert.True(FooterHomeLink.Text.Equals(MyResource.FooterHome));
            Assert.True(FooterWikiLink.Text.Equals(MyResource.FooterWiki));
            Assert.True(FooterContactLink.Text.Equals(MyResource.FooterContact));

            return this;
        }

        /// <summary>
        /// Email error check
        /// </summary>
        /// <param name="Error">The error to be checked</param>
        /// <returns>HomePage object</returns>
        public HomePage CheckEmailError(string Error)
        {
            Reporter.LogInfo("Checking email error");
            Assert.True(EmailError.Text.Equals(Error));
            Reporter.LogScreenshot("Email error screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        /// <summary>
        /// Password error check
        /// </summary>
        /// <param name="Error">The error to be checked</param>
        /// <returns>HomePage object</returns>
        public HomePage CheckPasswordError(string Error)
        {
            Reporter.LogInfo("Checking password error");
            Assert.True(PasswordError.Text.Equals(Error));
            Reporter.LogScreenshot("Password error screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        /// <summary>
        /// Write text into the Email field
        /// </summary>
        /// <param name="EmailAddress">The address to be written</param>
        /// <param name="ElementName">The name of the field</param>
        /// <returns>HomePage object</returns>
        public HomePage FillInEmail(string EmailAddress, string ElementName)
        {
            EmailField.SendText(EmailAddress, ElementName);
            return this;
        }

        /// <summary>
        /// Write text into the Password field
        /// </summary>
        /// <param name="Password">The password to be written</param>
        /// <param name="ElementName">The name of the field</param>
        /// <returns>HomePage object</returns>
        public HomePage FillInPassword(string Password, string ElementName)
        {
            PasswordField.SendText(Password, ElementName);
            return this;
        }

        /// <summary>
        /// Click the login button
        /// </summary>
        /// <typeparam name="T">Generic type parameter</typeparam>
        /// <returns>HomePage object</returns>
        public T ClickLogin<T>()
        {
            LoginButton.ClickIt("Login button");
            return (T)Activator.CreateInstance(typeof(T), new object[1] { Driver });
        }

        /// <summary>
        /// Failed login flow with missing password
        /// </summary>
        /// <returns>HomePage object</returns>
        public HomePage LoginNegativeFlow()
        {
            FillInEmail(MyResource.Email, "Email");
            ClickLogin<HomePage>();
            Reporter.LogScreenshot("Login error screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        /// <summary>
        /// Successful login flow
        /// </summary>
        /// <returns>HomePage object</returns>
        public DashboardPage LoginPositiveFlow()
        {
            FillInEmail(MyResource.Email, "Email");
            FillInPassword(MyResource.Password, "Password");
            ClickLogin<DashboardPage>();
            Reporter.LogScreenshot("Logged in screenshot", ImageHelper.CaptureScreen(Driver));
            return new DashboardPage(Driver);
        }
    }
}
