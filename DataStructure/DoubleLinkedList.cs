using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DoubleLinkedList {
    /// <summary>
    /// Fundamental element of a double linked list, contain the data,
    /// the reference to an eventual next node and the reference to
    /// an eventual previous node.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Node<T> {
        public T Item;
        public Node<T>? Next;
        public Node<T>? Prev;
    }

    /// <summary>
    /// A double linked list is a datastructure that consists of a series of 
    /// elements  (nodes) connected to each other. Each node has three attributes: 
    /// the data itself, the link to the next node and the link to previous node. 
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class DoubleLinkedList<T> : IEnumerable<T> {

        public Node<T>? Head;
        public Node<T>? Tail;
        private int Size;

        /// <summary>
        /// Create a new empty DoubleLinkedList
        /// <example>
        /// For example:
        /// <code>
        /// var ll = new DataStructure.DoubleLinkedList.DoubleLinkedList<int>();
        /// </code>
        /// </example>
        /// </summary>
        public DoubleLinkedList() {
            Head = null;
            Tail = null;
            Size = 0;
        }

        /// <summary>
        /// Get the size of the list
        /// <returns>The size of the list</returns>
        /// </summary>
        public int Lenght() {
            return Size;
        }

        /// <summary>
        /// Adds a new item to the top of the list
        /// <param name="item">The item to add</param>
        /// </summary>
        public void AddFirst(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;
            newNode.Prev = null;

            // Handle the case of a list with zero element
            if (Size == 0) {
                Head = newNode;
                Tail = newNode;

            // Handle the case of a list with one element
            } else if (Size == 1) {
                newNode.Next = Tail;

                Head = newNode;
                Tail.Prev = newNode;

            } else{
                newNode.Next = Head;
                Head = newNode;
            }

            Size++;
        }

        /// <summary>
        /// Adds a new item at the end of the list
        /// <param name="item">The item to add</param>
        /// </summary>
        public void AddLast(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;
            newNode.Prev = null;

            // Handle the case of a list with zero element
            if (Size == 0) {
                Head = newNode;
                Tail = newNode;

            // Handle the case of a list with one element
            } else if (Size == 1) {
                newNode.Prev = Head;

                Head.Next = newNode;
                Tail = newNode;
            } else {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }

            Size++;

        }

        /// <summary>
        /// Adds a new item after a specific position of the list
        /// <param name="position">The position after which to add the new item</param>
        /// <param name="item">The item to add</param>
        /// <exception cref="ArgumentOutOfRangeException">When the position parameter is out of range.</exception>
        /// </summary>
        public void AddAfter(int position, T item) {
            if (position < 0 || position >= Size) {
                throw new ArgumentOutOfRangeException();

            // Use AddLast() to add the item at the end or if the list have only one element
            } else if ((Size == 1) || (position == Size - 1)){
                AddLast(item);

            } else {
                Node<T> newNode = new Node<T>();
                newNode.Item = item;
                newNode.Next = null;
                newNode.Prev = null;

                Node<T>? tmpNode = Head;

                for (var i = 0; tmpNode is not null && i <= position; i++) {
                    tmpNode = tmpNode.Next;
                }

                newNode.Prev = tmpNode.Prev;
                newNode.Next = tmpNode;

                tmpNode.Prev.Next = newNode;
                tmpNode.Prev = newNode;

                Size++;
            }


        }

        /// <summary>
        /// Remove an item from the list
        /// <param name="position">The item to add</param>
        /// <exception cref="ArgumentOutOfRangeException">When the position parameter is out of range.</exception>
        /// </summary>
        public void Remove(int position) {
            if (position < 0 || Size < 1 || position >= Size) {
                throw new ArgumentOutOfRangeException();

            // Handle the case of a list with one element
            } else if (Size == 1) {
                Head = null;
                Tail = null;
                Size--;

            // Handle the case of removing the first element of the list
            } else if (position == 0) {
                Head = Head.Next;
                Head.Prev = null;
                Size--;

            // Handle the case of removing the last element of the list
            } else if (position == Size - 1) {
                Tail = Tail.Prev;
                Tail.Next = null;
                Size--;

            } else {
                Node<T>? tmpNode = Head;

                for (var i = 0; tmpNode is not null && i < position; i++) {
                    tmpNode = tmpNode.Next;
                }

                tmpNode.Prev.Next = tmpNode.Next;
                tmpNode.Next.Prev = tmpNode.Prev;
                Size--;
            }
        }

        #region Implementation of IEnumerable
        public IEnumerator<T> GetEnumerator() {
            Node<T>? tmpNode = Head;

            while (tmpNode is not null) {
                yield return tmpNode.Item;
                tmpNode = tmpNode.Next;
            }
        }

        public IEnumerable<T> GetRevEnumerator() {
            Node<T>? tmpNode = Tail;

            while (tmpNode is not null) {
                yield return tmpNode.Item;
                tmpNode = tmpNode.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }
}
