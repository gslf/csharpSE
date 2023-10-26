
namespace DataStructureTests {
    [TestClass]
    public class LinkedListTest {
        [TestMethod]
        public void TestList() {
            var ll = new DataStructure.LinkedList.LinkedList<int>();
            ll.AddFirst(2);
            ll.AddFirst(1);
            ll.AddLast(4);
            ll.AddLast(5);
            ll.AddAfter(1, 3);
            ll.AddAfter(4, 6);

            int[] expected = new int[]{ 1, 2, 3, 4, 5, 6};
            int counter = 0;
            foreach (int node in ll.GetEnum()) {
                Assert.AreEqual(expected[counter],node);
                counter++;
            }

            ll.Remove(5);
            Assert.AreEqual(5, ll.Lenght());

            
        }

        [TestMethod]
        public void TestIndexErrors() {
            var ll = new DataStructure.LinkedList.LinkedList<int>();

            try {
                ll.Remove(0);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is ArgumentOutOfRangeException, ex.Message);
            }

            try {
                ll.AddAfter(5,1);
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is ArgumentOutOfRangeException, ex.Message);
            }
        }
    }
}
