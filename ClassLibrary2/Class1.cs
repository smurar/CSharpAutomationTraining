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
    public class MyFirstTest
    {
		[Test]
		public void FirstSeleniumTest()
		{
			IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +@"\Drivers");
			driver.Url = "file:///C:/Users/lgrecu/Desktop/homepage.html";
			Assert.True(driver.Title.Equals("Home page"));
			driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
			driver.FindElement(By.Id("password")).SendKeys("111111");
			driver.FindElement(By.Id("Login")).Click();
			Assert.AreEqual(driver.Title.Contains("dashboardpage"), true);
			driver.Quit();
		}
    }
}
