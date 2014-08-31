
namespace CustomPriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
