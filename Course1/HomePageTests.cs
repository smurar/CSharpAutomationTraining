using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Course1
{
    [TestFixture]
    public class HomepageTests
    {

        public IWebDriver driver;
        Setup setup = new Setup();
        
        public IWebDriver BeforeTest()
        {
            setup.Initialize();
            driver = setup.driver;
            return driver;
        } 

        [Test]
        public void HomePageHeaderLinksTest()
        {
            BeforeTest();  
            Assert.True(driver.FindElement(By.XPath("//div[@id='header']/a")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//div[@id='header']/a/img")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='navHeader']/a[1]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='navHeader']/a[2]")).Displayed);
            driver.Quit();
        }

        [Test]
        public void HomePageTitleTest()
        {
            BeforeTest();
            Assert.True(driver.Title.Equals("Home page"));
            driver.Quit();
        }

        [Test]
        public void HomePageHeadingTitleTest()
        {
            BeforeTest();
            Assert.True(driver.FindElement(By.TagName("h1")).Text.Equals("HTML"));
            driver.Quit();
        }

        [Test]
        public void DefaultEmailPasswordTextTest()
        {
            BeforeTest();
            Assert.True(driver.FindElement(By.XPath("html/body/b/p[1]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("html/body/b/p[2]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("html/body/b/p[1]")).Text.Equals("Default email: admin@domain.org"));
            Assert.True(driver.FindElement(By.XPath("html/body/b/p[2]")).Text.Equals("Default password: 111111"));
            driver.Quit();
        }

        [Test]
        public void LoginFieldsDisplayedTest()
        {
            BeforeTest();
            Assert.True(driver.FindElement(By.Id("email")).Displayed);
            Assert.True(driver.FindElement(By.Id("password")).Displayed);
            driver.Quit();
        }

        [Test]
        public void ErrorEmptyEmailTest()
        {
            BeforeTest();
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.FindElement(By.Id("emailErrorText")).Text.Equals("Email address can't be null"));
            driver.Quit();
        }

        [Test]
        public void ErrorInvalidEmailFormatTest()
        {
            BeforeTest();
            driver.FindElement(By.Id("email")).SendKeys("asd");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.FindElement(By.Id("emailErrorText")).Text.Equals("Email address format is not valid"));
            driver.Quit();

        }

        [Test]
        public void ErrorInvalidLoginDataTest()
        {
            BeforeTest();
            driver.FindElement(By.Id("email")).SendKeys("user1@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("pass1");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.FindElement(By.Id("passwordErrorText")).Text.Equals("Invalid password/email"));
            driver.Quit();
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            BeforeTest();
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.Quit();
        }

        [Test]
        public void NavigateToWikiPageTest()
        {
            BeforeTest();
            driver.FindElement(By.XPath("//ul[@id='navHeader']/a[2]")).Click();
            Assert.True(driver.Title.Equals("Wiki page"));
            driver.Quit();
        }

        [Test]
        public void FooterLinksDisplayedTest()
        {
            BeforeTest();
            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[1]/a")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[2]/a")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[3]/a")).Displayed);

            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[1]/a")).Text.Equals("Home"));
            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[2]/a")).Text.Equals("WikiPage"));
            Assert.True(driver.FindElement(By.XPath("//ul[@id='nav']/li[3]/a")).Text.Equals("Contact (NA)"));
            driver.Quit();
        }
    }
}