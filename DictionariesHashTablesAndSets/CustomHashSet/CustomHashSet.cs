namespace CustomHashSet
{
    using CustomHashTable;

    public class CustomHashSet<T>
    {
        private readonly CustomHashTable<int, T> hashTable;

        public CustomHashSet()
        {
            this.hashTable = new CustomHashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Add(T item)
        {
            int itemKey = item.GetHashCode();
            var foundKey = this.hashTable.Find(itemKey);

            if (foundKey == null)
            {
                this.hashTable.Add(itemKey, item);
            }
        }

        public T Find(T item)
        {
            int itemKey = item.GetHashCode();
            var foundKey = this.hashTable.Find(itemKey);

            return foundKey;
        }

        public void Remove(T item)
        {
            int itemKey = item.GetHashCode();
            this.hashTable.Remove(itemKey);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }
    }
}