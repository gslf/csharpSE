using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DisjointSet {

    /// <summary>
    /// The exception that is thrown when searching for an element 
    /// that is not present in the set.
    /// </summary>
    public class ItemNotFoundException : Exception {
        public ItemNotFoundException() {
        }

        public ItemNotFoundException(string message)
            : base(message) {
        }

        public ItemNotFoundException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    /// <summary>
    /// The fundamental element of a disjoint set, contain the data, a reference
    /// to the parent node and the rank of the node.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Node<T> where T : IComparable<T> {
        public T Item { get; set; }
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }

        public Node(T item) {
            Item = item;
            Parent = this;
            Rank = 0;
        }

        #region Implementation of IComparable
        public override bool Equals(object? obj) {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(Item, node.Item);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Item);
        }
        #endregion
    }


    /// <summary>
    /// A union-find disjoint set A union-find disjoint set is a data 
    /// structure that maintains disjoint sets of elements.It supports 
    /// two main operations:
    /// 1. Union: Merges two disjoint sets into a single disjoint set.
    /// 2. Find: Determines the representative of a given element.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class DisjointSet<T> : IEnumerable<T> where T : IComparable<T> {

        private HashSet<Node<T>> _set;
        public int Size { get; private set; }


        public DisjointSet() {
            _set = new HashSet<Node<T>>();
        }

        /// <summary>
        /// Check if the set contain a specific element
        /// <param name="node">The node to search.</param>
        /// <returns>The result of the check.</returns>
        /// </summary>
        public bool Contains(Node<T> node) {
            return _set.Contains(node);
        }

        /// <summary>
        /// The makeset function establish a new set. 
        /// </summary>
        /// <param name="item">The element to add.</param>
        /// <returns>The result of make operation.</returns>
        public bool  MakeSet(T item) {
            Node<T> node = new Node<T>(item);
            if (Contains(node)) {
                return false;
            }
            
            _set.Add(node);
            Size++;
            return true;
        }

        private Node<T> GetNode(T item) {
            foreach(Node<T> node in _set) {
                if (item.CompareTo(node.Item) == 0) return node;
            }

            throw new ItemNotFoundException();
        }

        /// <summary>
        /// Determines the representative of a given element, 
        /// which is the element that belongs to the same disjoint 
        /// set as the given element.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <exception cref="ItemNotFoundException">The exception raised when the parameter does not exist in the set.</exception>
        /// <returns>The representative a the element</returns>
        public T Find(T item) {
            return Find(Find(GetNode(item))).Item;
        }

        private Node<T> Find(Node<T> node) {
            if (node.Parent == node)
                return node;

            node.Parent = Find(node.Parent);
            return node.Parent;
        }

        /// <summary>
        /// Merges two disjoint sets into a single disjoint set.
        /// </summary>
        /// <param name="item1">The first item to join.</param>
        /// <param name="item2">The second item to join.</param>
        /// <exception cref="ItemNotFoundException">The exception raised when one of the parameters does not exist in the set.</exception>
        /// <returns>The result of the union operation.</returns>
        public bool Union(T item1, T item2) {
            
            Node<T> node1 = GetNode(item1);
            Node<T> node2 = GetNode(item2);

            if (node1.Parent == node2.Parent)
                return false;

            if (node1.Parent.Rank >= node2.Parent.Rank) {
                if (node1.Parent.Rank == node2.Parent.Rank)
                    ++node1.Parent.Rank;

                node2.Parent.Parent = node1.Parent;
            } else {
                node1.Parent.Parent = node2.Parent;
            }

            return true;
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator() {
            foreach (Node<T> node in _set) {
                yield return node.Item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
}
