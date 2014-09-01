namespace BiDictionary
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, V> dict1;
        private readonly MultiDictionary<K2, V> dict2;
        private readonly MultiDictionary<int, V> dict3;

        public BiDictionary()
        {
            this.dict1 = new MultiDictionary<K1, V>(true);
            this.dict2 = new MultiDictionary<K2, V>(true);
            this.dict3 = new MultiDictionary<int, V>(true);
        }

        public void Add(K1 key1, K2 key2, V element)
        {
            this.dict1.Add(key1, element);
            this.dict2.Add(key2, element);

            var hash = this.GetDoubleKeyedHashCode(key1, key2);

            this.dict3.Add(hash, element);
        }

        public List<V> FindByFirstKey(K1 key)
        {
            return this.dict1[key].ToList();
        }

        public List<V> FindBySecondKey(K2 key)
        {
            return this.dict2[key].ToList();
        }

        public List<V> FindByBothKeys(K1 key1, K2 key2)
        {
            var hash = this.GetDoubleKeyedHashCode(key1, key2);
            return this.dict3[hash].ToList();
        }

        private int GetDoubleKeyedHashCode(K1 key1, K2 key2)
        {
            return key1.GetHashCode() ^ key2.GetHashCode();
        }
    }
}