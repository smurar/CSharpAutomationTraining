using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Course1
{
    [TestFixture]
    public class MyFirstTest
    {
        [Test]
        public void FirstNunitTest()
        {
            Assert.True(true);
        }

        [Test]
        public void FirstSeleniumTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/homepage.html";
            //e.g. driver.Url = "file:///D:/homepage.html";
            Assert.True(driver.Title.Equals("Home page"));
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("Login")).Click();
            driver.Quit(); //quits the drive
        }
    }
}
