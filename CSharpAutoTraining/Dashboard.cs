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
using System.Threading.Tasks;

namespace CSharpAutoTraining
{
    class Dashboard
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            // init driver
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/ralucastreja/CSharpAutomationOthers/Pages/dashboardpage.html"; //e.g. driver.Url = "file:///D:/homepage.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test, Order(1)]
        public void HeaderImage()
        {
            // locate test element
            IWebElement headerImg = driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img"));

            // run assertions
            Assert.IsTrue(headerImg.Displayed);   
        }

        [Test, Order(2)]
        public void HeaderLinks()
        {
           // locate test element
            ICollection<IWebElement> headerLinks = driver.FindElements(By.XPath("//*[@id=\"navHeader\"]/a"));

            // run assertions
            foreach (IWebElement headerLink in headerLinks)
            {
                Assert.IsTrue(headerLink.Displayed);

                String uri = headerLink.GetAttribute("href");

                Assert.IsNotEmpty(uri);
                Assert.IsTrue(Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute));
            }

        }

        [Test, Order(3)]
        public void DashboardTitle()
        {
            Assert.AreEqual(driver.Title,"Dashboard page");
        }

        [Test, Order(4)]
        public void PageHeadingTitle()
        {
            // locate test element
            var pageHeadingTitleText = driver.FindElement(By.XPath("//html/body/h1")).Text;

            // run assertions
            Assert.AreEqual(pageHeadingTitleText, "Dashboard page");          
        }

        [Test, Order(5)]
        public void FirstName()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.CssSelector("#firstname")).Clear();
            driver.FindElement(By.CssSelector("#firstname")).SendKeys("Gill");        
        }

        [Test, Order(6)]
        public void LastName()
        {
            driver.FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)")).Clear();
            driver.FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)")).SendKeys("Toy");
        }

        [Test, Order(7)]
        public void RadioButtons()
        {
            driver.FindElement(By.XPath("//*[@name=\"gender\" and @value=\"female\"]")).Click();
        }

        [Test, Order(8)]
        public void Checkbox()
        {
            IWebElement checkboxBike;
            IWebElement checkboxCar;

            checkboxBike = driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[5]")));
            checkboxCar = driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[6]")));

            if (!checkboxBike.Selected)
            {
                checkboxBike.Click();
            }


            if (!checkboxCar.Selected)
            {
                checkboxCar.Click();
            }
        }

        [Test, Order(9)]
        public void SelectBirthday()
        {
            driver.FindElement(By.Name("bday")).SendKeys("11011980");
        }

        [Test, Order(10)]
        public void UploadFile()
        {
            IWebElement fileUpload = driver.FindElement(By.Name("picture"));
            fileUpload.SendKeys(@"C:\Users\rstreja\Desktop\testpic.jpg");
        }

        [Test, Order(11)]
        public void SaveForm()
        {
            driver.FindElement(By.Id("SaveDetails")).Click();
        }

        [Test, Order(12)]
        public void DetailsSavedMessage()
        {
            var DetailsSavedMessage = driver.FindElement(By.Id("detailsSavedMessage"));
            Assert.AreEqual(DetailsSavedMessage.Text, "Details saved");
        }

        [Test, Order(13)]
        public void FooterLinks()
        {
         
            ICollection<IWebElement> footerLinks = driver.FindElements(By.XPath("//*[@id=\"nav\"]"));
           
            foreach (IWebElement footerLink in footerLinks)
            {
                Assert.IsTrue(footerLink.Displayed);
            }
        }

        [Test, Order(14)]
        public void Logout()
        {
            IWebElement logoutButton;
            logoutButton = driver.FindElement(By.Id("Logout"));
            logoutButton.Click();
            string url = driver.Url;
            Assert.AreEqual(driver.Url, "file:///C:/ralucastreja/CSharpAutomationOthers/Pages/homepage.html");
        }

        [OneTimeTearDown]
        public void EndTests()
        {
            driver.Quit();
        }
    }
}
