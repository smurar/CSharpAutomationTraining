using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course1
{
    class HomePageTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Manage().Window.Maximize();
            driver.Url = "file:///D:/workspace/Pages/homepage.html";
        }

        [Test]
        public void CheckHeaderImage()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='header']//img")).Displayed, "The header image is not displayed");
        }

        [Test]
        public void CheckHeaderLinks()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//ul[@id='navHeader']//a[1]")).Displayed, "Home Page link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//ul[@id='navHeader']//a[2]")).Displayed, "Wiki Page link is not displayed");
        }

        [Test]
        public void CheckPageTitle()
        {
           
            Assert.AreEqual("Home page", driver.Title, "The title is not correct");
        }

        [Test]
        public void CheckHeadingTitle()
        {
           
            
            Assert.AreEqual("HTML", driver.FindElement(By.XPath("//h1")).Text, "The heading title is not correct");
        }

        [Test]
        public void CheckDefaultEmail()
        {
            IWebElement defaultEmail = driver.FindElement(By.XPath("//b//p[contains(text() , 'Default email: admin@domain.org')]"));
            Assert.IsTrue(defaultEmail.Displayed, "Default Email is not displayed");
            Assert.AreEqual("Default email: admin@domain.org", defaultEmail.Text, "Deafult email text is not correct");
        }

        [Test]
        public void CheckDefaultPassword()
        {
            IWebElement defaultPassword = driver.FindElement(By.XPath("//b//p[contains(text() , 'Default password: 111111')]"));
            Assert.IsTrue(defaultPassword.Displayed, "Default Password is not displayed");
            Assert.AreEqual("Default password: 111111", defaultPassword.Text, "Deafult Password text is not correct");
        }

        [Test]
        public void CheckLoginFields()
        {
            Assert.IsTrue(driver.FindElement(By.Id("email")).Displayed, "Email field is not displayed");
            Assert.IsTrue(driver.FindElement(By.Id("password")).Displayed, "Password field is not displayed");
        }

        [Test]
        public void CheckNoEmailErrorMessage()
        {
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual("Email address can't be null", driver.FindElement(By.Id("emailErrorText")).Text, "The error message for no email address is not correct");

        }

        [Test]
        public void CheckEmailAddressFormatErrorMessage()
        {
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("Test");
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual("Email address format is not valid", driver.FindElement(By.Id("emailErrorText")).Text,
                            "The error message for the format of the email is not correct");
        }

        [Test]
        public void CheckInvalidEmailOrPasswordErrorMessage()
        {
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("Test@test.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Test");
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text,
                           "The error message for invalid email or password is not correct");
        }

        [Test]
        public void CheckSuccessfullyLoginAction()
        {
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            Assert.AreEqual("Dashboard page", driver.Title, "You are not on the expected landing page");
        }

        [Test]
        public void NavigateToWikiPage()
        {
            driver.FindElement(By.XPath("//ul[@id='navHeader']//a[2]")).Click();
           
            Assert.AreEqual("Wiki page", driver.Title, "You are not on the Wiki Page");
        }

        [Test]
        public void CheckFooterLinks()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'Home')]")).Displayed, "Home Page footer link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'WikiPage')]")).Displayed, "Wiki Page footer link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'Contact (NA)')]")).Displayed, "Contact footer link is not displayed");

        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }

    }
}
