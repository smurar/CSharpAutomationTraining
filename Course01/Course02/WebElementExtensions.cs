using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Course02
{
    public static class WebElementExtensions
    {
        public static void Click(this IWebElement element, string elementName)
        {
            Reporter.LogInfo("Click element: " + elementName);
            element.Click();
        }

        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        { Reporter.LogInfo("Write text '" + textToWrite + "' to elemet: " + elementName);
          element.SendKeys(textToWrite);
        }
    }
}
