using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.RecursionMemoization {

    /// <summary>
    /// Recursion memoization is a programming optimization technique 
    /// that improves the efficiency of recursive functions by storing 
    /// the results of function calls and reusing them when the same 
    /// inputs occur again. This method reduces the number of redundant 
    /// recursive calls, especially in problems with overlapping 
    /// subproblems, transforming a potentially exponential time algorithm 
    /// into a more efficient polynomial-time one. The primary trade-off is 
    /// increased space complexity due to the storage of previous results.
    /// </summary>
    public class RecursionMemoization {

        /// <summary>
        /// This is a simple recursive function without memoization.
        /// The function calulate the n-th Fibonacci number.
        /// </summary>
        /// <param name="n">The n-th value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The number can't be less than zero
        /// </exception>
        public static long Fibonacci(int n) {
            if (n < 1) throw new ArgumentOutOfRangeException();
            if (n <= 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        

        static Dictionary<int, long> memo = new Dictionary<int, long>();
        /// <summary>
        /// This function calculates the n-th Fibonacci number. To avoid repetitive 
        /// calculation of the same values, a dictionary (memo) is used to store the 
        /// results already calculated. When the function is called with the same 
        /// value of n, it directly returns the result from the dictionary instead 
        /// of recalculating it.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long FibonacciMemo(int n) {
            if (n < 1) throw new ArgumentOutOfRangeException();
            if (n <= 2) return 1;

            if (memo.ContainsKey(n)) {
                return memo[n];
            }

            memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memo[n];
        }

    }
}
