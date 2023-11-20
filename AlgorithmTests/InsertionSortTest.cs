using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTests {
    [TestClass]
    public class InsertionSortTest {
        [TestMethod]
        public void TestIntList() {
            var list = new List<int> { 5, 3, 8, 4, 1 };
            var expected = new List<int> { 1, 3, 4, 5, 8 };

            Algorithm.InsertionSort.InsertionSort< int>.Sort(list);

            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestStringList() {
            var list = new List<string> { "Dog", "Cat", "Bird", "Antelope" };
            var expected = new List<string> { "Antelope", "Bird", "Cat", "Dog" };

            Algorithm.InsertionSort.InsertionSort<string>.Sort(list);

            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestEmptyList() {
            var list = new List<int>();
            Algorithm.InsertionSort.InsertionSort<int>.Sort(list);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestSingleElementList() {
            var list = new List<int> { 1 };
            Algorithm.InsertionSort.InsertionSort<int>.Sort(list);
            var expected = new List<int> { 1 };
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestDuplicatesList() {
            var list = new List<int> { 3, 1, 3, 2 };
            Algorithm.InsertionSort.InsertionSort<int>.Sort(list);
            var expected = new List<int> { 1, 2, 3, 3 };
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestAlreadySortedList() {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Algorithm.InsertionSort.InsertionSort<int>.Sort(list);
            var expected = new List<int> { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, list);
        }
    }
}
