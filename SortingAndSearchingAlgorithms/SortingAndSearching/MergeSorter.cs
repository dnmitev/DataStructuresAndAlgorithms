namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            IList<T> sortedCollection = this.MergeSort(collection);

            collection.Clear();
            foreach (T item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static void AppendListWhileMerge(IList<T> merging, IList<T> merged) //method to append lists after merging
        {
            merged.Add(merging[0]);
            merging.RemoveAt(0);
        }

        private static IList<T> Merge(IList<T> left, IList<T> right) // method to merge the current list
        {
            // generate new list to store the merged lists
            List<T> merged = new List<T>();

            // compare the values of the list and merge them into a single list called merged
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) < 0)
                    {
                        AppendListWhileMerge(left, merged);
                    }
                    else
                    {
                        AppendListWhileMerge(right, merged);
                    }
                }
                else if (left.Count > 0)
                {
                    AppendListWhileMerge(left, merged);
                }
                else if (right.Count > 0)
                {
                    AppendListWhileMerge(right, merged);
                }
            }

            return merged;
        }
    }
}
