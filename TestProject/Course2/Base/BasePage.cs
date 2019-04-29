using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using TestProject.Course2.POM;
using TestProject.Course2.Resources;

namespace TestProject.Course2.Base
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void BeforeEachTest()
        {
            Driver = new ChromeDriver(Constants.DriverPath);
        }

        [TearDown]
        public void AfterEachTest()
        {
            Driver.Quit();
        }

        public HomePagePOM GoToHomePage()
        {
            Driver.Url = System.Configuration.ConfigurationManager.AppSettings["URL"];

            return new HomePagePOM(Driver);
        }        
    }
}
