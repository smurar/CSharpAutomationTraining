using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Course2.POM;
using TestProject.Course2.Resources.Class;

namespace TestProject.Course2.Base
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void BeforeEachTest()
        {
            Driver = new ChromeDriver(Paths.Driver);
        }

        [TearDown]
        public void AfterEachTest()
        {
            Driver.Quit();
        }

        public HomePagePOM GoToHomePage()
        {
            Driver.Url = Paths.HomePageUrl;

            return new HomePagePOM(Driver);
        }        

        public DashboardPagePOM GoToDashboardPage()
        {
            GoToHomePage()
                .LogInSuccesful();
               
            return new DashboardPagePOM(Driver);
        }
    }
}
