using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{   /// <summary>
    /// Web Element extension Class for reporting
    /// </summary>
    public static class WebElementExtensions
    {   /// <summary>
        /// Extends Webdriver Click() to send webelement and element name so it is logged by reporter.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementName"></param>
        public static void Click(this IWebElement element, string elementName)
        {
            ReporterBDD.LogInfo("Click element: " + elementName);
            element.Click();
        }

        /// <summary>
        /// Extends Webdriver SendKeys() to send webelement and element name so it is logged by reporter.
        /// </summary>
        /// <param name="element">web element used</param>
        /// <param name="textToWrite">text to be written as info</param>
        /// <param name="elementName">element name to be written as info</param>
        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        {
            ReporterBDD.LogInfo("Write text '" + textToWrite + "' to element: " + elementName);
            element.SendKeys(textToWrite);
        }
    }
}
