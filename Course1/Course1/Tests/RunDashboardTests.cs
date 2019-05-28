using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Course1.Tests
{
    [TestFixture]
    public class RunDashboardTests
    {
        [Test]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            if (driver.FindElement(By.LinkText("Home")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'Home' link is displayed.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.LinkText("WikiPage")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'WikiPage' link is displayed.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.XPath("//div[@id='header']//img")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check image is displayed.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void PageTitleIsCorrectLinkTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.Quit(); //quits the drive
        }

        [Test]
        public void PageHeadingTitleH1IsCorrectTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();

            if (driver.FindElement(By.XPath("//h1[text()='Dashboard page']")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'Dashboard page' h1 header is displayed.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void UserEditInfoTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));

            Thread.Sleep(3000); //will be replaced with wait method

            driver.FindElement(By.XPath("//form//input[@id='firstname']")).SendKeys("Mihai");
            driver.FindElement(By.XPath("//input[@value='David']")).SendKeys("Cuciureanu");
            driver.FindElement(By.XPath("//input[@value='female']")).Click();
            driver.FindElement(By.XPath("//input[@value='Bike']")).Click();
            driver.FindElement(By.XPath("//input[@value='Car']")).Click();
            driver.FindElement(By.Id("SaveDetails")).Click();

            driver.Quit(); //quits the drive
        }

        [Test]
        public void LogoutTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));
            Thread.Sleep(3000);//will be replaced with wait method
            driver.FindElement(By.XPath("//button[@id='Logout']")).Click();
            Assert.True(driver.Title.Equals("Home page"));

            driver.Quit(); //quits the drive
        }

        [Test]
        public void FooterLinksAreCorrectDisplayedTest()
        {
            bool isTextDisplayed = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.XPath("//a[text()='Home']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Home' footer link is displayed.", isTextDisplayed);

            isTextDisplayed = false;
            if (driver.FindElement(By.XPath("//a[text()='WikiPage']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Wiki Page' footer link is displayed.", isTextDisplayed);

            isTextDisplayed = false;
            if (driver.FindElement(By.XPath("//a[text()='Contact (NA)']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Contact (NA)' footer link is displayed.", isTextDisplayed);

            driver.Quit(); //quits the drive
        }
    }
}