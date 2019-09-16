using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement HeaderImage => driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img"));

        private ICollection<IWebElement> HeaderLinks => driver.FindElements(By.XPath("//*[@id=\"navHeader\"]/a"));

        private IWebElement DashboardTitle => driver.FindElement(By.CssSelector("head > title"));

        private IWebElement PageHeadingTitle => driver.FindElement(By.CssSelector("body > h1"));

        private IWebElement FirstName => driver.FindElement(By.CssSelector("#firstname"));

        private IWebElement LastName => driver.FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)"));

        private IWebElement FemaleRadioButton => driver.FindElement(By.XPath("//*[@name=\"gender\" and @value=\"female\"]"));

        private IWebElement CheckboxBike => driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[5]")));

        private IWebElement CheckboxCar => driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[6]")));

        private IWebElement BirthdayButton => driver.FindElement(By.Name("bday"));

        private IWebElement ChooseFileButton => driver.FindElement(By.Name("picture"));

        private IWebElement SaveButton => driver.FindElement(By.Id("SaveDetails"));

        private IWebElement DetailsSavedMessage => driver.FindElement(By.Id("detailsSavedMessage"));

        private ICollection<IWebElement> FooterLinks => driver.FindElements(By.XPath("//*[@id=\"nav\"]"));

        private IWebElement LogoutButton => driver.FindElement(By.Id("Logout"));

        public bool HeaderImageIsDisplayed()
        {
            return HeaderImage.Displayed;
        }

        public bool HeaderLinksAreAllDisplayed()
        {
            foreach (IWebElement headerLink in HeaderLinks)
            {
                if (!headerLink.Displayed)
                {
                    return false;
                }
            }

            return true;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingTitle()
        {
            return PageHeadingTitle.Text;
        }

        public BasePage FillInName(string firstName, string lastName)
        {
            FirstName.Clear();
            LastName.Clear();

            if (firstName != null)
            {
                FirstName.SendKeys("Gill");
            }

            if (lastName != null)
            {
                LastName.SendKeys("Toy");
            }

            return this;
        }

        public void RadioButtons()
        {
            FemaleRadioButton.Click();
        }

        public BasePage Checkbox(bool checkboxBike, bool checkboxCar)
        {
            if (!CheckboxBike.Selected)
            {
                CheckboxBike.Click();
            }

            if (CheckboxCar.Selected)
            {
                CheckboxCar.Click();
            }

            return this;
        }

        public void SelectBirthday()
        {
            BirthdayButton.SendKeys("11011980");
        }

        public void UploadFile()
        {
            ChooseFileButton.SendKeys(@"C:\Users\rstreja\Desktop\testpic.jpg");
        }
        
        public DashboardPage SaveForm()
        {
            SaveButton.Click();

            return this;
        }

        public String GetDetailsMessageText()
        {
            return DetailsSavedMessage.Text;
        }

        public bool FooterLinksAreDisplayed()
        {
            foreach (IWebElement footerLink in FooterLinks)
            {
                if (!footerLink.Displayed)
                {
                    return false;
                }
            }

            return true;
        }

        public string Logout()
        {
            LogoutButton.Click();
            return driver.Url;
        }

        }
}
