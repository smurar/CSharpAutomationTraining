using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{
    class WaitHelper
    {
        private IWebDriver driver;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementToBeDisplayed(IWebElement element, string elementName, int timeoutSeconds)
        {
            ReporterBDD.LogInfo("Wait for element" + elementName + " to be displayed");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => element.Displayed);
        }

    }
}
