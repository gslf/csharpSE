using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.InsertionSort {
    public class InsertionSort<T> where T : IComparable {

        /// <summary>
        /// Insertion Sort is an algorithm that incrementally 
        /// organizes a list by methodically selecting each element 
        /// and fitting it into its proper place within the pre-sorted 
        /// section. It carefully shifts any larger elements upwards 
        /// in the sorted part to create space, ensuring each new 
        /// element is positioned correctly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Te list to sort</param>
        public static void Sort<T>(List<T> list) where T : IComparable {
            for (int i = 1; i < list.Count; i++) {
                T key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j].CompareTo(key) > 0) {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = key;
            }
        }
    }
}
