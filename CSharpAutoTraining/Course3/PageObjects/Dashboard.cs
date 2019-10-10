using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using CSharpAutoTraining.Course3.Helpers;

namespace CSharpAutoTraining.Course3.PageObjects
{   /// <summary>
    /// Dashboard Page Object
    /// </summary>
    public class Dashboard
    {
        private IWebDriver driver;

        public Dashboard(IWebDriver driver)
        {
            this.driver = driver;
        }

        //set url from config
        public string DasboardURL = System.Configuration.ConfigurationManager.AppSettings["DashboardURL"];
        //elements
        public IWebElement HomepageHeaderLink => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#navHeader > a:nth-child(1)"));
        public IWebElement WikiPageHeaderLink => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#navHeader > a:nth-child(2)"));
        public IWebElement DashboardHeading1 => ((RemoteWebDriver)driver).FindElement(By.TagName("h1"));
        public IWebElement DashboardHeaderImage => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#header > a > img"));
        public IWebElement HomeFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[1]/a"));
        public IWebElement WikiFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[2]/a"));
        public IWebElement ContactsFooterLink => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"nav\"]/li[3]/a"));
        //edit account elements
        public IWebElement FirstNameElement => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#firstname"));
        public IWebElement LastNameElement => ((RemoteWebDriver)driver).FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)"));
        public IWebElement DetailsSavedMessage => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));
        public IWebElement FemaleRadioButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[4]"));
        public IWebElement MaleRadioButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[3]"));
        public IWebElement BikeButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[5]"));
        public IWebElement CarButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[6]"));
        public IWebElement SaveDetailsButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"SaveDetails\"]"));
        public IWebElement LogoutButton => ((RemoteWebDriver)driver).FindElement(By.XPath("//*[@id=\"Logout\"]"));

        /// <summary>
        /// Navigates to dashboard page. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard GoToDashboard()
        {
            ReporterBDD.LogInfo("Navigate to Dashboard page");

            driver.Navigate().GoToUrl(DasboardURL);

            return this;
        }

        /// <summary>
        /// Checks page title. Returns Dashboard Object
        /// </summary>
        /// <param name="expectedTitle">Expected title to check against</param>
        /// <returns></returns>
        public Dashboard CheckDashboardTitle(string expectedTitle)
        {
            ReporterBDD.LogInfo("Check Dashboard page title");

            Assert.AreEqual(expectedTitle, driver.Title);

            return this;
        }

        /// <summary>
        /// Fills in first name in the First Name field. Returns Dashboard Object
        /// </summary>
        /// <param name="firstName">first name to be written</param>
        /// <returns></returns>
        public Dashboard FillInFirstName(string firstName)
        {
            ReporterBDD.LogInfo("Fill in first name");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            FirstNameElement.Clear();

            FirstNameElement.SendKeys(firstName, "First Name Field");

            return this;
        }

        /// <summary>
        /// Fills in last name in the Last Name field. Returns Dashboard Object
        /// </summary>
        /// <param name="lastName">last name to be written</param>
        /// <returns></returns>
        public Dashboard FillInLastName(string lastName)
        {
            ReporterBDD.LogInfo("Fill in last name");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            LastNameElement.Clear();

            LastNameElement.SendKeys(lastName, "Last Name Field");

            return this;
        }

        /// <summary>
        /// Clicks Save Details button. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard ClickSaveDetailsButton()
        {
            ReporterBDD.LogInfo("Click on Save Details button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => SaveDetailsButton.Displayed);

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            SaveDetailsButton.Click("Save Details button");

            return this;
        }

        /// <summary>
        /// Checks if female button is selected. If not it selects it. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard SelectFemaleButton()
        {
            ReporterBDD.LogInfo("Select Female radio button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => FemaleRadioButton.Displayed);

            if (FemaleRadioButton.Selected == false)
            {
                FemaleRadioButton.Click("Female Radio button");
            }

            return this;
        }

        /// <summary>
        /// Checks if male button is selected. If not it selects it. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard SelectMaleButton()
        {
            ReporterBDD.LogInfo("Select Male radio button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => MaleRadioButton.Displayed);

            if (MaleRadioButton.Selected == false)
            {
                MaleRadioButton.Click("Male Radio button");
            }

            return this;
        }

        /// <summary>
        /// Checks if bike button is selected. If not it selects it. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard SelectBikeButton()
        {
            ReporterBDD.LogInfo("Select Bike button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => BikeButton.Displayed);

            if (BikeButton.Selected == false)
            {
                BikeButton.Click("Bike check button");
            }

            return this;
        }

        /// <summary>
        /// Checks if car button is selected. If not it selects it. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard SelectCarButton()
        {
            ReporterBDD.LogInfo("Select Car button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => CarButton.Displayed);

            if (CarButton.Selected == false)
            {
                CarButton.Click("Car check button");
            }

            return this;
        }

        /// <summary>
        /// Clicks logout button. Returns Dashboard Object
        /// </summary>
        /// <returns></returns>
        public Dashboard ClickLogoutButton()
        {
            ReporterBDD.LogInfo("Click logout button");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => LogoutButton.Displayed);

            LogoutButton.Click("Logout button");

            return this;
        }

        /// <summary>
        /// Returns new Homepage Object. Used after ClickLogoutButton()
        /// </summary>
        /// <returns></returns>
        public HomePage LogoutRedirectToHomepage()
        {
            ReporterBDD.LogInfo("Redirect to homepage after logout button pressed");

            return new HomePage(this.driver);
        }
    }
}
