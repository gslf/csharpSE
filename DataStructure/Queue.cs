
using System.Collections.Generic;

namespace DataStructure.Queue {
    /// <summary>
    /// FIFO Queue, implemented using a List.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Queue<T> {
        
        private List<T> queue = new List<T>();

        /// <summary>
        /// Create a new empty queue
        /// <example>
        /// For example:
        /// <code>
        /// var my_queue = new DataStructure.Queue.Queue<int>();
        /// </code>
        /// </example>
        /// </summary>
        public Queue() {
            queue = new List<T>();
        }

        /// <summary>
        /// Create a new queue from an Enumerable
        /// <example>
        /// For example:
        /// <code>
        /// var enumerable_queue = new DataStructure.Queue.Queue<int>(new[] { 0, 1, 2, 3, 4 });
        /// </code>
        /// </example>
        /// </summary>
        public Queue(IEnumerable<T> items) {
            queue = new List<T>();
            foreach (var item in items) {
                queue.Add(item);
            }
        }

        /// <summary>
        /// Get the size of the queue
        /// <returns>The size of the queue</returns>
        /// </summary>
        public int Size() {
            return queue.Count;
        }

        /// <summary>
        /// Add a new item to the queue
        /// <param name="item">The item to enqueue</param>
        /// </summary>
        public void Enqueue(T item) {
            queue.Add(item);
        }

        /// <summary>
        /// Get (and remove) an item from the queue
        /// <returns>The removed item</returns>
        /// </summary>>
        public T Dequeue() {
            if (queue.Count < 1) throw new InvalidOperationException();

            var first = queue[0];
            queue.RemoveAt(0);
            return first;
        }

        /// <summary>
        /// Get an item from the queue
        /// <returns>The peeked item</returns>
        /// </summary>
        public T Peek() {
            if (queue.Count < 1) throw new InvalidOperationException();

            return queue[0];
        }

        /// <summary>
        /// Remove all items from the queue
        /// </summary>
        public void Clear() {
            queue.Clear();
        }
    }
}
