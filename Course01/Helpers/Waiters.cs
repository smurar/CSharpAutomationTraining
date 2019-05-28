using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Course02
{
    public class Waiters
    {
        private IWebDriver WebDriver;
        public Waiters(IWebDriver WebDriver)
        { this.WebDriver = WebDriver; }

        public void WaitElementToBeDisplayed(IWebElement element, string elementName, int timeOutSeconds )
        {
            Reporter.LogInfo("Wait for element : [" + elementName + "] to be visible.");
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutSeconds));

            wait.Until(WebDriver => element.Displayed);

        }
    }
}
