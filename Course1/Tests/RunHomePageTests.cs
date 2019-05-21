using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Course1.Tests
{
    [TestFixture]
    public class RunHomePageTests
    {
        [Test]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.LinkText("Home")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'Home' link is displayed.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.LinkText("WikiPage")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'WikiPage' link is displayed.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.XPath("//div[@id='header']//img")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check image is displayed.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void PageTitleIsCorrectLinkTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            Assert.True(driver.Title.Equals("Home page"));
            driver.Quit(); //quits the drive
        }

        [Test]
        public void PageHeadingTitleH1IsCorrectTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.XPath("//h1[text()='HTML']")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'HTML' h1 header is displayed.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void DefaultEmailAndPasswordTextIsCorrectTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.XPath("//p[text()='Default email: admin@domain.org']")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'Default email' text is displayed and contains the expected value.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.XPath("//p[text()='Default password: 111111']")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check 'Default password' text is displayed and contains the expected value.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void LoginFieldsAreDisplayedTest()
        {
            bool isElementPresent = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.Id("password")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check password field is displayed.", isElementPresent);

            isElementPresent = false;

            if (driver.FindElement(By.Id("email")) != null)
            {
                isElementPresent = true;
            }
            Assert.True(true, "Check email field is displayed.", isElementPresent);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void NoDataIsProvidedErrorMessageTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("Login")).Click();

            bool isErrorTextDisplayed = false;

            if (driver.FindElement(By.Id("emailErrorText")).Text.Equals("Email address can't be null"))
            {
                isErrorTextDisplayed = true;
            }
            Assert.True(true, "Check 'Email address can't be null' error message is displayed.", isErrorTextDisplayed);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void ErrorMessageIsDisplayedWhenArondCharacterMissesFromEmailFieldTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admindomain.test");
            driver.FindElement(By.Id("Login")).Click();

            bool isErrorTextDisplayed = false;

            if (driver.FindElement(By.Id("emailErrorText")).Text.Equals("Email address format is not valid"))
            {
                isErrorTextDisplayed = true;
            }
            Assert.True(true, "Check 'Email address format is not valid' error message is displayed.", isErrorTextDisplayed);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void ProperErrorIsDisplayedForInvalidEmailOrPasswordTest()
        {
            bool isErrorTextDisplayed = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("test@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("Login")).Click();

            if (driver.FindElement(By.Id("passwordErrorText")).Text.Equals("Invalid password/email"))
            {
                isErrorTextDisplayed = true;
            }
            Assert.True(true, "Check 'Invalid password/email' error message is displayed.", isErrorTextDisplayed);

            driver.Quit(); //quits the drive
        }

        [Test]
        public void LandingPageIsCorrectTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.Id("email")).SendKeys("admin@domain.org");
            driver.FindElement(By.Id("password")).SendKeys("111111");
            driver.FindElement(By.Id("Login")).Click();
            Assert.True(driver.Title.Equals("Dashboard page"));
            driver.Quit(); //quits the drive
        }

        [Test]
        public void UserCanNavigateToWikiPageTest()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/homepage.html";
            driver.FindElement(By.LinkText("WikiPage")).Click();
            Assert.True(driver.Title.Equals("Wiki page"));
            driver.Quit(); //quits the drive
        }

        [Test]
        public void FooterLinksAreCorrectDisplayedTest()
        {
            bool isTextDisplayed = false;
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            driver.Url = "file:///C:/homepage.html";

            if (driver.FindElement(By.XPath("//a[text()='Home']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Home' footer link is displayed.", isTextDisplayed);

            isTextDisplayed = false;
            if (driver.FindElement(By.XPath("//a[text()='WikiPage']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Wiki Page' footer link is displayed.", isTextDisplayed);

            isTextDisplayed = false;
            if (driver.FindElement(By.XPath("//a[text()='Contact (NA)']")) != null)
            {
                isTextDisplayed = true;
            }
            Assert.True(true, "Check 'Contact (NA)' footer link is displayed.", isTextDisplayed);

            driver.Quit(); //quits the drive
        }
    }
}