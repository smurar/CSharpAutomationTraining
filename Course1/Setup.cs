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
    class Setup
    {

        public IWebDriver driver;
        public string homePage = "file:///D:/Workspace/csharp_automation/CSharpAutomationTraining/Pages/homepage.html";

        public IWebDriver Initialize()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = homePage;
            return driver;
        }

        public IWebDriver Login()
        {
            Initialize();
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            return driver;
        }

    }
}
