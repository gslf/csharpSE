using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSubsequence {
    public class SubsequenceMatrix {

        /// <summary>
        /// Function that allows you to find the longest common subsequence 
        /// (LCS) between two strings.
        /// </summary>
        /// <param name="s1">The first string to compare</param>
        /// <param name="s2">The second string to compare</param>
        /// <returns>The LCS value as integer</returns>
        public static int Subsequence(string s1, string s2) {
            int l1 = s1.Length;
            int l2 = s2.Length;

            //Creates an L matrix of size (m+1) x (n+1) to store the intermediate
            //results. The matrix is used for dynamic programming.
            int[,] L = new int[l1 + 1, l2 + 1];

            // Iterate over the rows of the matrix.
            for (int i = 0; i <= l1; i++) {

                // Iterate over the column of the matrix.
                for (int j = 0; j <= l2; j++) {

                    // Initialize the first row and first column of the matrix to 0.
                    // This represents the base case, where one of the strings is empty.
                    if (i == 0 || j == 0)
                        L[i, j] = 0;

                    // If the current characters in s1 and s2 are equal, increment the
                    // value of the previous diagonal cell (L[i-1, j-1]) by 1.
                    else if (s1[i - 1] == s2[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;

                    // If the current characters are not equal, it takes the maximum
                    // value between the top cell (L[i-1, j]) and the left cell
                    // (L[i, j-1]).
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }

            // Returns the value in the lower right corner of the array, which represents
            // the length of the LCS.
            return L[l1, l2];
        }
    }
}
