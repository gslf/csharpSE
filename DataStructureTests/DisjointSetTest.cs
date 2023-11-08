using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructureTests {
    [TestClass]
    public class DisjointSetTest {
        [TestMethod]
        public void TestMakeSet() {
            var testSet = new DataStructure.DisjointSet.DisjointSet<int>();
            bool makeResult = false;

            testSet.MakeSet(5);
            testSet.MakeSet(6);
            testSet.MakeSet(7);
            makeResult = testSet.MakeSet(8);
            Assert.IsTrue(makeResult);
            Assert.AreEqual(4, testSet.Size);

            makeResult = testSet.MakeSet(5);
            Assert.IsFalse(makeResult);
        }

        [TestMethod]
        public void TestFindUnion() {
            var testSet = new DataStructure.DisjointSet.DisjointSet<int>();

            testSet.MakeSet(1);
            testSet.MakeSet(2);
            testSet.MakeSet(3);
            testSet.MakeSet(4);
            testSet.MakeSet(5);
            testSet.MakeSet(6);
            testSet.MakeSet(5);
            testSet.MakeSet(6);
            testSet.MakeSet(7);
            testSet.MakeSet(8);
            testSet.MakeSet(9);
            testSet.MakeSet(10);
            Assert.AreEqual(5, testSet.Find(5));

            testSet.Union(1, 2);
            testSet.Union(3, 4);
            testSet.Union(1, 3);
            Assert.AreEqual(1, testSet.Find(1));
            Assert.AreEqual(1, testSet.Find(3));


            testSet.Union(5, 6);
            testSet.Union(7, 8);
            testSet.Union(5, 7);
            Assert.AreEqual(5, testSet.Find(8));
            Assert.AreEqual(5, testSet.Find(7));

            testSet.Union(9, 10);
            Assert.AreEqual(9, testSet.Find(9));

            testSet.Union(10, 5);
            testSet.Union(9, 1);
            Assert.AreEqual(5, testSet.Find(1));
            Assert.AreEqual(5, testSet.Find(9));

        }

        [TestMethod]
        public void TestExceptions() {

            var testSet = new DataStructure.DisjointSet.DisjointSet<int>();

            testSet.MakeSet(5);
            testSet.MakeSet(6);

            try {
                testSet.Union(5, 10);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is DataStructure.DisjointSet.ItemNotFoundException, ex.Message);
            }

            try {
                testSet.Union(15, 20);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is DataStructure.DisjointSet.ItemNotFoundException, ex.Message);
            }

            try {
                testSet.Find(10);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is DataStructure.DisjointSet.ItemNotFoundException, ex.Message);
            }

        }

        [TestMethod]
        public void TestIteration() {

            var testSet = new DataStructure.DisjointSet.DisjointSet<int>();
            var compareSet = new HashSet<int>();

            testSet.MakeSet(5);
            testSet.MakeSet(6);

            foreach (int element in testSet) {
                compareSet.Add(element);
            }

            Assert.IsTrue(compareSet.Contains(5));
            Assert.IsTrue(compareSet.Contains(6));
        }
    }
}
