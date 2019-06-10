using Course2.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.PageObjects
{
    class WindowsHandlingHomePage
    {
        private IWebDriver WebDriver;
        private IWebElement WindowsFrameLink => WebDriver.FindElement(By.XPath("//*[@href='frame_parent.html']"));

        public WindowsHandlingHomePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public WindowsFramePage ClickWindowsFrameLink()
        {
            WindowsFrameLink.Click("Window+Frame link");
            return new WindowsFramePage(WebDriver);
        }
    }

   
}
