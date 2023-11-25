using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;
using Algorithm.ShortestPath;

namespace AlgorithmTests {
    [TestClass]
    public class DijkstraShortestPathTest {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_EmptyGraph() {
            DijkstraShortestPath g = new DijkstraShortestPath(0);
            g.PathCalc(0);
        }

        [TestMethod]
        public void Test_SingleNode() {
            DijkstraShortestPath g = new DijkstraShortestPath(1);
            g.PathCalc(0);
            int[] expectedDistances = { 0 };
            CollectionAssert.AreEqual(expectedDistances, g.GetDistances());
        }

        [TestMethod]
        public void Test_DirectPaths() {
            DijkstraShortestPath g = new DijkstraShortestPath(4);
            g.AddEdge(0, 1, 1);
            g.AddEdge(1, 2, 2);
            g.AddEdge(2, 3, 3);
            g.AddEdge(3, 0, 4);
            g.PathCalc(0);

            int[] expectedDistances = { 0, 1, 3, 6 };
            CollectionAssert.AreEqual(expectedDistances, g.GetDistances());
        }
    }
}
