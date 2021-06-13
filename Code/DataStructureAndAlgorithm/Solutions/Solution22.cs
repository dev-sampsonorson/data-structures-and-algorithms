using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution22 : ISolution {
        public void Run() {
            this.ExecuteSolves<InputVoid, ReturnVoid>(null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First Implementation";

            public ReturnVoid Implementation(InputVoid input) {
                /*var queue = new Queue<string>();
                queue.Enqueue("google");
                queue.Enqueue("Udemy");
                queue.Enqueue("Discord");
                var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };
                Console.WriteLine(JsonSerializer.Serialize(queue, options));


                Console.WriteLine($"{queue.Dequeue()}");
                Console.WriteLine($"{queue.Dequeue()}");
                Console.WriteLine($"{queue.Dequeue()}");
                Console.WriteLine($"{queue.IsEmpty()}");
                Console.WriteLine(JsonSerializer.Serialize(queue, options));*/

                return null;
            }
        }

        private class QueueUsingStacks : ISolve<InputVoid, ReturnVoid> {
            public string Description => "Implementation of Queue using Stacks";

            public ReturnVoid Implementation(InputVoid input) {
                var queue = new QueueUsingStacks<string>();
                queue.Enqueue("google");
                queue.Enqueue("Udemy");
                queue.Enqueue("Discord");
                var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };
                Console.WriteLine(JsonSerializer.Serialize(queue, options));


                Console.WriteLine($"{queue.Dequeue()}");
                Console.WriteLine($"{queue.Dequeue()}");
                //Console.WriteLine($"{queue.Dequeue()}");
                Console.WriteLine($"{queue.IsEmpty()}");
                Console.WriteLine(JsonSerializer.Serialize(queue, options));

                return null;
            }
        }

        private class Node<T> {
            public T Value { get; set; }
            public Node<T> Next { get; set; }

            public Node(T value) {
                this.Value = value;
                this.Next = null;
            }

            public Node(T value, Node<T> next) {
                this.Value = value;
                this.Next = next;
            }
        }

        private class Queue<T> {

            public Node<T> First { get; private set; }
            public Node<T> Last { get; private set; }
            public int Length { get; private set; }

            public T Peek() {
                return First.Value;
            }

            public Queue<T> Enqueue(T value) {
                Node<T> newNode = new Node<T>(value);

                if (First == null)
                    First = newNode;

                if (this.Last != null)
                    this.Last.Next = newNode;
                
                this.Last = newNode;
                this.Length += 1;

                return this;
            }

            public T Dequeue() {
                T value = First.Value;
                First = First.Next;

                if (First == null)
                    Last = null;

                this.Length -= 1;

                return value;
            }

            public bool IsEmpty() {
                return this.Length == 0;
            }

        }

        private class QueueUsingStacks<T> {
            public Stack<T> Left { get; private set; } = new Stack<T>();
            public Stack<T> Right { get; private set; } = new Stack<T>();


            public T Peek() {
                if (!Left.IsEmpty())
                    return this.Left.Peek();

                if (!Right.IsEmpty()) {
                    while (!Right.IsEmpty())
                        Left.Push(Right.Pop());

                    return this.Left.Peek();
                }

                return default(T);
            }

            public QueueUsingStacks<T> Enqueue(T value) {
                while(!Left.IsEmpty())
                    Right.Push(Left.Pop());

                Right.Push(value);

                return this;
            }

            public T Dequeue() {
                while (!Right.IsEmpty())
                    Left.Push(Right.Pop());

                return Left.Pop();
            }

            public bool IsEmpty() {
                if (!Left.IsEmpty())
                    return false;

                return this.Right.Length == 0;
            }



        }

        private class Stack<T> {
            public List<T> Nodes { get; private set; } = new List<T>();
            public int Length { get { return this.Nodes.Count; } }

            public T Peek() {
                if (Nodes.Count == 0)
                    throw new Exception("Stack empty");

                return Nodes[Nodes.Count - 1];
            }

            public Stack<T> Push(T value) {
                Nodes.Add(value);

                return this;
            }

            public T Pop() {
                if (Nodes.Count == 0)
                    throw new Exception("Stack empty");

                int index = Nodes.Count - 1;
                T item = Nodes[index];
                Nodes.RemoveAt(index);

                return item;
            }

            public bool IsEmpty() {
                return Nodes.Count == 0;
            }
        }
    }
}
