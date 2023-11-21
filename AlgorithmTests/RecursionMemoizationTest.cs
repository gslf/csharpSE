using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Algorithm.RecursionMemoization;

namespace AlgorithmTests {
    [TestClass]
    public class RecursionMemoizationTest {
        [TestMethod]
        public void TestFibonacci1() {
            Assert.AreEqual(1, RecursionMemoization.Fibonacci(1));
        }

        [TestMethod]
        public void TestFibonacci0() {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(
                () => RecursionMemoization.Fibonacci(0));
        }

        [TestMethod]
        public void TestFibonacci20() {
            Assert.AreEqual(6765, RecursionMemoization.Fibonacci(20));
        }

        [TestMethod]
        public void TestFibonacciMemo1() {
            Assert.AreEqual(1, RecursionMemoization.FibonacciMemo(1));
        }

        [TestMethod]
        public void TestFibonacciMemo0() {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(
                () => RecursionMemoization.FibonacciMemo(0));
        }

        [TestMethod]
        public void TestFibonacciMemo20() {
            Assert.AreEqual(6765, RecursionMemoization.FibonacciMemo(20));
        }
    }
}
