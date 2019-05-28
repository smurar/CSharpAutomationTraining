using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2.PageObjects
{
    public class DashboardPage: BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement HeaderImage => driver.FindElement(By.XPath("//*[@id=\"header\"]/a/img"));

        private ICollection<IWebElement> HeaderLinks => driver.FindElements(By.XPath("//*[@id=\"navHeader\"]/a"));

        private IWebElement DashboardTitle => driver.FindElement(By.CssSelector("head > title"));

        private IWebElement PageHeadingTitle => driver.FindElement(By.XPath("//html/body/h1"));

        private IWebElement FirstName => driver.FindElement(By.CssSelector("#firstname"));

        private IWebElement LastName => driver.FindElement(By.CssSelector("#myDiv > form > input:nth-child(5)"));

        private IWebElement RadioButton => driver.FindElement(By.XPath("//*[@name=\"gender\" and @value=\"female\"]"));

        private IWebElement CheckboxBike => driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[5]")));

        private IWebElement CheckboxCar => driver.FindElement(By.XPath(("//*[@id=\"myDiv\"]/form/input[6]")));

        private IWebElement BirthdayButton => driver.FindElement(By.Name("bday"));

        private IWebElement ChooseFileButton => driver.FindElement(By.Name("picture"));

        private IWebElement SaveButton => driver.FindElement(By.Id("SaveDetails"));

        private IWebElement DetailsSavedMessage => driver.FindElement(By.Id("detailsSavedMessage"));

        private ICollection<IWebElement> FooterLinks => driver.FindElements(By.XPath("//*[@id=\"nav\"]"));

        private IWebElement LogoutButton => driver.FindElement(By.Id("Logout"));
    }
}
