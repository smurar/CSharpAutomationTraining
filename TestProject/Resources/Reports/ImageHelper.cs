using OpenQA.Selenium;
using TestProject.Resources.Class;
using TestProject.Resources.Resx;

namespace TestProject.Resources.Reports
{
    public static class ImageHelper 
    {        
        public static int screenshotNumber = 0;
        static string imagePath = string.Empty;

        public static string GetScreenshotPath(IWebDriver driver)
        {            
            SaveScreenshot(driver);

            return imagePath;
        }

        public static void SaveScreenshot(IWebDriver driver)
        {
            IncrementScreenshotNumber();
            SetImagePath();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(imagePath);
        }

        public static string IncrementScreenshotNumber()
        {
            screenshotNumber += 1;

            return screenshotNumber.ToString();
        }

        public static void SetImagePath()
        {
            string imageName = Helpers.GetCurrentTestName() + "_" + Templates.fileName + "_" + screenshotNumber + FileTypeResx.JPEG;
            imagePath = Paths.ScreenshotsFolder + imageName;            
        }

        public static void ResetScreenShotNumber()
        {
            screenshotNumber = 0;
        }     
    }
}
