using Course2.Reports;
using OpenQA.Selenium;
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
    }
}
