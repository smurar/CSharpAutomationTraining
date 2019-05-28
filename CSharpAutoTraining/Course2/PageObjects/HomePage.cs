using CSharpAutoTraining.Course2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //set url from config
        public string HomepageURL = System.Configuration.ConfigurationManager.AppSettings["HomepageURL"];
        //Elements

        public IWebElement HomeHeaderLink => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#navHeader > a:nth-child(1)"));

        public IWebElement WikiPageHeaderLink => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#navHeader > a:nth-child(2)"));

        public IWebElement Heading1 => ((RemoteWebDriver)driver).FindElement(By.TagName("h1"));

        public IWebElement HomeHeaderImage => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#header > a > img"));

        public IWebElement DefaultEmail => ((RemoteWebDriver)driver).FindElement(By.XPath("/html/body/b/p[1]"));

        public IWebElement DefaultPass => ((RemoteWebDriver)driver).FindElement(By.XPath("/html/body/b/p[2]"));

        public IWebElement HomeFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[1]/a"));

        public IWebElement WikiFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[2]/a"));

        public IWebElement ContactsFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[3]/a"));

        
        //login elements

        public IWebElement EmailField { get { return driver.FindElement(By.XPath("//*[@id=\"email\"]")); } }

        public IWebElement PasswordField { get { return driver.FindElement(By.XPath("//*[@id=\"password\"]")); } }

        private IWebElement LoginButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"Login\"]"));

        //error elements

        public IWebElement EmailCantBeNullError => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"emailErrorText\"]"));

        public IWebElement EmailFormatError => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"emailErrorText\"]"));

        public IWebElement CredentialsInvalidError => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id='passwordErrorText']"));


        //page methods

        public HomePage GoToHomepage()
        {
            Reporter.LogInfo("Navigate to Homepage");

            driver.Navigate().GoToUrl(HomepageURL);

            return this;
        }

        //return HomePage in order to chain methods in test
        public HomePage CheckHomepageTitle(string expectedTitle)
        {
            Reporter.LogInfo("Check homepage title");

            Assert.AreEqual(expectedTitle, driver.Title);

            return this;
        }


        public HomePage FillInEmail(string email)
        {
            Reporter.LogInfo("Fill in email");

            EmailField.SendKeys(email);

            return this;
        }

        public HomePage FillInPassword(string password)
        {
            Reporter.LogInfo("Fill in password");

            PasswordField.SendKeys(password);

            return this;
        }

        public HomePage ClickLoginButton()
        {
            Reporter.LogInfo("Click on login button");

            LoginButton.Click();

            return this;
        }

        public Dashboard LoginRedirectToDashboard()
        {
            Reporter.LogInfo("Redirect to Dashboard page after successful login");

            return new Dashboard(this.driver);
        }
        
        public WikiPage ClickOnWikiPage()
        {
            Reporter.LogInfo("Click on Wikipage header link and Redirect");

            WikiPageHeaderLink.Click();

            return new WikiPage(this.driver);
        }
        
    }
}
