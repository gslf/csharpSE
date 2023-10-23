using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace DataStructure.Stack {
    /// <summary>
    /// LIFO Stack, implemented using a List.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Stack<T>{

        private List<T> stack = new List<T>();

        /// <summary>
        /// Create a new empty stack
        /// <example>
        /// For example:
        /// <code>
        /// var my_stack = new DataStructure.Stack.Stack<int>();
        /// </code>
        /// </example>
        /// </summary>
        public Stack() { 
           stack = new List<T>();
        }

        /// <summary>
        /// Create a new stack from an Enumerable
        /// <example>
        /// For example:
        /// <code>
        /// var enumerable_stack = new DataStructure.Stack.Stack<int>(new[] { 0, 1, 2, 3, 4 });
        /// </code>
        /// </example>
        /// </summary>
        public Stack(IEnumerable<T> items){
            stack = new List<T>();
            foreach (var item in items) {
                stack.Add(item);
            }
        }

        /// <summary>
        /// Get the size of the stack
        /// <returns>The size of the stack</returns>
        /// </summary>
        public int Size() {
            return stack.Count;
        }

        /// <summary>
        /// Push a new item in the stack
        /// <param name="item">The item to push</param>
        /// </summary>
        public void Push(T item) {
            stack.Add(item);
        }

        /// <summary>
        /// Get (and remove) an item from the stack
        /// <returns>The removed item</returns>
        /// </summary>>
        public T Pop() {
            if (stack.Count < 1) throw new InvalidOperationException();
            
            var last_idx = stack.Count - 1;
            var last = stack[last_idx];
            stack.RemoveAt(last_idx);
            return last;
        }

        /// <summary>
        /// Get an item from the stack
        /// <returns>The peeked item</returns>
        /// </summary>
        public T Peek() {
            if (stack.Count < 1) throw new InvalidOperationException();

            var last_idx = stack.Count - 1;
            return stack[last_idx];
        }

        /// <summary>
        /// Remove all items from the stack
        /// </summary>
        public void Clear() {
            stack.Clear();
        }

    }
}