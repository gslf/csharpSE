
namespace DataStructureTests {
    [TestClass]
    public class DoubleLinkedListTest {
        [TestMethod]
        public void TestList() {
            var ll = new DataStructure.DoubleLinkedList.DoubleLinkedList<int>();
            ll.AddFirst(2);
            ll.AddFirst(1);
            ll.AddLast(4);
            ll.AddLast(5);
            ll.AddAfter(1, 3);
            ll.AddAfter(4, 6);

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            int counter = 0;
            foreach (int node in ll) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }

            int[] revExpected = new int[] { 6, 5, 4, 3, 2, 1 };
            counter = 0;
            foreach (int node in ll.GetRevEnumerator()) {
                Assert.AreEqual(revExpected[counter], node);
                counter++;
            }

            ll.Remove(5);
            Assert.AreEqual(5, ll.Lenght());


        }

        [TestMethod]
        public void TestIndexErrors() {
            var ll = new DataStructure.DoubleLinkedList.DoubleLinkedList<int>();

            try {
                ll.Remove(0);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is ArgumentOutOfRangeException, ex.Message);
            }

            try {
                ll.AddAfter(5, 1);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is ArgumentOutOfRangeException, ex.Message);
            }
        }

        [TestMethod]
        public void TestRemove() {
            // Remove from list with one element
            var ll = new DataStructure.DoubleLinkedList.DoubleLinkedList<int>();
            ll.AddFirst(1);
            ll.Remove(0);
            Assert.AreEqual(0, ll.Lenght());

            // Remove first from list with two elements
            ll.AddFirst(1);
            ll.AddLast(2);
            ll.Remove(0);
            Assert.AreEqual(1, ll.Lenght());
            Assert.AreEqual(2, ll.First());

            // Remove second from list with two elements
            ll.AddFirst(1);
            ll.Remove(1);
            Assert.AreEqual(1, ll.Lenght());
            Assert.AreEqual(1, ll.First());

            // Remove second from list with three elements
            ll.AddLast(2);
            ll.AddLast(3);
            ll.Remove(1);

            int[] expected = new int[] { 1, 3 };
            int counter = 0;
            foreach (int node in ll) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }
        }

        [TestMethod]
        public void TestAddAfter() {
            // AddAfter in a list with one element
            var ll = new DataStructure.DoubleLinkedList.DoubleLinkedList<int>();
            ll.AddFirst(1);
            ll.AddAfter(0,3);
            Assert.AreEqual(2, ll.Lenght());

            // AddAfter the first in list with two elements
            ll.AddAfter(0, 2);
            int[] expected = new int[] { 1, 2, 3 };
            int counter = 0;
            foreach (int node in ll) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }


            // AddAfter the second in a list with two elements
            ll.Remove(2);
            ll.AddAfter(1, 3);
            counter = 0;
            foreach (int node in ll) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }

        }
    }
}
