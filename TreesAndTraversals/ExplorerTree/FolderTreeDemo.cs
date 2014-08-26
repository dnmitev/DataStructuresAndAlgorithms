// 03. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using 
// them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates
// the sum of the file sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal.

namespace ExplorerTree
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class FolderTreeDemo
    {
        private static readonly StringBuilder output = new StringBuilder();

        private static void Main()
        {
            Console.WriteLine("Loading...");

            var mainFolder = new DirectoryInfo(ConfigurationSettings.AppSettings["Windows"]);
            var folderTree = GetFolderTree(mainFolder);
            GetFolderTree(folderTree, 0);

            StreamWriter writer = new StreamWriter(@"..\..\output.txt", false, Encoding.UTF8);

            using (writer)
            {
                writer.Write(output.ToString());
            }

            Console.WriteLine("Check main APP directory for file output.txt");
        }

        private static void GetFolderTree(Folder mainFolder, int separatorLength)
        {
            output.AppendLine(string.Format("Total file size: {0}", mainFolder.Size));

            foreach (var subfolder in mainFolder.SubFolders)
            {
                output.AppendLine(string.Format("{0}{1}", GetSeparator(separatorLength), subfolder.Name));
                GetFolderTree(subfolder, separatorLength + 1);
            }

            foreach (var file in mainFolder.Files)
            {
                output.AppendLine(string.Format("{0}{1}", GetSeparator(separatorLength), file.Name));
            }
        }

        private static Folder GetFolderTree(DirectoryInfo startFolder)
        {
            try
            {
                var currentFolder = new Folder(startFolder.Name);
                var files = startFolder.EnumerateFiles("*");

                foreach (var file in files)
                {
                    var currentFile = new File(file.Length, file.Name);

                    currentFolder.Files.Add(currentFile);
                }

                var subfolders = startFolder.EnumerateDirectories("*");

                foreach (var dir in subfolders)
                {
                    currentFolder.SubFolders.Add(GetFolderTree(dir));
                }

                return currentFolder;
            }
            catch (Exception)
            {
                return new Folder("Access not granted!");
            }
        }

        private static string GetSeparator(int length)
        {
            return new string(' ', length);
        }
    }
}