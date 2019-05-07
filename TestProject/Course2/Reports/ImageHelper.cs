using OpenQA.Selenium;
using TestProject.Course2.Base;
using TestProject.Course2.Resources.Class;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course2.Reports
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
