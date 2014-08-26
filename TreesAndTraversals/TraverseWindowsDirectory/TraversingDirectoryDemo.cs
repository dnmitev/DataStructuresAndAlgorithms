// 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files 
// matching the mask *.exe. Use the class System.IO.Directory.

namespace TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class TraversingDirectoryDemo
    {
        private static void Main()
        {
            // the main directory string is set in the .settings file beceause later it can be changed without 
            // rebuilding the API
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
                        filesList.AppendLine(string.Format("\t{0}", file.Name));
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // since its Windows folder some .exe files must have special permissions to be listed 
                    // and in this metter the .NET throws an exception which is handled here
                    continue;
                }
            }

            return filesList.ToString();
        }
    }
}