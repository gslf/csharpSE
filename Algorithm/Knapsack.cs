using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Knapsack {
    public class Knapsack {
        /// <summary>
        /// The Knapsack Problem is a pivotal optimization challenge in combinatorial 
        /// optimization and dynamic programming. It entails optimizing the total 
        /// value of items packed in a backpack, constrained by its weight capacity. 
        /// In its most encountered form, the "0/1 Knapsack Problem," each item can 
        /// either be entirely included or excluded, with no partial selection. 
        /// </summary>
        /// <param name="weight">Items weight</param>
        /// <param name="value">Items values</param>
        /// <param name="capacity">The backpack capacity</param>
        /// <returns></returns>
        public int MaxValue(int[] weight, int[] value, int capacity) {
            
            // The number of items
            int n = weight.Length;

            // Creates a matrix of size (n + 1) x (capacity + 1) to store the intermediate
            //results. The matrix is used for dynamic programming.
            int[,] dp = new int[n + 1, capacity + 1];

            // Iterate over all items
            for (int i = 0; i <= n; i++) {

                // Iterate over all backback capacity results
                for (int w = 0; w <= capacity; w++) {

                    // Initialize the first row and first column of the matrix to 0.
                    // This represents the base case: no items or no backpack capacity.
                    if (i == 0 || w == 0)
                        dp[i, w] = 0;

                    // Check if the current item's weight can be accommodated in the
                    // backpack. If yes, choose the maximum between including the current
                    // item or not including it.
                    else if (weight[i - 1] <= w)
                        dp[i, w] = Math.Max(value[i - 1] + dp[i - 1, w - weight[i - 1]], dp[i - 1, w]);

                    //If the current item's weight is too large to fit in the backpack,
                    //use the value of the optimal solution without the current item.
                    else
                        dp[i, w] = dp[i - 1, w];
                }
            }

            return dp[n, capacity];
        }
    }
}
