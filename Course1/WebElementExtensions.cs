using Course1.Course2;
using OpenQA.Selenium;

namespace Course1
{
    public static class WebElementExtensions
    {
        public static void Click(this IWebElement element, string elementName)
        {
            Reporter.LogInfo("Click elemet: " + elementName);
            element.Click();
        }
        public static void SendKeys(this IWebElement element, string textToWrite, string elementName)
        {
            Reporter.LogInfo("Write text '" + textToWrite + "' to elemet: " + elementName);
            element.SendKeys(textToWrite);
        }
    }
}
