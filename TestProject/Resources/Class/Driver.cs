using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;


namespace TestProject.Resources.Class
{
    public class Driver
    {
        public static IWebDriver DriverInstance { get; set; }
        private static string chromeHeadless = Helpers.GetValueFromAppConfig("ChromeHeadless");

        public static void ConfigureDriver()
        {
            switch (Helpers.GetBrowserType("BrowserType"))
            {
                case "Chrome":
                    if (chromeHeadless.Equals("Y"))
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--headless");
                        chromeOptions.AddArguments("--start-maximized");
                        DriverInstance = new ChromeDriver(Paths.Driver, chromeOptions);
                    }
                    else
                        DriverInstance = new ChromeDriver(Paths.Driver);
                    break;
                case "Firefox":
                    DriverInstance = new FirefoxDriver(Paths.Driver);
                    break;
                case "Edge":
                    DriverInstance = new EdgeDriver(Paths.Driver);
                    break;
            }
            DriverInstance.Manage().Window.Maximize();
            DriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
        }
    }
}
