using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmSubsequence;

namespace AlgorithmTests {
    [TestClass]
    public class SubsequenceMatrixTest {
        [TestMethod]
        public void TestEmptyStrings() {
            string s1 = "";
            string s2 = "";

            int result = SubsequenceMatrix.Subsequence(s1, s2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestNoMatchStrings() {
            string s1 = "ABCDEFGHI";
            string s2 = "LMNOPQRST";

            int result = SubsequenceMatrix.Subsequence(s1, s2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestMatchStrings() {
            string s1 = "ABCDEFGHI";
            string s2 = "LMNEFGHST";

            int result = SubsequenceMatrix.Subsequence(s1, s2);
            Assert.AreEqual(4, result);
        }
    }
}
