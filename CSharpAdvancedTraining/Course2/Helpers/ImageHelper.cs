using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace CSharpAdvancedTraining.Course2.Helpers
{
	public class ImageHelper
	{
		/// <summary>
		/// Capture a screenshot of the open page
		/// </summary>
		/// <param name="driver"></param>
		/// <returns></returns>
		public static string CaptureScreen(IWebDriver driver)
		{
			Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
			string imageName = DateTime.Now.ToString("yyyyMMdd-hhmmss");
			string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\images\\";

			System.IO.Directory.CreateDirectory(directoryPath);

			string imagePath = directoryPath + imageName + ".jpeg";
			ss.SaveAsFile(imagePath, ScreenshotImageFormat.Jpeg);
			return imagePath;
		}
	}
}
