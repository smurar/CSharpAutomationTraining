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

namespace CSharpAutoTraining.Course1
{
    class Dashboard
    {
        IWebDriver driver;

        [SetUp]
        public void InitializeDriver()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Manage().Window.Maximize();
        }


        [Test]
        public void HeaderImageDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement headerimage = driver.FindElement(By.CssSelector("#header > a > img"));

            Assert.IsTrue(headerimage.Displayed);
        }


        [Test]
        public void HomeHeaderLink()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement homeLinkElement = driver.FindElement(By.CssSelector("#navHeader > a:nth-child(1)"));

            Assert.IsTrue(homeLinkElement.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html", homeLinkElement.GetAttribute("href"));

        }

        [Test]
        public void WikiPageHeaderLink()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement wikiLinkElement = driver.FindElement(By.CssSelector("#navHeader > a:nth-child(2)"));

            Assert.IsTrue(wikiLinkElement.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/wikipage.html", wikiLinkElement.GetAttribute("href"));
        }


        [Test]
        public void DashboardTitle()
        {

            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            //Assert.True(driver.Title.Equals("Dashboard page"));

            Assert.AreEqual("Dashboard page", driver.Title);

        }


        [Test]
        public void PageHeaderCorrect()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement header1 = driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("Dashboard page", header1.Text);
        }

        [Test]
        public void EditFirstName()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement firstName = driver.FindElement(By.CssSelector("#firstname"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            firstName.Clear();

            firstName.SendKeys("Sergiu");

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));
                        
            Assert.AreEqual("Details saved",detailsSavedMessage.Text);

            Assert.AreEqual("Sergiu", firstName.GetAttribute("value"));
        }


        [Test]
        public void EditLastName()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement lastName = driver.FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            lastName.Clear();

            lastName.SendKeys("Soptirean");

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));

            Assert.AreEqual("Details saved", detailsSavedMessage.Text);

            Assert.AreEqual("Soptirean", lastName.GetAttribute("value"));
        }


        [Test]
        public void EditFemaleRadioButton()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement femaleButton = driver.FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[4]"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (femaleButton.Selected == false)
            {
                femaleButton.Click();
            }

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));

            Assert.AreEqual("Details saved", detailsSavedMessage.Text);

            Assert.True(femaleButton.Selected);
        }


        [Test]
        public void EditMaleRadioButton()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement maleButton = driver.FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[3]"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (maleButton.Selected == false)
            {
                maleButton.Click();
            }

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));

            Assert.AreEqual("Details saved", detailsSavedMessage.Text);

            Assert.True(maleButton.Selected);
        }


        [Test]
        public void EditBikeCheckButton()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement bikeButton = driver.FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[5]"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (bikeButton.Selected == false)
            {
                bikeButton.Click();
            }

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));

            Assert.AreEqual("Details saved", detailsSavedMessage.Text);

            Assert.True(bikeButton.Selected);
        }

        [Test]
        public void EditCarCheckButton()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement carButton = driver.FindElement(By.XPath("//*[@id=\"myDiv\"]/form/input[6]"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (carButton.Selected == false)
            {
                carButton.Click();
            }

            //click save
            driver.FindElement(By.XPath("//*[@id=\"SaveDetails\"]")).Click();

            IWebElement detailsSavedMessage = driver.FindElement(By.XPath("//*[@id=\"detailsSavedMessage\"]"));

            Assert.AreEqual("Details saved", detailsSavedMessage.Text);

            Assert.True(carButton.Selected);
        }


        [Test]
        public void UserLogout()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement logoutButton = driver.FindElement(By.XPath("//*[@id=\"Logout\"]"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            logoutButton.Click();

            Assert.AreEqual("Home page", driver.Title);
        }


        [Test]
        public void HomeFooterLinkDisplayedDashboard()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement homeFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[1]/a"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Assert.IsTrue(homeFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html", homeFooter.GetAttribute("href"));
        }


        [Test]
        public void WikiFooterLinkDisplayedDashboard()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            IWebElement wikiFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[2]/a"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Assert.IsTrue(wikiFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/wikipage.html", wikiFooter.GetAttribute("href"));
        }


        [Test]
        public void ContactFooterLinkDisplayedDashboard()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement contactFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[3]/a"));
                        
            Assert.IsTrue(contactFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/dashboardpage.html#", contactFooter.GetAttribute("href"));
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
