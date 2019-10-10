using CSharpAutoTraining.Course3.PageObjects;
using CSharpAutoTraining.Course3.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.PageObjects
{
    public class HomePage
    {   /// <summary>
        /// Homepage Page Object
        /// </summary>
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
        /// <summary>
        /// Navigates to Homepage. Returns HomePage object
        /// </summary>
        /// <returns></returns>
        public HomePage GoToHomepage()
        {
            ReporterBDD.LogInfo("Navigate to Homepage");

            driver.Navigate().GoToUrl(HomepageURL);

            return this;
        }

        /// <summary>
        /// Checks homepage title against input string. Returns HomePage object
        /// </summary>
        /// <param name="expectedTitle">Expected Title to be checked against</param>
        /// <returns></returns>
        //return HomePage in order to chain methods in test
        public HomePage CheckHomepageTitle(string expectedTitle)
        {
            ReporterBDD.LogInfo("Check homepage title");

            Assert.AreEqual(expectedTitle, driver.Title);

            return this;
        }

        /// <summary>
        /// Fills in email field. Returns HomePage object
        /// </summary>
        /// <param name="email">Email to be written</param>
        /// <returns></returns>
        public HomePage FillInEmail(string email)
        {
            ReporterBDD.LogInfo("Fill in email");

            EmailField.SendKeys(email, "Email field");

            return this;
        }

        /// <summary>
        /// Fills in password field. Returns HomePage object
        /// </summary>
        /// <param name="password">Password to be written</param>
        /// <returns></returns>
        public HomePage FillInPassword(string password)
        {
            ReporterBDD.LogInfo("Fill in password");

            PasswordField.SendKeys(password, "Password field");

            return this;
        }

        /// <summary>
        /// Clicks on login button. Returns HomePage object
        /// </summary>
        /// <returns></returns>
        public HomePage ClickLoginButton()
        {
            ReporterBDD.LogInfo("Click on login button");

            LoginButton.Click("Login button");

            return this;
        }

        /// <summary>
        /// Returns new Dashboard Object. Used after successfull login.
        /// </summary>
        /// <returns></returns>
        public Dashboard LoginRedirectToDashboard()
        {
            ReporterBDD.LogInfo("Redirect to Dashboard page after successful login");

            return new Dashboard(this.driver);
        }

        /// <summary>
        /// Clicks on Wikipage header link. Returns HomePage object
        /// </summary>
        /// <returns></returns>
        public HomePage ClickOnWikiPage()
        {
            ReporterBDD.LogInfo("Click on Wikipage header link and Redirect");

            WikiPageHeaderLink.Click("Wiki header link");

            return this;
        }

        /// <summary>
        /// Returns new WikiPage object. Used after clicking on Wikipage header link
        /// Might get deprecated as redirect test method creates new WikiPage object.
        /// </summary>
        /// <returns></returns>
        public WikiPage RedirectToWikiPage()
        {
            ReporterBDD.LogInfo("Redirect to Piki page");
            return new WikiPage(this.driver);
        }
    }
}
