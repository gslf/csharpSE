using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace DataStructureTests {
    [TestClass]
    public class HashTableTest {
        [TestMethod]
        public void AddTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();

            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            Assert.AreEqual(hashTable.Get("a"), 1);
            Assert.AreEqual(hashTable.Get("b"), 2);
            Assert.AreEqual(hashTable.Get("c"), 3);
        }

        [TestMethod]
        public void GetTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();

            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            Assert.AreEqual(hashTable.Get("a"), 1);
            Assert.AreEqual(hashTable.Get("b"), 2);
            Assert.AreEqual(hashTable.Get("c"), 3);

            Assert.AreEqual(hashTable.Get("d"), default(int));
        }

        [TestMethod]
        public void ContainsTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();

            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            Assert.IsTrue(hashTable.Contains("a"));
            Assert.IsTrue(hashTable.Contains("b"));
            Assert.IsTrue(hashTable.Contains("c"));

            Assert.IsFalse(hashTable.Contains("d"));
        }

        [TestMethod]
        public void RemoveTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();


            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            hashTable.Remove("a");

            Assert.AreEqual(hashTable.Get("a"), default(int));
            Assert.AreEqual(hashTable.Get("b"), 2);
            Assert.AreEqual(hashTable.Get("c"), 3);
        }

        [TestMethod]
        public void RehashTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();

            for(int i = 0; i < 200; i++) {
                hashTable.Add($"Item-{i.ToString()}", i);
            }

            for (int i = 0; i < 200; i++) {
                var key = $"Item-{i.ToString()}";

                Assert.AreEqual(hashTable.Get($"Item-{i.ToString()}"), i);
            }

            Assert.AreEqual(hashTable.Size, 200);
        }

        [TestMethod]
        public void CountTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();


            Assert.AreEqual(hashTable.Size, 0);

            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            Assert.AreEqual(hashTable.Size, 3);
        }

        [TestMethod]
        public void ClearTest() {
            DataStructure.HashTable.HashTable<string, int> hashTable = new DataStructure.HashTable.HashTable<string, int>();


            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);

            hashTable.Clear();

            Assert.AreEqual(hashTable.Size, 0);
        }
    }
}
