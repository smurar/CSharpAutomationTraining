using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace TestProject.Resources.Class
{
    public static class Driver
    {
        public static IWebDriver DriverInstance { get; set; }

        public static void ConfigureDriver()
        {
            switch (Helpers.GetBrowserType("BrowserType"))
            {
                case "Chrome":
                    DriverInstance = new ChromeDriver(Paths.Driver);
                    break;

                case "Firefox":
                    DriverInstance = new FirefoxDriver(Paths.Driver);
                    break;
            }
            DriverInstance.Manage().Window.Maximize();
            DriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
    }
}
