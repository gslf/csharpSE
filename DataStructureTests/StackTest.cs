using DataStructure.Stack;

namespace DataStructureTests {
    [TestClass]
    public class StackTest {
        [TestMethod]
        public void TestConstructor() {
            var empty_stack = new DataStructure.Stack.Stack<int>();
            var enumerable_stack = new DataStructure.Stack.Stack<int>(new[] { 0, 1, 2, 3, 4 });
            Assert.AreEqual(0, empty_stack.Size());
            Assert.AreEqual(4, enumerable_stack.Peek());
        }

        [TestMethod]
        public void TestPushPop() {
            var my_stack = new DataStructure.Stack.Stack<int>();
            my_stack.Push(1);
            my_stack.Push(2);
            Assert.AreEqual(2, my_stack.Pop());

            try {
                my_stack.Clear();
                my_stack.Pop();
                Assert.Fail("no exception thrown");
            } catch (Exception ex) {
                Assert.IsTrue(ex is InvalidOperationException, ex.Message);
            }
        }
    }
}