using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

namespace TestProject.Courses.Course1
{
    class DashboardPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Driver")
            {
                Url = @"C:\Users\itancau\Desktop\Automation\Pages\homepage.html"
            };

            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            WaitForSpinnerToFinish();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        public void WaitForSpinnerToFinish()
        {
            while (driver.FindElement(By.Id("loader")).Displayed)
            {
                Thread.Sleep(50);
            }
        }

        [Test]
        public void HeaderItemsAreDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//img")).Displayed, "Header photo is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")).Displayed, "Header HomePage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")).Displayed, "Header WikiPage is not displayed");
        }

        [Test]
        public void PageTitleOk()
        {
            StringAssert.AreEqualIgnoringCase("Dashboard Page", driver.Title, "Page title is not correct");
        }

        [Test]
        public void PageHeadlingTitleOk()
        {
            StringAssert.AreEqualIgnoringCase("Dashboard page", driver.FindElement(By.XPath("//h1")).Text, "Page headling title is not correct");
        }

        [Test]
        public void EditPersonalInformationSuccesful()
        {           
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys("Iulian");
            driver.FindElement(By.XPath("//input[@value='David']")).Clear();
            driver.FindElement(By.XPath("//input[@value='David']")).SendKeys("Tancau");
            driver.FindElement(By.Name("vehicle2")).Click();
            driver.FindElement(By.Name("bday")).SendKeys("07/01/1995");              
            driver.FindElement(By.Name("picture")).SendKeys(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Photos\car.jpeg");           
            driver.FindElement(By.Id("SaveDetails")).Click();
            StringAssert.AreEqualIgnoringCase("Details saved", driver.FindElement(By.Id("detailsSavedMessage")).Text);
        }

        [Test]
        public void SuccessfulLogOut()
        {
            WaitForSpinnerToFinish();
            driver.FindElement(By.Id("Logout")).Click();
            StringAssert.AreEqualIgnoringCase("Home Page", driver.Title, "Page title is not correct");
        }

        [Test]
        public void FooterLinksAreDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")).Displayed, "Footer HomePage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")).Displayed, "Footer WikiPage link is not displayed");
            Assert.IsTrue(driver.FindElement(By.LinkText("Contact (NA)")).Displayed, "Footer Contact link is not displayed");
        }
    }
}
