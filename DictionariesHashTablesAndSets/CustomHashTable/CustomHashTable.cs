namespace CustomHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomHashTable<K, V>
    {
        private const int InitialCapacity = 16;
        private const double CapacityFactor = 0.75;
        private const int GrowStep = 2;

        private LinkedList<KeyValuePair<K, V>>[] values;

        public CustomHashTable()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public LinkedList<KeyValuePair<K, V>> this[int index]
        {
            get
            {
                return this.values[index];
            }
        }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();

                foreach (var item in this.values)
                {
                    if (item != null)
                    {
                        foreach (var pair in item)
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public void Add(K key, V value)
        {
            var hash = this.GetHash(key);

            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            int limitCapacity = (int)(CapacityFactor * this.Capacity);
            if (this.Count >= limitCapacity)
            {
                this.Resize();
            }
        }

        public bool ContainsKey(K key)
        {
            var hash = this.GetHash(key);

            if (this.values[hash] == null)
            {
                return false;
            }

            var pairs = this.values[hash];
            var output = pairs.Any(p => p.Key.Equals(key));

            return output;
        }

        public V Find(K key)
        {
            var hash = this.GetHash(key);
            var list = this.values[hash];

            if (list != null)
            {
                foreach (var pair in list)
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            return default(V);
        }

        public void Remove(K key)
        {
            var hash = this.GetHash(key);
            var list = this.values[hash];

            if (list != null)
            {
                foreach (var pair in list)
                {
                    if (pair.Key.Equals(key))
                    {
                        list.Remove(pair);
                        this.Count--;
                        break;
                    }
                }
            }
        }

        public void Clear()
        {
            foreach (var item in this.values)
            {
                if (item != null)
                {
                    item.Clear();
                }
            }

            this.Count = 0;
        }

        private int GetHash(K key)
        {
            var hash = key.GetHashCode();
            var position = hash % this.values.Length;

            return Math.Abs(position);
        }

        private void Resize()
        {
            var cached = this.values;

            this.values = new LinkedList<KeyValuePair<K, V>>[GrowStep * this.Capacity];

            this.Count = 0;
            foreach (var valueCollection in cached)
            {
                if (valueCollection != null)
                {
                    foreach (var pair in valueCollection)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}