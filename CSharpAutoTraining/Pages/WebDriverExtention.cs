using CSharpAutoTraining.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Pages
{
    public static class WebDriverExtention
    {
        public static void WaitElementToBeDisplayed(this IWebDriver Driver, IWebElement element, bool isDisplayed, string elementName, int timeout = 30)
        {
            Reporter.LogInfo(string.Format("Wait element '{0}' to be displayed: {1}", elementName, isDisplayed));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));

            if (isDisplayed)
            {
                wait.Until(x => element.Displayed);
            }
            else
            {
                wait.Until(x => !element.Displayed);
            }
        }

        public static void WaitElementContainsText(this IWebDriver Driver, IWebElement element, string textToCheck, string elementName, int timeout = 30)
        {
            Reporter.LogInfo(string.Format("Wait element '{0}' to contain text: {1}", elementName, textToCheck));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(x => element.Text.Contains(textToCheck));
        }
    }
}
