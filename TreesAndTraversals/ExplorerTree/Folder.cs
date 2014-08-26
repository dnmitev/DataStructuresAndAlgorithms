namespace ExplorerTree
{
    using System;
    using System.Collections.Generic;

    internal class Folder
    {
        private string name;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<IFile>();
            this.SubFolders = new List<Folder>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Folder name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public IList<IFile> Files { get; set; }

        public IList<Folder> SubFolders { get; set; }

        public long Size
        {
            get
            {
                long totalFolderSize = 0;

                foreach (var file in this.Files)
                {
                    totalFolderSize += file.Size;
                }

                return totalFolderSize;
            }
        }
    }
}