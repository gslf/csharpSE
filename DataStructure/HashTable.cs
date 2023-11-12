using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// TODO: HashTable Docstring

namespace DataStructure.HashTable {

    /// <summary>
    /// An entry of the Hash Table, contain a value and a key.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Entry<TKey, TValue> 
        where TValue : IComparable<TValue> 
        where TKey : IComparable<TKey> {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    /// <summary>
    /// An hash table is a data structure that maps keys to values using 
    /// a hash function, enabling fast and efficient access to elements. 
    /// It employs a hash function to compute an index where the desired 
    /// data can be found. This facilitates quick retrieval and insertion 
    /// of data, making it a fundamental tool for optimizing search and 
    /// retrieval operations.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class HashTable<TKey, TValue>
         where TValue : IComparable<TValue>
         where TKey : IComparable<TKey> {

        private const int DEFAULT_CAPACITY = 128;
        private int _current_capacity;
        private LinkedList<Entry<TKey, TValue>>[] _content;
        public int Size { get; private set; }

        public HashTable() {
            _content = new LinkedList<Entry<TKey, TValue>>[DEFAULT_CAPACITY];
            _current_capacity = DEFAULT_CAPACITY;
        }


        /// <summary>
        /// Adds a new item to the Hash Table
        /// <param name="key">The key of the value</param>
        /// <param name="value">The value to add</param>
        /// </summary>
        public void Add(TKey key, TValue value) {
            int index = GetIndex(key);

            LinkedList<Entry<TKey, TValue>> keyList = _content[index];
            if (keyList == null) {
                keyList = new LinkedList<Entry<TKey, TValue>>();
                _content[index] = keyList;
                keyList.AddLast(new Entry<TKey, TValue> { Key = key, Value = value });
            } else {

                bool exist = false;
                foreach (Entry<TKey, TValue> entry in keyList) {

                    if(entry.Key.Equals(key)) {
                        entry.Value = value;
                        exist = true;
                        break;
                    }
                }

                if(!exist) {
                    keyList.AddLast(new Entry<TKey, TValue> { Key = key, Value = value });
                }
            }

            Size++;

            if (Size / _current_capacity > 0.75) {
                Rehash();
            }
        }

        /// <summary>
        /// Remove an item from the Hash Table
        /// <param name="key">The key of the item to remove</param>
        /// </summary>
        public void Remove(TKey key) {
            int index = GetIndex(key);

            LinkedList<Entry<TKey, TValue>> keyList = _content[index];
            if (keyList != null) {
                Entry<TKey, TValue> foundItem = null;

                foreach (Entry<TKey, TValue> entry in keyList) {
                    if (entry.Key.Equals(key)) {
                        foundItem = entry;
                        break;
                    }
                }

                if (foundItem != null) {
                    keyList.Remove(foundItem);
                    Size--;
                }
            }
        }

        /// <summary>
        /// Retrieve the value for a specific key
        /// <param name="key">The key of the item to retrieve</param>
        /// <returns>The retrieved item. If the key do not exist, this function return
        /// the default value for type "TValue".</returns>
        /// </summary>
        public TValue Get(TKey key) {
            int index = GetIndex(key);

            LinkedList<Entry<TKey, TValue>> keyList = _content[index];
            if (keyList != null) {
                foreach (Entry<TKey, TValue> entry in keyList) {
                    if (entry.Key.Equals(key)) {
                        return entry.Value;
                    }
                }
            }

            return default(TValue);
        }

        /// <summary>
        /// Check if the Hash Table contain a key
        /// <param name="key">The key to search</param>
        /// <returns>The result of the search</returns>
        /// </summary>
        public bool Contains(TKey key) {
            int index = GetIndex(key);

            LinkedList<Entry<TKey, TValue>> keyList = _content[index];
            if (keyList != null) {
                foreach (Entry<TKey, TValue> entry in keyList) {
                    if (entry.Key.Equals(key)) {
                        return true;
                    }
                }
            }

            return false;
        }

        private int GetIndex(TKey key) {
            return Math.Abs(key.GetHashCode()) % _current_capacity;
        }

        private void Rehash() {
            _current_capacity = _current_capacity * 2;
            LinkedList < Entry < TKey, TValue >> [] newTable = new LinkedList<Entry<TKey, TValue>>[_current_capacity];

            foreach (LinkedList<Entry<TKey, TValue>> entryList in _content) {
                if (entryList != null) {
                    foreach (Entry<TKey, TValue> entry in entryList) {
                        var newIndex = GetIndex(entry.Key);

                        LinkedList<Entry<TKey, TValue>> newTableList = newTable[newIndex];
                        if (newTableList == null) {
                            newTableList = new LinkedList<Entry<TKey, TValue>>();
                            newTable[newIndex] = newTableList;
                            newTableList.AddLast(new Entry<TKey, TValue> { Key = entry.Key, Value = entry.Value });

                        } else {
                            newTableList.AddLast(new Entry<TKey, TValue> { Key = entry.Key, Value = entry.Value });
                        }
                    }
                }
            }

            _content = newTable;
        }

        /// <summary>
        /// Remove all values from the Hash Table
        /// </summary>
        public void Clear() {
            _content = new LinkedList<Entry<TKey, TValue>>[DEFAULT_CAPACITY];
            _current_capacity = DEFAULT_CAPACITY;
            Size = 0;
        }

    }
}
