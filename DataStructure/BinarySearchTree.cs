using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DataStructure.BinarySearchTree {

    /// <summary>
    /// The exception that is thrown when searching for an element 
    /// that is not present in the tree.
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
    /// The fundamental element of a binary search tree, contain the data and the
    /// reference to left and right child nodes.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class Node<T> where T : IComparable<T> {
        public T Item { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T item) {
            Item = item;
            Left = null;
            Right = null;
        }

        public void Add(T newItem) {

            if (newItem.CompareTo(Item) < 0) {
                if (Left == null)
                    Left = new Node<T>(newItem);
                else
                    Left.Add(newItem);

            } else {
                if (Right == null)
                    Right = new Node<T>(newItem);
                else
                    Right.Add(newItem);  
            }
        }
    }

    /// <summary>
    /// A binary search tree (BST) is a data structure in which each node contains 
    /// a value and two pointers, one on the left and one on the right, that point
    /// to two subtrees. Node values are ordered such that each value in the left 
    /// subtree of a node is less than or equal to the value of the node itself, 
    /// and each value in the right subtree is greater than or equal to the value 
    /// of the node itself.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public class BinarySearchTree<T> where T : IComparable<T> {
        public Node<T>? Root { get; private set; }
        // The size of the binary search tree
        public int Size { get; private set; }

        /// <summary>
        /// Adds a new item to the BST
        /// <param name="item">The item to add</param>
        /// </summary>
        public void Insert(T item) {
            if (Root == null) 
                Root = new Node<T>(item);
            else 
                Root.Add(item);
            

            Size++;
        }

        /// <summary>
        /// Remove an item from the BST
        /// <param name="item">The item to remove</param>
        /// </summary>
        public void Remove(T item) {
            Remove(item, Root);
        }

        // Private utility function to remove a node
        private void Remove(T item, Node<T> startNode) {

            if (Root != null) { 
                Node<T> current = startNode;
                Node<T> parent = startNode;
                bool isLeft = false;


                while (item.CompareTo(current.Item) != 0) {
                    parent = current;
                    int comparison = item.CompareTo(current.Item);
                    
                    if (comparison < 0) {
                        current = current.Left;
                        isLeft = true;
                    } else {
                        current = current.Right;
                        isLeft = false;
                    }

                    if (current == null) {
                        throw new ItemNotFoundException();
                    }
                }

                // Case 1: the item is a leaf node
                if (current.Right == null && current.Left == null) {
                    if (isLeft)
                        parent.Left = null;
                    else
                        parent.Right = null;

                    Size--;

                }

                // Case 2a: the item has only one child (Left)
                else if (current.Right == null) {
                    if (isLeft)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;

                    Size--;
                }

                // Case 2b: the item has only one child (Right)
                else if (current.Right == null) {
                    if (isLeft)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;

                    Size--;
                }

                // Case 3: the item has two child
                else {
                    Node<T> successor = FindSuccessor(current.Right);
                    T tmpItem = successor.Item;
                    Remove(tmpItem, current);
                    current.Item = tmpItem;
                }



            } else {
                throw new ItemNotFoundException();
            }
        }

        // Utility function to find the successor of a node to remove
        private Node<T> FindSuccessor(Node<T> node) {
            while (node.Left != null) {
                node = node.Left;
            }
            return node;
        }


        /// <summary>
        /// Function to create a tree CLI diagram , starting from a specific node
        /// <param name="level">The starting level of the diagram</param>
        /// <param name="root">The starting node of the diagram</param>
        /// </summary>
        public void Display(int level, Node<T> root) {
            if (root != null) {
                Display(level + 1, root.Right);

                if (root.Item.CompareTo(Root.Item) == 0) {
                    Console.Write("-> ");
                }
                for (int i = 0; i < level && root.Item.CompareTo(Root.Item) != 0; i++) {
                    Console.Write("   ");
                }
                Console.WriteLine(root.Item);
                Display(level + 1, root.Left);
            }
        }



        /// <summary>
        /// Traverse the tree in order
        /// <returns>The enumerable object</returns>
        /// </summary>
        public IEnumerable<T> InOrderEnum() => InOrderEnum(Root);
        // Recursive private in order traverse function
        private IEnumerable<T> InOrderEnum(Node<T>? node) {
            if (node is null) {
                return Enumerable.Empty<T>();
            }

            return InOrderEnum(node.Left)
                        .Concat(new[] { node.Item })
                        .Concat(InOrderEnum(node.Right));
        }

        /// <summary>
        /// Traverse the tree pre order
        /// <returns>The enumerable object</returns>
        /// </summary>
        public IEnumerable<T> PreOrderEnum() => PreOrderEnum(Root);
        // Recursive private pre order traverse function
        private IEnumerable<T> PreOrderEnum(Node<T>? node) {
            if (node is null) {
                return Enumerable.Empty<T>();
            }


            return new[] { node.Item }
                    .Concat(PreOrderEnum(node.Left))
                    .Concat(PreOrderEnum(node.Right));
        }

        /// <summary>
        /// Traverse the tree post order
        /// <returns>The enumerable object</returns>
        /// </summary>
        public IEnumerable<T> PostOrderEnum() => PostOrderEnum(Root);
        // Recursive private post order traverse function
        private IEnumerable<T> PostOrderEnum(Node<T>? node) {
            if (node is null) {
                return Enumerable.Empty<T>();
            }

            return PostOrderEnum(node.Left)
                    .Concat(PostOrderEnum(node.Right))
                    .Concat(new[] { node.Item });
        }

    }
}
