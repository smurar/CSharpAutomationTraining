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
using OpenQA.Selenium.Support.UI;

namespace Course1
{

    public class DashboardPageTests
    {
        public IWebDriver driver;
        HomepageTests homeTests = new HomepageTests();
        Setup setup = new Setup();

        public IWebDriver BeforeTest()
        {
            setup.Login();
            driver = setup.driver;
            return driver;
        }

        [Test]
        public void DashboardPageHeaderLinksTest()
        {
            BeforeTest();
            //homeTests.HomePageHeaderLinksTest();
            Assert.True(driver.FindElement(By.XPath("//div[@id='header']/a")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//div[@id='header']/a/img")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='navHeader']/a[1]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//ul[@id='navHeader']/a[2]")).Displayed);
            driver.Quit();
        }

        [Test]
        public void DashboardPageTitleTest()
        {
            BeforeTest();
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.Quit();
        }

        [Test]
        public void DashboardPageHeadingTitleTest()
        {
            BeforeTest();
            Assert.True(driver.FindElement(By.TagName("h1")).Text.Equals("Dashboard page"));
            driver.Quit();
        }

        [Test]
        public void EditPersonalInformationTest()
        {
            BeforeTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("myDiv")));
            Assert.False(driver.FindElement(By.XPath("//p[@id='detailsSavedMessage']")).Displayed);
            driver.FindElement(By.XPath("//input[@id='firstname']")).Clear();
            driver.FindElement(By.XPath("//input[@id='firstname']")).SendKeys("Olga");
            driver.FindElement(By.XPath("//div[@id='myDiv']/form/input[2]")).Clear();
            driver.FindElement(By.XPath("//div[@id='myDiv']/form/input[2]")).SendKeys("Finn");
            driver.FindElement(By.XPath("//input[@value='female']")).Click();
            driver.FindElement(By.XPath("//input[@value='Bike']")).Click();
            driver.FindElement(By.XPath("//input[@type='date']")).SendKeys("09251990");
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys("C:\\Users\\rparlaghi\\Desktop\\SamplePNGImage_100kbmb.png");
            driver.FindElement(By.XPath("//button[@id='SaveDetails']")).Click();
            Assert.True(driver.FindElement(By.XPath("//p[@id='detailsSavedMessage']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//p[@id='detailsSavedMessage']")).Text.Equals("Details saved"));
            driver.Quit();
        }

        [Test]
        public void LogoutTest()
        {
            BeforeTest();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Logout")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.True(driver.Title.Equals("Home page"));
            driver.Quit();
        }

        [Test]
        public void DashboardFooterLinksTest()
        {
            BeforeTest();
            homeTests.FooterLinksDisplayedTest();
            driver.Quit();
        }
    }
}