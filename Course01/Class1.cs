using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace Course01
{
    public class Class1
    {
        [Test]
        public void FirstTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/homepage.html"; 
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            Assert.True(driver.Title.Equals("Home page"));
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("Login")).Click();
            driver.Quit(); //quits the drive 
        }
    }
}
