using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course4
{
    class FilesHandling
    {
       

        public FilesHandling CreateFolderOne(string folderOnePath)
        {
            Directory.CreateDirectory(folderOnePath);
            return this;
        }

        public FilesHandling CreateFolderTwo(string folderTwoPath)
        {
            Directory.CreateDirectory(folderTwoPath);
            return this;
        }

        public FilesHandling CreateFileOne(string fileOnePath)
        {

            var file = File.Create(fileOnePath);
            file.Close();
            return this;
        }

        public FilesHandling CreateFileTwo(string fileTwoPath)
        {
            var file=File.Create(fileTwoPath);
            file.Close();
            return this;
            
        }
        

        public FilesHandling DeleteAllFoldersAndFiles(string rootFolderPath)
        {
            Directory.Delete(rootFolderPath, true);
            return this;
        }
        

    }
}
