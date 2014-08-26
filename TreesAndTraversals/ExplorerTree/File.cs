namespace ExplorerTree
{
    using System;

    internal class File : IFile
    {
        private string name;
        private long size;

        public File(long size, string name)
        {
            this.Size = size;
            this.Name = name;
        }

        public File()
            : this(0l, string.Empty)
        {
        }

        public File(string name)
            : this(0l, name)
        {
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("File size cannot be a negative number");
                }

                this.size = value;
            }
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
                    throw new ArgumentException("File name cannot be null or empty");
                }

                this.name = value;
            }
        }
    }
}