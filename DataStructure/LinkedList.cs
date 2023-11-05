using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.LinkedList {

    /// <summary>
    /// Fundamental element of a linked list, contain the data and the
    /// reference to an eventual next node.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Node<T>{
        public T Item;
        public Node<T>? Next;
    }

    /// <summary>
    /// A linked list is a datastructure that consists of a series of elements 
    /// (nodes) connected to each other. Each node has two attributes: 
    /// the data itself and the link to the next node. 
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class LinkedList<T> : IEnumerable<T> {

        public Node<T>? Head;
        private int Size;

        /// <summary>
        /// Create a new empty LinkedList
        /// <example>
        /// For example:
        /// <code>
        /// var ll = new DataStructure.LinkedList.LinkedList<int>();
        /// </code>
        /// </example>
        /// </summary>
        public LinkedList() {
            Head = null;
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

            if (Size != 0) {
                newNode.Next = Head;
            }

            Head = newNode;
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

            if (Size == 0) {
                Head = newNode;
            } else {
                Node<T>? tmpNode = Head;

                // Iterate all items
                while (tmpNode.Next is not null) {
                    tmpNode = tmpNode.Next;
                }
                tmpNode.Next = newNode;
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
            } else if ((Size == 1) || (position == Size - 1)) {
                AddLast(item);

            } else {
                Node<T> newNode = new Node<T>();
                newNode.Item = item;
                newNode.Next = null;

                Node<T> tmpNode = Head;

                for (var i = 0; tmpNode is not null && i < position; i++) {
                    tmpNode = tmpNode.Next;
                }

                newNode.Next = tmpNode.Next;
                tmpNode.Next = newNode;

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
                Size--;

            // Handle the case of removing the first element of the list
            } else if (position == 0) {
                Head = Head.Next;
                Size--;

            } else {
                Node<T>? tmpNode = Head;
                Node<T>? tmpPrevious = null;
                for (var i = 0; tmpNode is not null && i < position; i++) {
                    tmpPrevious = tmpNode;
                    tmpNode = tmpNode.Next;
                }

                tmpPrevious.Next = tmpNode.Next;
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

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion

    }
}
