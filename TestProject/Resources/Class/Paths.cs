
namespace TestProject.Resources.Class
{  
    public static class Paths 
    {            
        public static string Driver = Helpers.GetDirectoryPath("DriverPath");          
        public static string HomePageUrl = "file:///" + Helpers.GetFilePath("HomePagePath");     
        public static string CarPhoto = Helpers.GetFilePath("CarPhotoPath");       
        public static string ReportFilesFolder = Helpers.GetDirectoryPath("ReportFilesFolderPath");        
        public static string ScreenshotsFolder = Helpers.GetDirectoryPath("ScreenshotsFolderPath");
        public static string FirstLevelTestFolder = Helpers.GetDirectoryPath("FirstLevelTestFolder");
        public static string SecondLevelTestFolder = Helpers.GetDirectoryPath("SecondLevelTestFolder");
    }
}
