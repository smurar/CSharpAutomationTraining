using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Pages
{
    public class DashboardPage
    {
        public IWebDriver Driver;
      
        private IWebElement HeaderWikiLink => Driver.FindElement(By.XPath("//div[@id='header']/a"));
        private IWebElement HeaderWikiImg => Driver.FindElement(By.XPath("//div[@id='header']/a/img"));
        private IWebElement MyHomeLink => Driver.FindElement(By.XPath("//ul[@id='navHeader']/a[1]"));
        private IWebElement MyWikiLink => Driver.FindElement(By.XPath("//ul[@id='navHeader']/a[2]"));
        private IWebElement PageTitle => Driver.FindElement(By.TagName("title"));
        private IWebElement HeadingTitle => Driver.FindElement(By.TagName("h1"));
        private IWebElement FooterHomeLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[1]/a"));
        private IWebElement FooterWikiLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[2]/a"));
        private IWebElement FooterContactLink => Driver.FindElement(By.XPath("//ul[@id='nav']/li[3]/a"));
        private IWebElement MyDiv => Driver.FindElement(By.Id("myDiv']"));
        private IWebElement DetailsSaved => Driver.FindElement(By.XPath("//p[@id='detailsSavedMessage']"));
        private IWebElement FirstName => Driver.FindElement(By.XPath("//input[@id='firstname']"));
        private IWebElement LastName => Driver.FindElement(By.XPath("//div[@id='myDiv']/form/input[2]"));
        private IWebElement Female => Driver.FindElement(By.XPath("//input[@value='female']"));
        private IWebElement Male => Driver.FindElement(By.XPath("//input[@value='male']"));
        private IWebElement Vehicle1 => Driver.FindElement(By.XPath("//input[@value='Bike']"));
        private IWebElement Vehicle2 => Driver.FindElement(By.XPath("//input[@value='Car']"));
        private IWebElement Birthday => Driver.FindElement(By.XPath("//input[@type='date']"));
        private IWebElement UploadFile => Driver.FindElement(By.XPath("//input[@type='file']"));
        private IWebElement SaveButton => Driver.FindElement(By.XPath("//button[@id='SaveDetails']"));
        private IWebElement LogoutButton => Driver.FindElement(By.Id("Logout"));

        public DashboardPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public DashboardPage Wait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("firstname")));
            return this;
        }

        public DashboardPage CheckDashboardTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking page title");
            Assert.True(Driver.Title.Equals(ExpectedTitle));
            return this;
        }

        public DashboardPage CheckHeadingTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking heading title");
            Assert.True(HeadingTitle.Text.Equals(ExpectedTitle));
            return this;
        }

        public DashboardPage CheckHeaderLinks()
        {
            Reporter.LogInfo("Checking page header links");
            Assert.True(HeaderWikiLink.Displayed);
            Assert.True(HeaderWikiImg.Displayed);
            Assert.True(MyHomeLink.Displayed);
            Assert.True(MyWikiLink.Displayed);          
            return this;
        }

        public DashboardPage CheckFooterLinks(string Home, string Wiki, string Contact)
        {
            Reporter.LogInfo("Checking page footer links");
            Assert.True(FooterHomeLink.Displayed);
            Assert.True(FooterWikiLink.Displayed);
            Assert.True(FooterContactLink.Displayed);
            Assert.True(FooterHomeLink.Text.Equals(Home));
            Assert.True(FooterWikiLink.Text.Equals(Wiki));
            Assert.True(FooterContactLink.Text.Equals(Contact));
            return this;
        }

        public DashboardPage FillInName(string First, string Element1, string Last, string Element2)
        {
            FirstName.SendText(First, Element1);
            LastName.SendText(Last, Element2);
            return this;
        }

        public DashboardPage SelectGender(string Gender)
        {
            Reporter.LogInfo("Selecting gender");
            if (Gender == Male.GetAttribute("value"))
            {
                Male.ClickIt("Radio button");
            } else
            {
                Female.ClickIt("Radio button");
            }
            return this;
        }

        public DashboardPage SelectBirthDate(string Date, string Element)
        {
            Birthday.SendText(Date, Element);
            return this;
        }

        public DashboardPage SelectVehicle(string vehicle)
        {
            Reporter.LogInfo("Selecting vehicle");
            Vehicle1.ClickIt(vehicle);
            return this;
        }

        public DashboardPage ClickSave()
        {
            SaveButton.ClickIt("Save button");
            Assert.True(DetailsSaved.Displayed);
            Reporter.LogScreenshot("Details Saved screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        public HomePage Logout()
        {
            LogoutButton.ClickIt("Logout button");
            Reporter.LogScreenshot("Logged out screenshot", ImageHelper.CaptureScreen(Driver));
            return new HomePage(Driver);
        }
        
    }
}
