﻿using Course01.Screens;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Course02
{
    public class DashBoardPage : Waiters
    {
        private IWebDriver WebDriver;
        public DashBoardPage(IWebDriver WebDriver)
        { this.WebDriver = WebDriver; }

        private IWebElement H1Title { get { return WebDriver.FindElement(By.XPath("//h1[contains(text(),'Dashboard page')]")); } }

        private IWebElement FirstName { get { return WebDriver.FindElement(By.Id("firstname")); } }
        private IWebElement LastName { get { return WebDriver.FindElement(By.XPath("//input[2]")); } }
        private IWebElement vehicle { get { return WebDriver.FindElement(By.XPath("//form/input[@name='vehicle1']")); } }
        private IWebElement Bday { get { return WebDriver.FindElement(By.XPath("//form/input[@type='date'][@name='bday']")); } }
        private IWebElement SaveDetailsButton { get { return WebDriver.FindElement(By.Id("SaveDetails")); } }
        private IWebElement SaveDetailsMessage { get { return WebDriver.FindElement(By.Id("detailsSavedMessage")); } }
        private IWebElement LogoutBUtton { get { return WebDriver.FindElement(By.Id("Logout")); } }
        private IWebElement DefaultEmailText { get { return WebDriver.FindElement(By.XPath("//b/p[contains(text(),'Default email: admin@domain.org')]")); } }

        public DashBoardPage CheckPageTitle(string expectedTitle)
        {
            WaitElementToBeDisplayed(WebDriver.FindElement(By.XPath("//div/p[contains(text(),'Welcome to dashboard page')]")), "Welcome To Dashboard", 10);
            Assert.True(object.Equals(WebDriver.Title, expectedTitle));
            return this;
        }

        public HomePage Logout()
        {
            LogoutBUtton.Click();
            Reporter.LogInfo("Logout button clicked");
            WaitElementToBeDisplayed(DefaultEmailText, "HomePage email field", 10);
            CheckElementIsDisplayed(WebDriver.FindElement(By.Id("nav")));

            return new HomePage(WebDriver);
        }
        public DashBoardPage EditPersonalInfoAndSave()
        {
            FirstName.Clear();
            Reporter.LogInfo("first name field cleared");
            LastName.Clear();
            Reporter.LogInfo("Last name field cleared");
            FirstName.SendKeys("Bogdan");
            Reporter.LogInfo("first name field filled");
            LastName.SendKeys("Hasiu");
            Reporter.LogInfo("last name field filled");
            vehicle.Click();
            Reporter.LogInfo("vehicle chosed");
            Bday.SendKeys("31051994");
            Reporter.LogInfo("Bday inserted");
            SaveDetailsButton.Click();
            Reporter.LogInfo("save details clicked");
            WaitElementToBeDisplayed(WebDriver.FindElement(By.Id("detailsSavedMessage")), "details saved info message", 10);
            CheckElementContainsText(WebDriver.FindElement(By.Id("detailsSavedMessage")), "Details saved");

            return this;
        }

        public DashBoardPage CheckH1Title()
        {
            Assert.IsTrue(H1Title.Text.Contains("Dashboard page"));
            return this;
        }

        public DashBoardPage CheckElementIsDisplayed(IWebElement element)
        {
            Assert.AreEqual(true, element.Displayed);
            return this;
        }

        public DashBoardPage CheckElementContainsText(IWebElement element, string TextContained)
        {
            Assert.IsTrue(element.Text.Contains(TextContained));
            return this;
        }
        public WikiPage NavigateToWiki()
        {
            WebDriver.FindElement(By.XPath("//a[@href='wikipage.html'][@style='padding-left:5em'][contains(text(),'WikiPage')]")).Click();
            WaitElementToBeDisplayed(WebDriver.FindElement(By.Id("htmlVersion")), "wiki page field", 10);
            return new WikiPage(WebDriver);
        }
    }
}
