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

    public class Entry<TKey, TValue> 
        where TValue : IComparable<TValue> 
        where TKey : IComparable<TKey> {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

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

        public void Clear() {
            _content = new LinkedList<Entry<TKey, TValue>>[DEFAULT_CAPACITY];
            _current_capacity = DEFAULT_CAPACITY;
            Size = 0;
        }

    }
}
