namespace DataStructureTests {
    [TestClass]
    public class BinarySearchTreeTest {


        [TestMethod]
        public void TestBST() {
            var bst = new DataStructure.BinarySearchTree.BinarySearchTree<int>();

            // Test all Insert position
            bst.Insert(50);
            bst.Insert(60);
            bst.Insert(55);
            bst.Insert(70);
            bst.Insert(40);
            bst.Insert(41);
            bst.Insert(42);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(31);
            bst.Insert(10);
            bst.Insert(100);

            // Test postorder traversal on the original list
            int[] expected = new int[] { 10, 20, 31, 30, 42, 41, 40, 55, 100, 70, 60, 50 };
            int counter = 0;
            foreach (int node in bst.PostOrderEnum()) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }

            // Remove two elements
            bst.Remove(30);
            bst.Remove(60);

            // Test preorder traversal after removing 2 items
            expected = new int[] { 50, 40, 31, 20, 10, 41, 42, 70, 55, 100 };
            counter = 0;
            foreach (int node in bst.PreOrderEnum()) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }

            // Remove two elements
            bst.Remove(100);
            bst.Remove(50);

            // Test inorder traversal after removing 4 items
            expected = new int[] { 10, 20, 31, 40, 41, 42, 55, 70 };
            counter = 0;
            foreach (int node in bst.InOrderEnum()) {
                Assert.AreEqual(expected[counter], node);
                counter++;
            }
        }
    }
}
