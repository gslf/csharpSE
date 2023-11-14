namespace Algorithm.BubbleSort {
    public class BubbleSort<T> where T : IComparable {
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