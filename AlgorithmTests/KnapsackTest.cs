using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Knapsack;

namespace AlgorithmTests {
    [TestClass]
    public class KnapsackTest {
        private readonly Knapsack _knapsack = new Knapsack();

        [TestMethod]
        public void TestEmptyKnapsack() {
            int[] values = { };
            int[] weights = { };
            int capacity = 0;
            Assert.AreEqual(0, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        public void TestSingleItemFits() {
            int[] values = { 100 };
            int[] weights = { 10 };
            int capacity = 50;
            Assert.AreEqual(100, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        public void TestSingleItemDoesNotFit() {
            int[] values = { 100 };
            int[] weights = { 60 };
            int capacity = 50;
            Assert.AreEqual(0, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        public void TestMultipleItems() {
            int[] values = { 60, 100, 120 };
            int[] weights = { 10, 20, 30 };
            int capacity = 50;
            Assert.AreEqual(220, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        public void TestFullCapacityNotUsed() {
            int[] values = { 60, 40 };
            int[] weights = { 10, 20 };
            int capacity = 50;
            Assert.AreEqual(100, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        public void TestZeroCapacity() {
            int[] values = { 60, 100, 120 };
            int[] weights = { 10, 20, 30 };
            int capacity = 0;
            Assert.AreEqual(0, _knapsack.MaxValue(weights, values, capacity));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInvalidInput() {
            int[] values = { 60, 100 }; // Length mismatch
            int[] weights = { 10, 20, 30 };
            int capacity = 50;
            _knapsack.MaxValue(weights, values, capacity);
        }
    }
}
