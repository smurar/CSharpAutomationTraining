using Course2.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
                case "Chrome":
                     if (Driver == null)
                     {
                         Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Drivers");
                       //  Drivers.Add("Chrome", Driver);
                     }
                     break;
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
