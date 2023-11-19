using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.QuickSort {
    /// <summary>
    /// QuickSort is a very efficient and commonly used sorting algorithm. 
    /// It works on the principle of "divide and conquer." Firstly, an 
    /// element of the array is chosen to serve as the pivot. This choice 
    /// can be random or follow a specific strategy, such as taking the 
    /// last element (as in the example), the first, or the median value. 
    /// Subsequently, the array is reorganized so that all elements smaller 
    /// than the pivot are placed before it and all larger elements are 
    /// placed after it. This process is then recursively applied to all 
    /// the sublists that precede or follow the pivot.
    /// </summary>
    /// <typeparam name="T">The comparable generic type of the list to sort</typeparam>
    public class QuickSort<T> where T : IComparable<T> {
        /// <summary>
        /// Recursive sorting function
        /// </summary>
        /// <param name="list"> The list to sort</param>
        public static void Sort(List<T> list) {
            RecursiveQuickSort(list, 0, list.Count - 1);
        }

        private static void RecursiveQuickSort(List<T> list, int low, int high) {
            if (low < high) {
                int partitionIndex = Partition(list, low, high);

                // Recursive sort the "low" sublist
                RecursiveQuickSort(list, low, partitionIndex - 1);

                // Recursive sort the "high" sublist
                RecursiveQuickSort(list, partitionIndex + 1, high);
            }
        }

        private static int Partition(List<T> list, int low, int high) {
            T pivot = list[high];
            int i = low - 1;

            // Move all element smaller than pivot
            for (int j = low; j < high; j++) {
                if (list[j].CompareTo(pivot) < 0) {
                    i++;
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }

            // Move the pivot in the right position
            (list[i + 1], list[high]) = (list[high], list[i + 1]);

            return i + 1;
        }
    }
}
