using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Course2.PageObjects
{
    public class WindowsFramePage
    {

        private IWebDriver WebDriver;
        private IWebElement frame1 => WebDriver.FindElement(By.XPath("//*[@src='frame_a.html']"));
        private IWebElement frame2 => WebDriver.FindElement(By.XPath("//*[@src='frame_b.html']"));
        private IWebElement textArea => WebDriver.FindElement(By.XPath("//textarea[@id='htmlVersion']"));

        public WindowsFramePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public WindowsFramePage WriteToFrame1TextArea()
        {
            IReadOnlyCollection<string> Windows = WebDriver.WindowHandles;
            WebDriver.SwitchTo().Window(Windows.ElementAt(1));
            WebDriver.SwitchTo().Frame(frame1);
            textArea.SendKeys("test");
            
            
            return this;

        }

        public WindowsFramePage SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
            return this;
        }
        public WindowsFramePage WriteToFrame2TextArea()
        {
            IReadOnlyCollection<string> Windows = WebDriver.WindowHandles;
            WebDriver.SwitchTo().Window(Windows.ElementAt(1));
           

            WebDriver.SwitchTo().Frame(frame2);
            textArea.SendKeys("test2");
            return this;

        }
    }
}