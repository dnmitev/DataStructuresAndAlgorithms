namespace ExplorerTree
{
    using System;

    public interface IFile
    {
        long Size { get; set; }

        string Name { get; set; }
    }
}