using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    
    public static class WebElementExtensions
    {

        public static void ClickIt(this IWebElement element, string elementName)
        {
            Reporter.LogInfo("Clicking element: " + elementName);
            element.Click();    
        }

        public static void SendText(this IWebElement element, string textToWrite, string elementName)
        {
            Reporter.LogInfo("Clearing field: " + elementName);
            element.Clear();
            Reporter.LogInfo("Write text '" + textToWrite + "' to element: " + elementName);
            element.SendKeys(textToWrite);
        }
    }
}
