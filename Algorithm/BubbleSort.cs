namespace Algorithm.BubbleSort {
    public class BubbleSort<T> where T : IComparable {

        /// <summary>
        /// Bubble Sort is a simple sorting algorithm that sequentially 
        /// traverses through a list, comparing and swapping adjacent 
        /// elements if they are out of order. This process is repeatedly 
        /// carried out until the entire list is sorted, indicated by the 
        /// absence of any further swaps.
        /// </summary>
        /// <param name="list">The list to sort</param>
        public static void Sort(List<T> list) {
            bool swapped;
            do {
                swapped = false;
                for (int i = 0; i < list.Count - 1; i++) {
                    if (list[i].CompareTo(list[i + 1]) > 0) {
                        T temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}