using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class HomePageTests
    {
        [Test]
        public void HomePage_Header_LinksImage()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='header']/a/img")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='Home']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']")).Displayed);

            driver.Quit();
        }

        [Test]
        public void HomePage_Title()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            Assert.IsTrue("Home page".Equals(driver.Title));

            driver.Quit();
        }

        [Test]
        public void HomePage_HeadingTitleH1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            Assert.AreEqual("HTML", (driver.FindElement(By.XPath("//html/body/h1"))).Text);

            driver.Quit();

        }

        [Test]
        public void HomePage_Default_Email_Password()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";


            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/b/p[1]")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/b/p[1]")).Text.Contains("admin@domain.org"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/b/p[2]")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/b/p[2]")).Text.Contains("111111"));
            });

            driver.Quit();
        }

        [Test]
        public void HomePage_LoginFields()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            Assert.IsTrue(driver.FindElement(By.Id("email")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("password")).Displayed);

            driver.Quit();
        }

        [Test]
        public void HomePage_NoLoginData_ErrorMSG()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("Login")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("emailErrorText")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("emailErrorText")).Text.Contains("Email address can't be null"));

            driver.Quit();
        }

        [Test]
        public void HomePage_InvalidEmail_Password_ValidationMsg()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admindomain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("emailErrorText")).Displayed);
            Assert.AreEqual("Email address format is not valid", driver.FindElement(By.Id("emailErrorText")).Text);
            Assert.AreEqual("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text);

            Thread.Sleep(3000);

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("11111");
            driver.FindElement(By.Id("Login")).Click();

            Thread.Sleep(3000);

            Assert.IsFalse(driver.FindElement(By.Id("emailErrorText")).Displayed);
            Assert.AreEqual("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text);

            driver.Quit();
        }

        [Test]
        public void HomePage_ValidLogin()
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
        public void Homepage_GoTOWikiPage()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            driver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']")).Click();

            Assert.AreEqual("Wiki page", driver.Title);

            driver.Quit();
        }

        [Test]
        public void HomePage_FooterLinks()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[1]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[2]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='nav']/li[3]")).Displayed);

            driver.Quit();
        }


    }
}
