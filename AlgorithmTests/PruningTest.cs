using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Pruning;

namespace AlgorithmTests {
    [TestClass]
    public class PruningTest {
        private int[,] solvableMaze;
        private int[,] unsolvableMaze;
        private Pruning solver;

        [TestInitialize]
        public void Setup() {
            solvableMaze = new int[,] {
                { 1, 1, 1, 1 },
                { 0, 0, 0, 1 },
                { 1, 1, 1, 1 },
                { 1, 0, 0, 0 },
                { 1, 1, 1, 1 }
            };

            unsolvableMaze = new int[,] {
                { 1, 0, 0, 1 },
                { 1, 0, 0, 1 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 }
            };
        }

        [TestMethod]
        public void TestSolvableMaze() {
            solver = new Pruning(solvableMaze);
            Assert.IsTrue(solver.SolveMaze(0, 0, 4, 3));
        }

        [TestMethod]
        public void TestUnsolvableMaze() {
            solver = new Pruning(unsolvableMaze);
            Assert.IsFalse(solver.SolveMaze(0, 0, 4, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestInvalidMaze() {
            solver = new Pruning(null);
            solver.SolveMaze(0, 0, 4, 3);
        }

        [TestMethod]
        public void TestEmptyMaze() {
            solver = new Pruning(new int[,] { });
            Assert.IsFalse(solver.SolveMaze(0, 0, 0, 0));
        }
    }
}
