using Course2.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Utils
{

    public static class Extensions
    {
        public static void Click(this IWebElement element, string elementName)
        {
            Reporter.LogInfo("Click elemet: " + elementName);
            element.Click();
        }
        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        {
            
            Reporter.LogInfo("Write text '" + textToWrite + "' to elemet: " + elementName);
            element.Clear();
            element.SendKeys(textToWrite);
        }

        public static void WaitForCompleteLoading(IWebDriver driver)
        {
            Reporter.LogInfo("Wait until the page is loaded");
            while (true)
            {
                if (!driver.FindElement(By.Id("loader")).Displayed)
                {
                    break;
                }
            }
            Reporter.LogInfo("The page is loaded");
        }

        public static void SelectCheckBox(IWebElement element,string elementName)
        {
            Reporter.LogInfo("Select " + elementName + " check box");
            if (!element.Selected)
            {
                element.Click();
            }
            else { Reporter.LogInfo(elementName + " check box was already selected"); }
        }
        public static void WaitElementToBeDisplayed(this IWebDriver driver, IWebElement element, bool isDisplayed, string elementName, int timeout = 30)
        {
            Reporter.LogInfo(string.Format("Wait element '{0}' to be displayed: {1}", elementName, isDisplayed));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            if (isDisplayed)
            {
                wait.Until(x => element.Displayed);
            }
            else {
                wait.Until(x => !element.Displayed);
            }
        }
    }
}
