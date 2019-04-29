using System.IO;
using System.Reflection;
using System.Configuration;

namespace TestProject.Course2.Resources.Class
{
    public static class Paths
    {
        public static string Driver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ConfigurationManager.AppSettings["DriverPath"];      
        public static string HomePageUrl = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ConfigurationManager.AppSettings["HomePagePath"]);
        public static string CarPhoto = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ConfigurationManager.AppSettings["CarPhotoPath"]);
    }
}
