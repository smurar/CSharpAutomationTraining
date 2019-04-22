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

namespace Course1
{
    public class Class1
    {
        [Test]
        public void FirstNunitTest()
        {
            Assert.True(true);
        }

        [Test]
        public void PagetTitleCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";
            Assert.True(driver.Title.Equals("Home page"));

            driver.Quit();
        }

        [Test]
        public void HeaderAndImageCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            Assert.True(driver.FindElement(By.XPath("//header//a[@href='homepage.html']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//header//a[@href='wikipage.html']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//div[@id = 'header']//img")).Displayed);

            driver.Quit();
        }

        [Test]
        public void HeadingTitleCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            Assert.True(driver.FindElement(By.XPath("//h1")).Text.Equals("HTML"), "H1 text is not correct");

            driver.Quit();
        }

        [Test]
        public void DefaultEmailAndPasswordCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            Assert.True(driver.FindElement(By.XPath("//p[contains(text(),'Default email:')]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//p[contains(text(),'Default password:')]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//p[contains(text(),'Default password:')]")).Text.Contains("111111"));
            StringAssert.Contains("admin@domain.org", driver.FindElement(By.XPath("//p[contains(text(),'Default email:')]")).Text);

            driver.Quit();
        }

        [Test]
        public void LoginFieldsCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            Assert.True(driver.FindElement(By.Id("email")).Displayed);
            Assert.True(driver.FindElement(By.Id("password")).Displayed);

            driver.Quit();
        }

        [Test]
        public void EmptyEmailErrorMessageCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            driver.FindElement(By.Id("Login")).Click();
            StringAssert.Contains("Email address can't be null", driver.FindElement(By.Id("emailErrorText")).Text);

            driver.Quit();
        }

        [Test]
        public void EmailAddressFormatValidationCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("test");
            driver.FindElement(By.Id("Login")).Click();

            StringAssert.Contains("Email address format is not valid", driver.FindElement(By.Id("emailErrorText")).Text);

            driver.Quit();
        }

        [Test]
        public void IncorrectEmailOrPassowrdCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("test@test.com");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            StringAssert.Contains("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text);

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("password")).Clear();

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("aaaaa");
            driver.FindElement(By.Id("Login")).Click();

            StringAssert.Contains("Invalid password/email", driver.FindElement(By.Id("passwordErrorText")).Text);

            driver.Quit();
        }

        [Test]
        public void LoginSuccessfulCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));

            driver.Quit();
        }

        [Test]
        public void WikiPageLinkCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            driver.FindElement(By.XPath("//header//a[@href='wikipage.html']")).Click();
            Assert.True(driver.Title.Equals("Wiki page"));

            driver.Quit();
        }

        [Test]
        public void FooterLinksCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/homepage.html";

            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = 'homepage.html']")).Displayed, "Link is not displayed in footer");
            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = 'wikipage.html']")).Displayed, "Link is not displayed in footer");
            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = '#']")).Displayed, "Link is not displayed in footer");

            driver.Quit();
        }

        [Test]
        public void DashboardHeaderLinkAndImageCheckk()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";

            Assert.True(driver.FindElement(By.XPath("//header//a[@href='homepage.html']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//header//a[@href='wikipage.html']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//div[@id = 'header']//img")).Displayed);

            driver.Quit();
        }

        [Test]
        public void DashboardPagetTitleCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";
            Assert.True(driver.Title.Equals("Dashboard page"));

            driver.Quit();
        }

        [Test]
        public void DashboardHeadingTitleCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";

            Assert.True(driver.FindElement(By.XPath("//h1")).Text.Equals("Dashboard page"), "H1 text is not correct");

            driver.Quit();
        }

        [Test]
        public void DashboardLogoutCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("Logout")).Click();

            Assert.True(driver.Title.Equals("Home page"));

            driver.Quit();
        }

        [Test]
        public void DashboardFooterLinksCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = 'homepage.html']")).Displayed, "Link is not displayed in footer");
            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = 'wikipage.html']")).Displayed, "Link is not displayed in footer");
            Assert.True(driver.FindElement(By.XPath("//footer//a[@href = '#']")).Displayed, "Link is not displayed in footer");

            driver.Quit();
        }

        [Test]
        public void DashboardUserEditCheck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Automation/.NET Advance Training/Pages/dashboardpage.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("firstname")).SendKeys("Firstname Test");
            driver.FindElement(By.XPath("//form//input[2]")).SendKeys("Lastname Test");
            driver.FindElement(By.XPath("//input[@value = 'male']")).Click();
            driver.FindElement(By.Name("vehicle1")).Click();
            driver.FindElement(By.Name("vehicle2")).Click();
            driver.FindElement(By.Name("bday")).SendKeys("12/29/1989");
            driver.FindElement(By.Id("SaveDetails")).Click();

            Assert.True(driver.FindElement(By.Id("detailsSavedMessage")).Text.Equals("Details saved"), "H1 text is not correct");

            driver.FindElement(By.XPath("//input[@value = 'female']")).Click();
            driver.FindElement(By.Id("SaveDetails")).Click();

            Assert.True(driver.FindElement(By.Id("detailsSavedMessage")).Text.Equals("Details saved"), "H1 text is not correct");

            driver.Quit();
        }
    }
}
