using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2
{
    public static class WebElementExtensions
    {
        public static void Click(this IWebElement element, string elementName)
        {
            Reporter.LogInfo("Click element: " + elementName);
            element.Click();
        }
        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        {
            Reporter.LogInfo("Write text '" + textToWrite + "' to element: " + elementName);
            element.SendKeys(textToWrite);
        }
    }
}
