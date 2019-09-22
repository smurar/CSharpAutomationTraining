using Course2.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course4
{
    class FilesTest
    {
        [Test]
        public void CreateDeleteFilesAndFolders()
        {
            FilesHandling filesHandling = new FilesHandling();
            filesHandling
                .CreateFolderOne(FileHandlingData.FolderOnePath)
                .CreateFileOne(FileHandlingData.FolderOnePath + "\\" + FileHandlingData.FileOneName)
                .CreateFolderTwo(FileHandlingData.FolderOnePath + "\\" + FileHandlingData.FolderTwoName)
                .CreateFileTwo(FileHandlingData.FolderOnePath + "\\" + FileHandlingData.FolderTwoName + "\\" + FileHandlingData.FileTwoName)
                .DeleteAllFoldersAndFiles(FileHandlingData.FolderOnePath);
        }
    }
}
