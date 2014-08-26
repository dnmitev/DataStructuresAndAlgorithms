// 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files 
// matching the mask *.exe. Use the class System.IO.Directory.

namespace TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    class TraversingDirectoryDemo
    {
        static void Main()
        {
            var mainDirectory = new DirectoryInfo(TraverseDirectorySettings.Default.DirString).EnumerateDirectories("*");
            var allExeFiles = GetAllExeFiles(mainDirectory);

            Console.WriteLine(allExeFiles);
        }

        private static string GetAllExeFiles(IEnumerable<DirectoryInfo> directiories)
        {
            StringBuilder filesList = new StringBuilder();

            foreach (var dir in directiories)
            {
                try
                {
                    var files = dir.EnumerateFiles("*.exe");

                    foreach (var file in files)
                    {
                        filesList.AppendLine(file.Name);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }

            return filesList.ToString();
        }
    }
}