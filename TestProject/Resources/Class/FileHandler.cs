using NUnit.Framework;
using System.IO;
using TestProject.Resources.Resx;

namespace TestProject.Resources.Class
{
    public class FileHandler
    {
        private static readonly string fileName1 = @"\TestFile" + FileTypeResx.TXT;
        private static readonly string fileName2 = @"\TestFile2" + FileTypeResx.TXT;
        private static readonly string[] content = { "line1", "line2", "line3" };

        public static void GenerateTestFoldersAndFiles()
        {
            CreateNewFileInsideDesiredFolder(Paths.FirstLevelTestFolder, fileName1, content);
            CreateNewFileInsideDesiredFolder(Paths.SecondLevelTestFolder, fileName2, content);
        }

        public static void DeleteTestFoldersAndFiles()
        {
            DeleteFolder(Paths.SecondLevelTestFolder);
            DeleteFolder(Paths.FirstLevelTestFolder);            
        }

        private static void DeleteFolder(string directoryPath)
        {
            DeleteFiles(directoryPath);
            Assert.IsTrue(IsFolderEmpty(directoryPath));
            Directory.Delete(directoryPath);
        }

        private static void CreateNewFileInsideDesiredFolder(string directoryPath, string fileName, string[] text)
        {
            Directory.CreateDirectory(directoryPath);
            File.WriteAllLines(directoryPath + fileName, text);
            Assert.IsFalse(IsFolderEmpty(directoryPath));
        }

        private static bool IsFolderEmpty(string path)
        {
            var files = Directory.GetFiles(path);
            if (files.Length > 0) return false;
            else return true;
        }        

        private static void DeleteFiles(string path)
        {            
            foreach (var file in GetFileList(path))
            {
                if (file.Exists) file.Delete();
            }
        }

        private static FileInfo[] GetFileList(string path)
        {
            return new DirectoryInfo(path).GetFiles();
        }
    }
}
