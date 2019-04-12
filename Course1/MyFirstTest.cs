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

namespace Course1
{
    [TestFixture]
    public class MyFirstTest
    {
        public IWebDriver driver;

        [Test]
        public void FirstNunitTest()
        {
            Assert.True(true);
        }
        [Test]
        public void FirstSeleniumTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///D:/Workspace/csharp_automation/CSharpAutomationTraining/Pages/homepage.html";
            Assert.True(driver.Title.Equals("Home page"));
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
        }
    }
}
