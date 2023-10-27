﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// TODO: Review LinkedList Comments

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

            if (Size != 0) {
                newNode.Next = Head;
            }

            Head = newNode;
            Size++;
        }

        public void AddLast(T item) {
            Node<T> newNode = new Node<T>();
            newNode.Item = item;
            newNode.Next = null;

            if (Size == 0) {
                Head = newNode;
            } else {
                Node<T>? tmpNode = Head;

                // all elements where a next attribute exists
                while (tmpNode.Next is not null) {
                    tmpNode = tmpNode.Next;
                }
                tmpNode.Next = newNode;
            }

            Size++;

        }


        public void AddAfter(int position, T item) {
            if (position < 0 || position >= Size) {
                throw new ArgumentOutOfRangeException();

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
        public void Remove(int position) {
            if (position < 0 || Size < 1 || position >= Size) {
                throw new ArgumentOutOfRangeException();

            } else if (Size == 1) {
                Head = null;
                Size--;

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

        public IEnumerable<T> GetEnum() {
            Node<T>? tmpNode = Head;

            // all elements where a next attribute exists
            while (tmpNode is not null) {
                yield return tmpNode.Item;
                tmpNode = tmpNode.Next;
            }
        }

    }
}