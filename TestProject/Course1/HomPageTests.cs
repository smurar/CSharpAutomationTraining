using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace TestProject.Course1
{
    class HomPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Driver")
            {
                Url = @"C:\Users\itancau\Desktop\Automation\Pages\homepage.html"
            };
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        [Test]
        public void HeaderItemsAreDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//img")).Displayed, "Header photo is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")).Displayed, "Header HomePage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")).Displayed, "Header WikiPage is not displayed");
        }

        [Test]
        public void PageTitleOk()
        {
            StringAssert.AreEqualIgnoringCase("Home Page", driver.Title, "Page title is not correct");
        }

        [Test]
        public void PageHeadlingTitleOk()
        {
            StringAssert.AreEqualIgnoringCase("HTML", driver.FindElement(By.XPath("//h1")).Text, "Page headling title is not correct");
        }

        [Test]
        public void CorrectDefaultLogInDetailsDisplayed()
        {
            StringAssert.Contains("admin@domain.org", driver.FindElement(By.XPath("//b/p[contains(text(),'admin@domain.org')]")).Text, "Invalid default email value");
            StringAssert.Contains("111111", driver.FindElement(By.XPath("//b/p[contains(text(),'111111')]")).Text, "Invalid default password value");
        }

        [Test]
        public void LogInFieldsDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.Id("email")).Displayed, "Email field is not displayed");
            Assert.IsTrue(driver.FindElement(By.Id("password")).Displayed, "Password field is not displayed");
            Assert.IsTrue(driver.FindElement(By.Id("Login")).Displayed, "LogIn button is not displayed");
        }

        [Test]
        public void MissingLogInDetailsErrorMessage()
        {
            driver.FindElement(By.Id("Login")).Click();
            StringAssert.AreEqualIgnoringCase("Email address can't be null", driver.FindElement(By.Id("emailErrorText")).Text, "Wrong error message displayed");
            StringAssert.AreEqualIgnoringCase("Password can't be null", driver.FindElement(By.Id("passwordErrorText")).Text, "Wrong error message displayed");
        }

        [Test]
        public void InvalidEmailFormatErrorMessage()
        {
            driver.FindElement(By.Id("email")).SendKeys("testEmail");
            driver.FindElement(By.Id("Login")).Click();
            StringAssert.AreEqualIgnoringCase("Email address format is not valid", driver.FindElement(By.Id("emailErrorText")).Text, "Wrong error message displayed");
        }

        [Test]
        public void InvalidEmailOrPasswordErrorMessage()
        {
            driver.FindElement(By.Id("email")).SendKeys("testEmail");
            driver.FindElement(By.Id("password")).SendKeys("testPassword");
            driver.FindElement(By.Id("Login")).Click();
            StringAssert.AreEqualIgnoringCase("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text, "Wrong error message displayed");
        }

        [Test]
        public void SuccessfulLogIn()
        {
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            StringAssert.AreEqualIgnoringCase("Dashboard page", driver.Title, "Page title is not correct");
        }

        [Test]
        public void SuccesfulNavigateToWikiPage()
        {
            driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")).Click();
            StringAssert.AreEqualIgnoringCase("Wiki page", driver.Title, "Page title is not correct");
        }

        [Test]
        public void FooterLinksAreDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")).Displayed, "Footer HomePage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")).Displayed, "Footer WikiPage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.LinkText("Contact (NA)")).Displayed, "Footer Contact link is not displayed");
        }
    }
}
