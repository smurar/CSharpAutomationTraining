using Course2.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course2.BrowserFactory
{
  class  Browser
    {
       // private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        private static IWebDriver Driver=null;

        public static IWebDriver GetDriver()
        {

            return Driver;
        }

        public static void InitBrowser(string browserName)
        {
           // Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
            switch (browserName)
             {

                case "ChromeHeadless":
                    {
                        if (Driver == null)
                        {
                            Reporter.LogInfo("Starting Chrome browser in headless mode");
                            ChromeOptions chromeOptions = new ChromeOptions(); chromeOptions.AddArguments("--headless"); chromeOptions.AddArguments("--start-maximized");
                            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers", chromeOptions);
                            //  Drivers.Add("Chrome", Driver);
                        }
                        break;
                    }
                case "FF":
                    {
                        if (Driver==null)
                        {
                            Reporter.LogInfo("Starting Firefox browser");
                            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
                            Driver = new FirefoxDriver(service);
                            
                        }
                        break;
                    }

                case "ME":
                    {
                        if (Driver == null)
                        {
                            Reporter.LogInfo("Starting Microsoft Edge browser");
                            // Driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
                            Driver = new EdgeDriver();
                        }
                        break;
                    }

                default:
                    {
                        if (Driver == null)
                        {
                            Reporter.LogInfo("Starting Chrome browser");
                            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
                            //  Drivers.Add("Chrome", Driver);
                        }
                        break;
                    }
             }
            
        }

        public static void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            Driver.Quit();
            if (Driver != null)
            {
                Driver = null;
            }
            
        }
    }
}
