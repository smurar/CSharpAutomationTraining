using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{
    public static class WebElementExtensions
    {
        public static void Click(this IWebElement element, string elementName)
        {
            ReporterBDD.LogInfo("Click element: " + elementName);
            element.Click();
        }

        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        {
            ReporterBDD.LogInfo("Write text '" + textToWrite + "' to element: " + elementName);
            element.SendKeys(textToWrite);
        }
    }
}
