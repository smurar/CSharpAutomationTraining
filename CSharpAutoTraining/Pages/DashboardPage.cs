using CSharpAutoTraining.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAutoTraining
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
        private IWebElement Loader => WebDriver.FindElement(By.Id("loader"));

        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public DashboardPage WaitForPageToLoad()
        {
            while (Loader.Displayed)
            {
                Thread.Sleep(1000);
            }
            return this;
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

        public DashboardPage HeaderItemVisibilityVerification()
        {
            try
            {
                Assert.IsTrue(HeaderImg.Displayed);
                Assert.IsTrue(HeaderHomePageLink.Displayed);
                Assert.IsTrue(HeaderWikiPageLink.Displayed);
            }
            catch (Exception)
            {
                Assert.Fail("Header does not contain all mandatory fields");
                Reporter.LogFail("WebElement missing");
            }
            return this;
        }

        public DashboardPage FooterItemVisibilityVerification()
        {
            try
            {
                Assert.IsTrue(FooterLinkHome.Displayed);
                Assert.IsTrue(FooterLinkWikiPage.Displayed);
                Assert.IsTrue(FooterLinkContact.Displayed);
            }
            catch (Exception)
            {
                Assert.Fail("Footer does not contain all mandatory fields");
                Reporter.LogFail("WebElement missing");
            }
            return this;
        }

        public DashboardPage EditUserInfo(string firstname, string lastname, string Gender, string birthday, bool bike = false, bool car = false)
        {
            AddUserName(firstname, lastname);
            MaleOrFemale(Gender);
            SelectBike(bike);
            SelectCar(car);
            AddBirthDate(birthday);

            return this;
        }

        public DashboardPage AddUserName(string fName, string lName)
        {
            FirstName.Clear();
            LastName.Clear();
            FirstName.SendKeys(fName);
            LastName.SendKeys(lName);
            return this;
        }

        public DashboardPage MaleOrFemale(string gender)
        {
            switch (gender)
            {
                case "Male":
                    IsMale.Click();
                    break;
                case "Female":
                    IsFemale.Click();
                    break;
            }
            return this;
        }

        public DashboardPage AddBirthDate(string birthdate)
        {
            DateTime date = Convert.ToDateTime(birthdate);
            Birthday.SendKeys(date.Day + date.Month + Keys.Tab + date.Year);
            return this;
        }

        public DashboardPage SelectBike(bool haveABike)
        {
            if (haveABike) { HaveABike.Click(); }
            return this;
        }

        public DashboardPage SelectCar(bool haveACar)
        {
            if (haveACar) { HaveACar.Click(); }
            return this;
        }

        public DashboardPage SaveConfirmationDisplayed()
        {
            Assert.IsTrue(SaveConfirmationMSG.Displayed);
            return this;
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
