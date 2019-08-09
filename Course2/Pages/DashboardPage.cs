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

    /// <summary>
    /// DashboardPage page object
    /// </summary>
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

        /// <summary>
        /// Wait until the page fully loads, i.e. first name field is visible
        /// </summary>
        /// <returns>DashboardPage object</returns>
        public DashboardPage Wait()
        {
            Reporter.LogInfo("Waiting for 'first name' to be displayed");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("firstname")));
            return this;
        }

        /// <summary>
        /// Check the page title
        /// </summary>
        /// <param name="ExpectedTitle">Expected Dashboard page title</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage CheckDashboardTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking page title");
            Assert.True(Driver.Title.Equals(ExpectedTitle));
            return this;
        }

        /// <summary>
        /// Check the page heading title
        /// </summary>
        /// <param name="ExpectedTitle">Expected heading title</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage CheckHeadingTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking heading title");
            Assert.True(HeadingTitle.Text.Equals(ExpectedTitle));
            return this;
        }

        /// <summary>
        /// Check links and image in page header
        /// </summary>
        /// <returns>DashboardPage object</returns>
        public DashboardPage CheckHeaderLinks()
        {
            Reporter.LogInfo("Checking page header links");
            Assert.True(HeaderWikiLink.Displayed);
            Assert.True(HeaderWikiImg.Displayed);
            Assert.True(MyHomeLink.Displayed);
            Assert.True(MyWikiLink.Displayed);          
            return this;
        }

        /// <summary>
        /// Check footer links
        /// </summary>
        /// <returns>DashboadPage object</returns>
        public DashboardPage CheckFooterLinks()
        {
            Reporter.LogInfo("Checking page footer links");
            Assert.True(FooterHomeLink.Displayed);
            Assert.True(FooterWikiLink.Displayed);
            Assert.True(FooterContactLink.Displayed);
            Assert.True(FooterHomeLink.Text.Equals(MyResource.FooterHome));
            Assert.True(FooterWikiLink.Text.Equals(MyResource.FooterWiki));
            Assert.True(FooterContactLink.Text.Equals(MyResource.FooterContact));
            return this;
        }

        /// <summary>
        /// Write text into the name fields
        /// </summary>
        /// <param name="First">First name to be written</param>
        /// <param name="Element1">Name of the field</param>
        /// <param name="Last">Last name to be written</param>
        /// <param name="Element2">Name of the field</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage FillInName(string First, string Element1, string Last, string Element2)
        {
            FirstName.SendText(First, Element1);
            LastName.SendText(Last, Element2);
            return this;
        }

        /// <summary>
        /// Select gender
        /// </summary>
        /// <param name="Gender">Gender to be selected</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage SelectGender(string Gender)
        {
            Reporter.LogInfo("Selecting gender");
            if (Gender == Male.GetAttribute("value"))
            {
                Male.ClickIt("'" + Gender + "'" + " radio button");
            } else
            {
                Female.ClickIt("'" + Gender + "'" + " radio button");
            }
            return this;
        }

        /// <summary>
        /// Write the birthdate into the Birthdate field
        /// </summary>
        /// <param name="Date">The date to be written</param>
        /// <param name="Element">The name of the field</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage SelectBirthDate(string Date, string Element)
        {
            Birthday.SendText(Date, Element);
            return this;
        }

        /// <summary>
        /// Select the vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to be selected</param>
        /// <returns>DashboardPage object</returns>
        public DashboardPage SelectVehicle(string vehicle)
        {
            Reporter.LogInfo("Selecting vehicle");
            Vehicle1.ClickIt("'" + vehicle + "'" + " checkbox");
            return this;
        }

        /// <summary>
        /// Click the Save button
        /// </summary>
        /// <returns>DashboardPage object</returns>
        public DashboardPage ClickSave()
        {
            SaveButton.ClickIt("Save button");            
            return this;
        }

        /// <summary>
        /// Check the "Details saved" messsage
        /// </summary>
        /// <returns>DashboardPage object</returns>
        public DashboardPage CheckDetailsSavedMessage()
        {
            Reporter.LogInfo("Checkin the Details Saved message");
            Assert.True(DetailsSaved.Displayed);
            Reporter.LogScreenshot("Details Saved screenshot", ImageHelper.CaptureScreen(Driver));
            return this;
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>HomePage object</returns>
        public HomePage Logout()
        {
            LogoutButton.ClickIt("Logout button");
            Reporter.LogScreenshot("Logged out screenshot", ImageHelper.CaptureScreen(Driver));
            return new HomePage(Driver);
        }
        
    }
}
