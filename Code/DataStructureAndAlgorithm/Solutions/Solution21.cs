using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution21 : ISolution {
        public void Run() {

            this.ExecuteSolves<InputVoid, ReturnVoid>(null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First solution";

            public ReturnVoid Implementation(InputVoid input) {

                var stack = new Stack<string>();
                stack.Push("google");
                stack.Push("Udemy");
                stack.Push("Discord");
                var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };
                Console.WriteLine(JsonSerializer.Serialize(stack, options));


                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.IsEmpty()}");



                return null;
            }
        }

        private class Second : ISolve<InputVoid, ReturnVoid> {
            public string Description => "Second solution";

            public ReturnVoid Implementation(InputVoid input) {

                var stack = new StackUsingArray<string>();
                stack.Push("google");
                stack.Push("Udemy");
                stack.Push("Discord");
                var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };
                Console.WriteLine(JsonSerializer.Serialize(stack, options));


                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.Pop()}");
                Console.WriteLine($"{stack.IsEmpty()}");



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

        private class Stack<T> {

            public Node<T> Top { get; private set; }
            public Node<T> Bottom { get; private set; }
            public int Length { get; private set; }

            public T Peek() {
                return Top.Value;
            }

            public Stack<T> Push(T value) {
                var newNode = new Node<T>(value, Top);

                if (Top == null)
                    Bottom = newNode;

                Top = newNode;

                this.Length += 1;

                return this;
            }

            public T Pop() {
                // If stack is empty
                if (Top == null)
                    throw new Exception("Stack empty");

                var topValue = Top.Value;
                Top = Top.Next;

                if (Top == null)
                    Bottom = null;

                this.Length -= 1;

                return topValue;
            }

            public bool IsEmpty() {
                return Top == null;
            }
        }

        private class StackUsingArray<T> {
            public List<T> Nodes { get; private set; } = new List<T>();

            public T Peek() {
                if (Nodes.Count == 0)
                    throw new Exception("Stack empty");

                return Nodes[Nodes.Count - 1];
            }

            public StackUsingArray<T> Push(T value) {
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
