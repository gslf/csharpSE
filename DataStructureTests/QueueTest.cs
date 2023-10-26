
namespace DataStructureTests {
    [TestClass]
    public class QueueTest {
        [TestMethod]
        public void TestConstructor() {
            var empty_queue = new DataStructure.Queue.Queue<int>();
            var enumerable_queue = new DataStructure.Queue.Queue<int>(new[] { 0, 1, 2, 3, 4 });
            Assert.AreEqual(0, empty_queue.Size());
            Assert.AreEqual(0, enumerable_queue.Peek());
        }

        [TestMethod]
        public void TestPushPop() {
            var my_queue = new DataStructure.Queue.Queue<int>();
            my_queue.Enqueue(1);
            my_queue.Enqueue(2);
            Assert.AreEqual(1, my_queue.Dequeue());

            try {
                my_queue.Clear();
                my_queue.Dequeue();
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is InvalidOperationException, ex.Message);
            }
        }
    }
}
