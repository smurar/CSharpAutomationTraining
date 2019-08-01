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

        public HomePage Wait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));
            return this;
        }

        public HomePage CheckHomeTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking page title");
            Assert.True(Driver.Title.Equals(ExpectedTitle));
            return this;
        }

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

        public HomePage CheckHeadingTitle(string ExpectedHeading)
        {
            Reporter.LogInfo("Checking heading title");
            Assert.True(HeadingTitle.Text.Equals(ExpectedHeading));
            return this;
        }

        public HomePage CheckDefaultEmailPassText(string EmailText, string PasswordText)
        {
            Reporter.LogInfo("Checking default email and password are displayed");
            Assert.True(DefaultEmail.Displayed);
            Assert.True(DefaultPassword.Displayed);
            Assert.True(DefaultEmail.Text.Equals(EmailText));
            Assert.True(DefaultPassword.Text.Equals(PasswordText));
            return this;
        }

        public HomePage CheckLoginFields()
        {
            Reporter.LogInfo("Checking login fields are displayed");
            Assert.True(EmailField.Displayed);
            Assert.True(PasswordField.Displayed);
            return this;
        }

        public HomePage GoToWiki(string Title)
        {
            MyWikiLink.ClickIt("Wiki link");
            Assert.True(PageTitle.Equals(Title));
            Reporter.LogScreenshot("Wiki page screenshot: ", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        public HomePage CheckFooterLinks(string Home, string Wiki, string Contact)
        {
            Assert.True(FooterHomeLink.Displayed);
            Assert.True(FooterWikiLink.Displayed);
            Assert.True(FooterContactLink.Displayed);
            Assert.True(FooterHomeLink.Text.Equals(Home));
            Assert.True(FooterWikiLink.Text.Equals(Wiki));
            Assert.True(FooterContactLink.Text.Equals(Contact));

            return this;
        }

        public HomePage CheckEmailError(string Error)
        {
            Reporter.LogInfo("Checking email error");
            Assert.True(EmailError.Text.Equals(Error));
            Reporter.LogScreenshot("Email error screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        public HomePage CheckPasswordError(string Error)
        {
            Reporter.LogInfo("Checking password error");
            Assert.True(PasswordError.Text.Equals(Error));
            Reporter.LogScreenshot("Password error screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        public HomePage FillInEmail(string EmailAddress, string ElementName)
        {
            EmailField.SendText(EmailAddress, ElementName);
            return this;
        }

        public HomePage FillInPassword(string Password, string ElementName)
        {
            PasswordField.SendText(Password, ElementName);
            return this;
        }

        public HomePage ClickLoginButton()
        {
            LoginButton.ClickIt("Login button");
            return this;
        }

        public DashboardPage Login(string Email, string Password, string ElementName1, string ElementName2)
        {
            FillInEmail(Email, ElementName1);
            FillInPassword(Password, ElementName2);
            LoginButton.ClickIt("Login button");
            Reporter.LogScreenshot("Logged in screenshot", ImageHelper.CaptureScreen(Driver));
            return new DashboardPage(Driver);
        }

        public DashboardPage OnDashboard()
        {
            return new DashboardPage(Driver);
        }
    }
}
