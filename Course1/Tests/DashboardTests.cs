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
    class DashboardTests
    {
        [Test]
        public void HeaderLinkAndImg()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            if ("Dashboard page".Equals(driver.Title))
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='header']/a/img")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='Home']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']")).Displayed);
            }
            else
            {
                Assert.Fail("Page is not the Dashboard page");
            }

            driver.Quit();
        }

        [Test]
        public void DashBoardPageTitle()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            Assert.AreEqual("Dashboard page", driver.Title);

            driver.Quit();
        }

        [Test]
        public void DashboardPageHeading()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            if ("Dashboard page".Equals(driver.Title))
            {
                Assert.AreEqual("Dashboard page", driver.FindElement(By.XPath("//html/body/h1")).Text);
            }
            else
            {
                Assert.Fail("Page is not the Dashboard page");
            }

            driver.Quit();
        }

        [Test]
        public void EditpersonalInformation()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            Thread.Sleep(1000);
            Assert.AreEqual("Dashboard page", driver.Title);

            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys("Lola");
            driver.FindElement(By.XPath("//*[@id='myDiv']/form/input[2]")).Clear();
            driver.FindElement(By.XPath("//*[@id='myDiv']/form/input[2]")).SendKeys("Bunny");

            driver.FindElement(By.CssSelector("#myDiv>form>input[type='radio']:nth-child(10)")).Click();
            driver.FindElement(By.XPath("//*[@id='myDiv']/form/input[5]")).Click();

            driver.FindElement(By.XPath("//*[@id='myDiv']/form/input[7]")).SendKeys("12" + "NOV" + "1986");

            driver.FindElement(By.Id("SaveDetails")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("detailsSavedMessage")).Displayed);
            Assert.AreEqual("Details saved", driver.FindElement(By.Id("detailsSavedMessage")).Text);

            driver.Quit();
        }

        [Test]
        public void LogoutDashboardPage()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            Assert.AreEqual("Dashboard page", driver.Title);

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));            
            //IWebElement element = wait.Until(wdriver => driver.FindElement(By.XPath("//*[@id='Logout']")));
            Thread.Sleep(2500);
            driver.FindElement(By.XPath("//*[@id='Logout']")).Click();

            Assert.AreEqual("Home page", driver.Title);

            driver.Quit();
        }

        [Test]
        public void DashboardPage_FooterLinks()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/dashboardpage.html";

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[1]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[2]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[3]")).Displayed);

            driver.Quit();
        }
    }
}
