using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.MergeSort {
    /// <summary>
    /// MergeSort is a divide-and-conquer algorithm for sorting lists or arrays. 
    /// 
    /// It works as follows:
    /// Divide: The algorithm begins by dividing the entire list(or array) into two halves.
    /// If the list is already of size one(or zero), it is considered sorted, and no 
    /// further action is taken.
    /// 
    /// Conquer: Each half is then recursively sorted using the same MergeSort process.
    /// This recursive division continues until each subsection of the list contains only 
    /// a single element.
    /// 
    /// Combine(Merge): After the subdivision, the algorithm begins merging the pieces 
    /// back together.During this merge step, it combines two sorted sublists into one 
    /// sorted list.This is done by comparing the smallest elements of each sublist and 
    /// placing the smaller one into the new combined list.This process is repeated until 
    /// all elements have been merged back into a single sorted list.
    /// </summary>
    /// <typeparam name="T">The comparable generic type of the list to sort</typeparam>
    public class MergeSort<T> where T : IComparable<T> {

        /// <summary>
        /// Recursive sorting function
        /// </summary>
        /// <param name="list">The list to sort</param>
        public static void Sort(List<T> list) {
            if (list.Count <= 1) return;

            //////////////////////////////////////////////////
            // Split
            int middle = list.Count / 2;
            List<T> left = new List<T>(list.GetRange(0, middle));
            List<T> right = new List<T>(list.GetRange(middle, list.Count - middle));

            // Recursive Call
            Sort(left);
            Sort(right);

            //////////////////////////////////////////////////
            // Merge 

            // Iteration indexes
            int i = 0, j = 0, k = 0;
            while (i < left.Count && j < right.Count) {
                if (left[i].CompareTo(right[j]) <= 0) {
                    list[k] = left[i];
                    i++;
                } else {
                    list[k] = right[j];
                    j++;
                }
                k++;
            }

            // Collect remaining elements
            while (i < left.Count) {
                list[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Count) {
                list[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
