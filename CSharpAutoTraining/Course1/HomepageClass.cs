using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course1
{
    class HomepageClass
    {

        IWebDriver driver;
        
        [SetUp]
        public void InitializeDriver()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");

            driver.Manage().Window.Maximize();
        }
        

        [Test]
        public void HomepageTitle()
        {

            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            //Assert.True(driver.Title.Equals("Dashboard page"));

            Assert.AreEqual("Home page", driver.Title);

        }


        [Test]
        public void HeaderImageDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement headerimage = driver.FindElement(By.CssSelector("#header > a > img"));

            Assert.IsTrue(headerimage.Displayed);
        }


        [Test]
        public void HomeHeaderLink()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";
                    
            IWebElement homeLinkElement = driver.FindElement(By.CssSelector("#navHeader > a:nth-child(1)"));

            Assert.IsTrue(homeLinkElement.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html", homeLinkElement.GetAttribute("href"));
                        
        }


        [Test]
        public void WikiPageHeaderLink()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement wikiLinkElement = driver.FindElement(By.CssSelector("#navHeader > a:nth-child(2)"));

            Assert.IsTrue(wikiLinkElement.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/wikipage.html", wikiLinkElement.GetAttribute("href"));
        }


        [Test]
        public void PageHeaderCorrect()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement header1 = driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("HTML",header1.Text);
        }


        [Test]
        public void DefaultEmailDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement email = driver.FindElement(By.XPath("/html/body/b/p[1]"));

            Assert.IsTrue(email.Displayed);

            Assert.AreEqual("Default email: admin@domain.org", email.Text);
        }


        [Test]
        public void DefaultPasswordDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement password = driver.FindElement(By.XPath("/html/body/b/p[2]"));

            Assert.IsTrue(password.Displayed);

            Assert.AreEqual("Default password: 111111", password.Text);
        }


        [Test]
        public void LoginFieldsDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement loginfield = driver.FindElement(By.XPath("//*[@id=\"email\"]"));

            IWebElement passfield = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            Assert.IsTrue(loginfield.Displayed);

            Assert.IsTrue(passfield.Displayed);
        }


        [Test]
        public void EmailCantBeNull()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            //find and click login button
            driver.FindElement(By.XPath("//*[@id=\"Login\"]")).Click();

            IWebElement nullemailerror = driver.FindElement(By.XPath("//*[@id=\"emailErrorText\"]"));

            Assert.IsTrue(nullemailerror.Displayed);

            Assert.AreEqual("Email address can't be null", nullemailerror.Text);
            
        }


        [Test]
        public void EmailFormatNotValid()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement loginfield = driver.FindElement(By.XPath("//*[@id=\"email\"]"));

            //send invalid email format to field
            loginfield.SendKeys("asdfasdf");

            //find and click login button
            driver.FindElement(By.XPath("//*[@id=\"Login\"]")).Click();

            IWebElement emailformaterror = driver.FindElement(By.XPath("//*[@id=\"emailErrorText\"]"));

            Assert.IsTrue(emailformaterror.Displayed);

            Assert.AreEqual("Email address format is not valid", emailformaterror.Text);
        }


        [Test]
        public void InvalidCredentialsEmailSent()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement loginfield = driver.FindElement(By.XPath("//*[@id=\"email\"]"));

            IWebElement passfield = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            loginfield.SendKeys("asdf@aaa.com");

            passfield.SendKeys("111111");

            driver.FindElement(By.XPath("//*[@id=\"Login\"]")).Click();

            IWebElement invalidemailerror = driver.FindElement(By.XPath("//*[@id='passwordErrorText']"));

            Assert.IsTrue(invalidemailerror.Displayed);

            Assert.AreEqual("Invalid password/email",invalidemailerror.Text);
        }


        [Test]
        public void InvalidCredentialsPassSent()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement loginfield = driver.FindElement(By.XPath("//*[@id=\"email\"]"));

            IWebElement passfield = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            loginfield.SendKeys("admin@domain.org");

            passfield.SendKeys("333333");

            //click on login button
            driver.FindElement(By.XPath("//*[@id=\"Login\"]")).Click();

            IWebElement invalidpasserror = driver.FindElement(By.XPath("//*[@id='passwordErrorText']"));

            Assert.IsTrue(invalidpasserror.Displayed);

            Assert.AreEqual("Invalid password/email", invalidpasserror.Text);
        }


        [Test]
        public void LoginValidCredentials()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement loginfield = driver.FindElement(By.XPath("//*[@id=\"email\"]"));

            IWebElement passfield = driver.FindElement(By.XPath("//*[@id=\"password\"]"));

            loginfield.SendKeys("admin@domain.org");

            passfield.SendKeys("111111");

            //click on login button
            driver.FindElement(By.XPath("//*[@id=\"Login\"]")).Click();

            Assert.AreEqual("Dashboard page",driver.Title);
        }


        [Test]
        public void NavigateToWikiPage()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            //Click on WikiPage link
            driver.FindElement(By.CssSelector("#navHeader > a:nth-child(2)")).Click();

            Assert.AreEqual("Wiki page", driver.Title);
        }


        [Test]
        public void HomeFooterLinkDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement homeFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[1]/a"));

            Assert.IsTrue(homeFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html", homeFooter.GetAttribute("href"));
        }


        [Test]
        public void WikiFooterLinkDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement wikiFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[2]/a"));

            Assert.IsTrue(wikiFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/wikipage.html", wikiFooter.GetAttribute("href"));
        }


        [Test]
        public void ContactFooterLinkDisplayed()
        {
            driver.Url = "file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html";

            IWebElement contactFooter = driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[3]/a"));

            Assert.IsTrue(contactFooter.Displayed);

            Assert.AreEqual("file:///C:/Users/ssoptirean/Desktop/PagesTest/homepage.html#", contactFooter.GetAttribute("href"));
        }


        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }



    }
}
