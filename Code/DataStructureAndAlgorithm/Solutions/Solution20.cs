using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution20 : ISolution {

        public void Run() {

            this.ExecuteSolves<InputVoid, ReturnVoid>(null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First solution";

            public ReturnVoid Implementation(InputVoid input) {
                var ll = new DoublyLinkedList<int>(10);
                ll.Append(5);
                ll.Append(16);
                ll.Prepend(1);
                var settings = new JsonSerializerSettings { MaxDepth = 10, PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                Console.WriteLine(JsonConvert.SerializeObject(ll, settings));
                Utility.PrintArray<int>(ll.PrintList());

                //ll.Prepend(1);

                //ll.Insert(2, 55);

                //var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };
                //Console.WriteLine(JsonSerializer.Serialize(ll, options));

                //Utility.PrintArray<int>(ll.PrintList());
                //ll.Remove(4);
                //Utility.PrintArray<int>(ll.PrintList());

                return null;
            }
        }

        private class Node<T> {
            public T Value { get; set; }
            public Node<T> Prev { get; set; }
            public Node<T> Next { get; set; }

            public Node(T value) {
                this.Value = value;
                this.Prev = null;
                this.Next = null;
            }

            public Node(T value, Node<T> prev, Node<T> next) {
                this.Value = value;
                this.Prev = prev;
                this.Next = next;
            }
        }

        private class DoublyLinkedList<T> {

            public Node<T> Head { get; private set; }
            public Node<T> Tail { get; private set; }
            public int Length { get; private set; }

            public DoublyLinkedList(T value) {
                this.Head = new Node<T>(value);
                this.Tail = this.Head;
                this.Length = 1;
            }

            public DoublyLinkedList<T> Append(T value) {
                Node<T> newNode = new Node<T>(value, this.Tail, null);

                this.Tail.Next = newNode;
                this.Tail = newNode;
                this.Length += 1;

                return this;
            }

            public DoublyLinkedList<T> Prepend(T value) {
                Node<T> newNode = new Node<T>(value, null, this.Head);
                this.Head.Prev = newNode;
                this.Head = newNode;
                this.Length += 1;

                return this;
            }

            public DoublyLinkedList<T> Insert(int index, T value) {
                if (index < 0 || index >= this.Length)
                    throw new Exception("Linked List: index out of bounds");

                if (index == 0) Prepend(value);

                var prevNode = TraverseToIndex(index - 1);
                var indexNode = prevNode.Next;

                var newNode = new Node<T>(value, prevNode, indexNode);

                prevNode.Next = newNode;
                indexNode.Prev = newNode;
                this.Length += 1;

                return this;
            }

            public DoublyLinkedList<T> Remove(int index) {
                if (index < 0 || index >= this.Length)
                    throw new Exception("Linked List: index out of bounds");

                Node<T> nextNode = null, prevNode = null, nodeToDelete = null;

                if (index == 0) {
                    nextNode = this.Head.Next;
                    nextNode.Prev = null;
                    this.Head.Next = null;
                    this.Head = nextNode;
                } else {
                    prevNode = TraverseToIndex(index - 1);
                    nodeToDelete = prevNode.Next;
                    nextNode = nodeToDelete.Next;

                    nodeToDelete.Prev = null;
                    nodeToDelete.Next = null;
                    prevNode.Next = nextNode;

                    if (nextNode != null)
                        nextNode.Prev = prevNode;
                }

                this.Length -= 1;

                return this;
            }

            public T[] PrintList() {
                T[] array = new T[this.Length];
                Node<T> currentNode = this.Head;

                for (int i = 0; i < this.Length; i++) {
                    array[i] = currentNode.Value;
                    currentNode = currentNode.Next;
                }

                return array;
            }

            private Node<T> TraverseToIndex(int index = 0, int counter = -1, Node<T> node = null) {
                if (index < 0 || index >= this.Length)
                    throw new Exception("Linked List: index out of bounds");

                node = node ?? this.Head;
                counter += 1;

                if (index == 0) return this.Head;
                if (index == this.Length - 1) return this.Tail;

                if (index == counter)
                    return node;

                if (node.Next != null)
                    return TraverseToIndex(index, counter, node.Next);

                return null;
            }

        }
    }
}
