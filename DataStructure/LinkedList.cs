using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.LinkedList {

    public class Node<T>{
        public T Item;
        public Node<T>? Next;
    }
    public class LinkedList<T> {

        public Node<T>? Head;
        private int Size;

        public LinkedList() {
            Head = null;
            Size = 0;
        }

        public int Lenght() {
            return Size;
        }

        public void AddFirst(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;

            if (Size == 0) {
                Head = newNode;
            } else {
                newNode.Next = Head;
                Head = newNode;
            }

            Size++;
        }

        public void AddLast(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;

            if (Size == 0) {
                Head = newNode;
            } else {
                Node<T> tmpHead = Head;

                // all elements where a next attribute exists
                while (tmpHead.Next is not null) {
                    tmpHead = tmpHead.Next;
                }
                tmpHead.Next = newNode;
            }

            Size++;

        }


        public void AddAfter(int position, T item) {
            if (position < 0 || position >= Size) {
                throw new ArgumentOutOfRangeException();

            } else if (position == 0) {
                AddFirst(item);
            } else {
                Node<T> newNode = new Node<T>();
                newNode.Item = item;
                newNode.Next = null;

                Node<T> tmpHead = Head;

                for (var i = 0; tmpHead is not null && i < position; i++) {
                    tmpHead = tmpHead.Next;
                }

                newNode.Next = tmpHead.Next;
                tmpHead.Next = newNode;

                Size++;
            }

            
        }
        public void Remove(int position) {
            if (position < 0 || position >= Size) {
                throw new ArgumentOutOfRangeException();

            } else if (position == 0) {
                Head = Head.Next;
                Size--;
            } else {
                Node<T> tmpHead = Head;
                Node<T> previous = null;
                for (var i = 0; tmpHead is not null && i < position; i++) {
                    previous = tmpHead;
                    tmpHead = tmpHead.Next;
                }

                previous.Next = tmpHead.Next;
                Size--;
            }
        }

        public IEnumerable<T> GetEnum() {
            Node<T> tmpHead = Head;

            // all elements where a next attribute exists
            while (tmpHead is not null) {
                yield return tmpHead.Item;
                tmpHead = tmpHead.Next;
            }
        }

    }
}
