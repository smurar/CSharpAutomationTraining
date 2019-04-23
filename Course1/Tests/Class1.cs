using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Course1
{
    public class Class1
    {
        IWebDriver driver;

        [SetUp]
        public void beforeEach()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/Users/tfoldi/Desktop/Endava%20Trainings/CSharpAutomationtraining/Pages/homepage.html";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void afterEach()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }

        [Test]
        public void FirstNunitTest()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void FirstSeleniumTest()
        {
            Assert.True(driver.Title.Equals("Home page"));
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
        }
    }
}
