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
using System.Threading;
using Course01.Course02;

namespace Course01
{
    public class TestsClass : TestBase
    {
        [Test]
        public void FirstTest()
        {
            GoToHomePage().CheckPageTitle("Home page").FillInEmail(Resource.Email).FillInPassword(Resource.Password);

        }

        [Test]
        public void HeaderLinksAndImageDisplayedHomePageTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            Assert.AreEqual(true, driver.FindElement(By.XPath("//a/img")).Displayed);
            Assert.AreEqual(true, driver.FindElement(By.XPath("//ul[@id='navHeader']")).Displayed);
            driver.Quit(); //quits the drive 
        }

        [Test]
        public void HomePageTitleIsCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            Assert.True(driver.Title.Equals("Home page"));
            driver.Quit(); //quits the drive 

        }

        [Test]
        public void HomePageH1TitleIsCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            //Assert.AreEqual(driver.FindElement(By.XPath("//h1[contains(text(),'HTML')]")), "HTML");
            Assert.IsTrue(driver.FindElement(By.XPath("//h1[contains(text(),'HTML')]")).Text.Contains("HTML"));

            //Assert.IsTrue(driver.FindElement(By.XPath("//h1[contains(text(),'HTML')]").Equals("HTML");

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void DefaultValuesAreDisplayedAndCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            Assert.AreEqual(true, driver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")).Displayed);
            Assert.AreEqual(true, driver.FindElement(By.XPath("//b/p[contains(text(),'Default password: 111111')]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")).Text.Contains("Default email: admin@domain.org"));
            Assert.IsTrue(driver.FindElement(By.XPath("//b/p[contains(text(),'Default password: 111111')]")).Text.Contains("Default password: 111111"));

            driver.Quit(); //quits the drive 
        }


        [Test]
        public void LoginFieldsDisplayedTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            Assert.AreEqual(true, driver.FindElement(By.Id("email")).Displayed);
            Assert.AreEqual(true, driver.FindElement(By.Id("password")).Displayed);
            driver.Quit(); //quits the drive 
        }

        [Test]
        public void ErrorMessageVerifyNoCredentialsTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("emailErrorText")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("emailErrorText")).Text.Contains("Email address can't be null"));
            driver.Quit(); //quits the drive 
        }

        [Test]
        public void ErrorMessageVerifyWrongEmailFormatTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("Hasiubogdan2.gmail.com");
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("emailErrorText")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("emailErrorText")).Text.Contains("Email address format is not valid"));
            driver.Quit(); //quits the drive 
        }

        [Test]
        public void ErrorMessageVerifyInvalidPasswordTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("Hasiubogdan2.gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("asas");
            driver.FindElement(By.Id("Login")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("passwordErrorText")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("passwordErrorText")).Text.Contains("Invalid password/email"));
            driver.Quit(); //quits the drive 
        }


        [Test]
        public void LoginValidCredentialsTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void NavigateToWikiPage()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.FindElement(By.XPath("//a[@href='wikipage.html'][@style='padding-left:5em'][contains(text(),'WikiPage')]")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Wiki page"));

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void WikiFootersDisplayedTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.FindElement(By.XPath("//a[@href='wikipage.html'][@style='padding-left:5em'][contains(text(),'WikiPage')]")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Wiki page"));
            Assert.AreEqual(true, driver.FindElement(By.Id("nav")).Displayed);

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void HeaderLinksAndImageDisplayedDashboardPageTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual(true, driver.FindElement(By.XPath("//a[@href='wikipage.html'][@style='padding-left:5em'][contains(text(),'WikiPage')]")).Displayed);
            Assert.AreEqual(true, driver.FindElement(By.XPath("//a[@href='homepage.html'][@style='padding-left:5em'][contains(text(),'Home')]")).Displayed);
            driver.Quit(); //quits the drive 
        }

        [Test]
        public void DashboardPageTitleIsCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void DashboardPageTitleH1IsCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));
            Assert.IsTrue(driver.FindElement(By.XPath("//h1[contains(text(),'Dashboard page')]")).Text.Contains("Dashboard page"));


            driver.Quit(); //quits the drive 
        }

        [Test]
        public void DashboardPageEditPersonalInfoTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));
            Assert.IsTrue(driver.FindElement(By.XPath("//h1[contains(text(),'Dashboard page')]")).Text.Contains("Dashboard page"));
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.XPath("//input[2]")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys("Bogdan");
            driver.FindElement(By.XPath("//input[2]")).SendKeys("Hasiu");
            driver.FindElement(By.XPath("//form/input[@name='vehicle1']")).Click();
            driver.FindElement(By.XPath("//form/input[@type='date'][@name='bday']")).SendKeys("31051994");
            driver.FindElement(By.Id("SaveDetails")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(driver.FindElement(By.Id("detailsSavedMessage")).Text.Contains("Details saved"));

           

            driver.Quit(); //quits the drive 
        }

        [Test]
        public void LogOutTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = @"file:///D:/Pages%20Training%20Advanced%20Automation/Pages/homepage.html";
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/dashboardpage.html -- DashboardPage
            //file:///C:/Users/bhasiu/AppData/Local/Temp/Temp1_Pages.zip/Pages/wikipage.html -- WikiPAge
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.Title.Equals("Dashboard page"));
            Assert.IsTrue(driver.FindElement(By.XPath("//h1[contains(text(),'Dashboard page')]")).Text.Contains("Dashboard page"));
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.XPath("//input[2]")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys("Bogdan");
            driver.FindElement(By.XPath("//input[2]")).SendKeys("Hasiu");
            driver.FindElement(By.XPath("//form/input[@name='vehicle1']")).Click();
            driver.FindElement(By.XPath("//form/input[@type='date'][@name='bday']")).SendKeys("31051994");
            driver.FindElement(By.Id("SaveDetails")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(driver.FindElement(By.Id("detailsSavedMessage")).Text.Contains("Details saved"));
            driver.FindElement(By.Id("Logout")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true, driver.FindElement(By.Id("nav")).Displayed);



            driver.Quit(); //quits the drive 
        }
    }
}
