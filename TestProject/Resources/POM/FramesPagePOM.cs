using OpenQA.Selenium;
using TestProject.Resources.Class;

namespace TestProject.Resources.POM
{
    public class FramesPagePOM
    {
        private IWebDriver driver;

        public FramesPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region WebElements
        public IWebElement Frame1 { get { return driver.FindElement(By.CssSelector("frame[src='frame_a.html'")); } }
        public IWebElement Frame2 { get { return driver.FindElement(By.XPath("//frame[@src = 'frame_b.html']")); } }
        public IWebElement TextArea { get { return driver.FindElement(By.Id("htmlVersion")); } }
        #endregion

        public FramesPagePOM SwitchFrame(IWebElement desiredFrame)
        {
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(desiredFrame);

            return this;
        }

        public FramesPagePOM SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();

            return this;
        }

        public FramesPagePOM WriteInsideTextArea(string text)
        {
            TextArea.SendText(text , "Text area");

            return this;
        }

    }
}
