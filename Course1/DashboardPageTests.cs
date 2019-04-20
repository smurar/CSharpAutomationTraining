using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course1
{
    class DashboardPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Manage().Window.Maximize();
            driver.Url = "file:///D:/workspace/Pages/dashboardpage.html";
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

            Assert.AreEqual("Dashboard page", driver.Title, "The title is not correct");
        }

        [Test]
        public void CheckHeadingTitle()
        {


            Assert.AreEqual("Dashboard page", driver.FindElement(By.XPath("//h1")).Text, "The heading title is not correct");
        }

        [Test]
        public void EditPersonalDetails()
        {
            WaitForCompleteLoading();
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys("Septimiu");
            driver.FindElement(By.XPath("//label[contains(text(),'Last Name:')]/following-sibling::input[1]")).Clear();
            driver.FindElement(By.XPath("//label[contains(text(),'Last Name:')]/following-sibling::input[1]")).SendKeys("Murar");
            driver.FindElement(By.XPath("//input[@value='male']")).Click();
            SelectCheckBox(driver.FindElement(By.XPath("//input[@value='Car']")));
            driver.FindElement(By.XPath("//input[@type='date']")).SendKeys("18/12/1992");
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\Car.jpg");
            driver.FindElement(By.Id("SaveDetails")).Click();
            Assert.AreEqual("Details saved", driver.FindElement(By.Id("detailsSavedMessage")).Text, "Detais saved message is not correct");
        }

        [Test]
        public void LogOut()
        {
            WaitForCompleteLoading();
            driver.FindElement(By.Id("Logout")).Click();
            Assert.AreEqual("Home page", driver.Title, "You haven't been successfully log out");
        }

        [Test]
        public void CheckFooterLinks()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'Home')]")).Displayed, "Home Page footer link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'WikiPage')]")).Displayed, "Wiki Page footer link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li//a[contains(text(),'Contact (NA)')]")).Displayed, "Contact footer link is not displayed");

        }

        private void SelectCheckBox(IWebElement element)
        {
            if (!element.Selected)
            {
                element.Click();
            }
        }

        private  void WaitForCompleteLoading()
        {
            while (true)
            {
                if (!driver.FindElement(By.Id("loader")).Displayed)
                {
                    break;
                }
            }
        }


        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}
