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

namespace CSharpAutoTraining
{
    class Home
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            // init driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/ralucastreja/CSharpAutomationOthers/Pages/homepage.html"; //e.g. driver.Url = "file:///D:/homepage.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test, Order(1)]
        public void HeaderImage()
        {
            IWebElement headerImg = driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img"));
            
            Assert.IsTrue(headerImg.Displayed);
        }

        [Test, Order(2)]
        public void HeaderLinks()
        {          
            ICollection<IWebElement> headerLinks = driver.FindElements(By.XPath("//*[@id=\"navHeader\"]"));
          
            foreach (IWebElement headerLink in headerLinks)
            {
                Assert.IsTrue(headerLink.Displayed);           
            }
        }

        [Test, Order(3)]
        public void PageTile()
        {
            Assert.AreEqual(driver.Title, "Home page");
        }

        [Test, Order(4)]
        public void PageHeadingTitle()
        {          
            var pageHeadingTitleText = driver.FindElement(By.CssSelector("body > h1")).Text;

            Assert.AreEqual(pageHeadingTitleText, "HTML");
        }

        [Test, Order(5)]
        public void DefaultEmail()
        {
            var defaultEmail = driver.FindElement(By.XPath("/html/body/b/p[1]"));
            Assert.That(defaultEmail.Text, Is.EqualTo("Default email: admin@domain.org")); 
        }

        [Test, Order(6)]
        public void DefaultPass()
        {
            var defaultPass = driver.FindElement(By.XPath("/html/body/b/p[2]"));
            Assert.That(defaultPass.Text, Is.EqualTo("Default password: 111111"));
        }

        [Test, Order(7)]
        public void LoginFieldsDisplayed()
        {
            IWebElement emailField = driver.FindElement(By.XPath("//*[@id=\"email\"]"));
            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            Assert.That(emailField.Displayed);
            Assert.True(passwordField.Displayed);
        }

        [Test, Order(8)]
        public void ErrorEmailNotNull()
        {                 
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            var errorEmailNotNull = driver.FindElement(By.Id("emailErrorText"));
            Assert.AreEqual(errorEmailNotNull.Text, "Email address can't be null");
        }

        [Test, Order(9)]
        public void ErrorEmailFormatNotValid()
        {
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys("jvngbbfsdxdeu");
            driver.FindElement(By.Id("Login")).Click();

            var errorEmailFormatNotValid = driver.FindElement(By.Id("emailErrorText"));
            Assert.AreEqual(errorEmailFormatNotValid.Text, "Email address format is not valid");
        }

        [Test, Order(10)]
        public void ErrorInvalidPassEmail()
        {
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("derg");
            driver.FindElement(By.Id("Login")).Click();

            var errorInvalidPassEmail = driver.FindElement(By.Id("passwordErrorText"));
            Assert.AreEqual(errorInvalidPassEmail.Text, "Invalid password/email");
        }

        [Test, Order(11)]
        public void ValidLogin()
        {
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys("admin@domain.org");
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            string url = driver.Url;
            Assert.AreEqual(driver.Url, "file:///C:/ralucastreja/CSharpAutomationOthers/Pages/dashboardpage.html");
        }

        [Test, Order(12)]
        public void FooterLinks()
        {
            ICollection<IWebElement> footerLinks = driver.FindElements(By.XPath("//*[@id=\"nav\"]"));

            foreach (IWebElement footerLink in footerLinks)
            {
                Assert.IsTrue(footerLink.Displayed);
            }
        }

        [Test, Order(13)]
        public void LandingPageTitle()
        {
            Assert.AreEqual(driver.Title, "Dashboard page");
        }

        [Test, Order(14)]
        public void NavigateToWiki()
        {
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[2]/a")).Click();
            Assert.AreEqual(driver.Title, "Wiki page");
        }

        [OneTimeTearDown]
        public void EndTests()
        {
            driver.Quit();
        }

    }
}
