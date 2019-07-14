using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    public class DashboardPage
    {
        private IWebDriver WebDriver;
        private IWebElement HeaderImg => WebDriver.FindElement(By.XPath("//*[@id='header']/a/img"));
        private IWebElement HeaderHomePageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='Home']"));
        private IWebElement HeaderWikiPageLink => WebDriver.FindElement(By.XPath("//*[@id='navHeader']//*[text()='WikiPage']"));
        private IWebElement DashboardPageH1Title => WebDriver.FindElement(By.XPath("//html/body/h1"));
        private IWebElement FirstName => WebDriver.FindElement(By.Id("firstname"));
        private IWebElement LastName => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[2]"));
        private IWebElement IsMale => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[3]"));
        private IWebElement IsFemale => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[4]"));
        private IWebElement HaveABike => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[5]"));
        private IWebElement HaveACar => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[6]"));
        private IWebElement Birthday => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[7]"));
        private IWebElement SelectFile => WebDriver.FindElement(By.XPath("//*[@id='myDiv']/form/input[8]"));
        private IWebElement SaveButton => WebDriver.FindElement(By.Id("SaveDetails"));
        private IWebElement SaveConfirmationMSG => WebDriver.FindElement(By.Id("detailsSavedMessage"));
        private IWebElement LogoutButton => WebDriver.FindElement(By.Id("Logout"));
        private IWebElement FooterLinkHome => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[1]"));
        private IWebElement FooterLinkWikiPage => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[2]"));
        private IWebElement FooterLinkContact => WebDriver.FindElement(By.XPath("//*[@id='nav']/li[3]"));
        
        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public DashboardPage VerifyPageTitle(string expected)
        {
            Assert.IsTrue(condition: object.Equals(WebDriver.Title, expected));

            return this;
        }

        public DashboardPage VerifyH1Title(string title)
        {
            Assert.AreEqual(title, DashboardPageH1Title.Text);
            return this;
        }

        public bool HeaderItemVisibilityVerification()
        {
            if (HeaderImg.Displayed.Equals(false) ||
                HeaderHomePageLink.Displayed.Equals(false) ||
                HeaderWikiPageLink.Displayed.Equals(false))
            {
                Console.WriteLine("Header does not contain all necessary fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FooterItemVisibilityVerification()
        {
            if (FooterLinkHome.Displayed.Equals(false) ||
                FooterLinkWikiPage.Displayed.Equals(false) ||
                FooterLinkContact.Displayed.Equals(false))
            {
                Console.WriteLine("Footer does not contain all necessary fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        public DashboardPage EditUserInfo(string firstname, string lastname, bool isMale, string birthday, bool bike = false, bool car = false)
        {
            FirstName.SendKeys(firstname);
            LastName.SendKeys(lastname);
            if (!isMale)
            {
                IsFemale.Click();
            }
            if (bike)
            {
                HaveABike.Click();
            }
            if (car)
            {
                HaveACar.Click();
            }
            Birthday.SendKeys(birthday);

            return this;
        }

        public bool SaveConfirmationDisplayed()
        {
            if (SaveConfirmationMSG.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DashboardPage SavePage()
        {
            SaveButton.Click();
            return this;
        }

        public HomePage Logout()
        {
            LogoutButton.Click();
            return new HomePage(WebDriver);
        }      
        

    }
}
