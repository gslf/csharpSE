using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Review DoubleLinkedList Comments

namespace DataStructure.DoubleLinkedList {
    public class Node<T> {
        public T Item;
        public Node<T>? Next;
        public Node<T>? Prev;
    }
    public class DoubleLinkedList<T> {

        public Node<T>? Head;
        public Node<T>? Tail;
        private int Size;

        public DoubleLinkedList() {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public int Lenght() {
            return Size;
        }

        public void AddFirst(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;
            newNode.Prev = null;

            if (Size == 0) {
                Head = newNode;
                Tail = newNode;
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

        public void AddLast(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;
            newNode.Prev = null;

            if (Size == 0) {
                Head = newNode;
                Tail = newNode;
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


        public void AddAfter(int position, T item) {
            if (position < 0 || position >= Size) {
                throw new ArgumentOutOfRangeException();

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
        
        public void Remove(int position) {
            if (position < 0 || Size < 1 || position >= Size) {
                throw new ArgumentOutOfRangeException();
            
            } else if (Size == 1) {
                Head = null;
                Tail = null;
                Size--;

            } else if (position == 0) {
                Head = Head.Next;
                Head.Prev = null;
                Size--;

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

        public IEnumerable<T> GetEnum() {
            Node<T>? tmpNode = Head;

            // all elements where a next attribute exists
            while (tmpNode is not null) {
                yield return tmpNode.Item;
                tmpNode = tmpNode.Next;
            }
        }
        
        public IEnumerable<T> GetReverseEnum() {
        Node<T>? tmpNode = Tail;

        // all elements where a next attribute exists
        while (tmpNode is not null) {
            yield return tmpNode.Item;
            tmpNode = tmpNode.Prev;
        }
        }

    }
}
