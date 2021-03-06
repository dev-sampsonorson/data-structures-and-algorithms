using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution23 : ISolution {

        public void Run() {
            this.ExecuteSolves<InputVoid, ReturnVoid>(null, null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First Implementation";

            public ReturnVoid Implementation(InputVoid input) {
                var bst = new BinarySearchTree<int>();
                bst.Insert(9);
                bst.Insert(4);
                bst.Insert(1);
                bst.Insert(6);
                bst.Insert(20);
                bst.Insert(170);
                bst.Insert(15);
                var options = new JsonSerializerOptions { MaxDepth = 10, WriteIndented = true };


                Console.WriteLine($"Lookup value: {bst.Lookup(13)?.Value.ToString() ?? "NULL"}");
                Console.WriteLine($"Min: {bst.Min()?.Value.ToString() ?? "NULL"}");
                Console.WriteLine($"Max: {bst.Max()?.Value.ToString() ?? "NULL"}");

                var kk = bst.Remove(170);

                Console.WriteLine(JsonSerializer.Serialize(bst, options));

                return null;
            }
        }

        private class Node<T> {

            public Node(T value) {
                this.Value = value;
                this.Left = null;
                this.Right = null;
            }

            public Node(T value, Node<T> left = null, Node<T> right = null) {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }

            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
        }


        private class BinarySearchTree<T> where T : IComparable<T> {
            public Node<T> Root { get; private set; }

            public BinarySearchTree() {
                this.Root = null;
            }

            public void Insert(T value) {
                Node<T> newNode = new Node<T>(value);
                if (this.Root == null) {
                    this.Root = newNode;
                } else {
                    Node<T> currentNode = this.Root;
                    while (true) {
                        T local = currentNode.Value;
                        if (local.CompareTo(value) > 0) {
                            if (currentNode.Left != null) {
                                currentNode = currentNode.Left;
                                continue;
                            }
                            currentNode.Left = newNode;
                        } else {
                            if (currentNode.Value.CompareTo(value) >= 0) {
                                continue;
                            }
                            if (currentNode.Right != null) {
                                currentNode = currentNode.Right;
                                continue;
                            }
                            currentNode.Right = newNode;
                        }
                        break;
                    }
                }
            }

            public Node<T> Lookup(T value) {
                if (this.Root == null)
                    return null;

                Node<T> currentNode = this.Root;
                while(currentNode != null) {
                    if (currentNode.Value.CompareTo(value) > 0) {
                        currentNode = currentNode.Left;
                    } else if (currentNode.Value.CompareTo(value) < 0) {
                        currentNode = currentNode.Right;
                    } else if (currentNode.Value.CompareTo(value) == 0) {
                        break;
                    }

                }

                return currentNode;
            }

            public Node<T> Max(Node<T> node = null) {
                node ??= this.Root;
                while (node.Right != null)
                    node = node.Right;

                return node;
            }

            public Node<T> Min(Node<T> node = null) {
                node ??= this.Root;
                while (node.Left != null)
                    node = node.Left;

                return node;
            }

            public bool Remove(T value) {
                if (this.Root == null)
                    return false;

                Node<T> parentNode = null;
                Node<T> currentNode = this.Root;

                while(currentNode != null) {
                    if (currentNode.Value.CompareTo(value) > 0) {
                        parentNode = currentNode;
                        currentNode = currentNode.Left;
                    } else if (currentNode.Value.CompareTo(value) < 0) {
                        parentNode = currentNode;
                        currentNode = currentNode.Right;
                    } else if (currentNode.Value.CompareTo(value) == 0) {
                        if (currentNode.Right == null) {
                            if (parentNode == null) {
                                this.Root = currentNode.Left;
                            } else {
                                // if parent > current value, make current
                                // left child a child of parent
                                if (parentNode.Value.CompareTo(currentNode.Value) > 0) {
                                    parentNode.Left = currentNode.Left;
                                } else if (parentNode.Value.CompareTo(currentNode.Value) < 0) {
                                    parentNode.Right = currentNode.Left;
                                }
                            }
                        } else if (currentNode.Right.Left == null) {
                            if (parentNode == null) {
                                currentNode.Left.Right = this.Root.Right;
                                this.Root = currentNode.Left;
                            } else {
                                currentNode.Right.Left = currentNode.Left;

                                if (currentNode.Value.CompareTo(parentNode.Value) < 0) {
                                    parentNode.Left = currentNode.Right;
                                } else if (currentNode.Value.CompareTo(parentNode.Value) > 0) {
                                    parentNode.Right = currentNode.Right;
                                }
                            }
                        } else {
                            Node<T> leftmost = currentNode.Right.Left;
                            Node<T> leftmostParent = currentNode.Right;
                            while (leftmost.Left != null) {
                                leftmostParent = leftmost;
                                leftmost = leftmost.Left;
                            }

                            // parent's left subtree is not leftmost's 
                            // right subtree
                            leftmostParent.Left = leftmost.Right;
                            leftmost.Left = currentNode.Left;
                            leftmost.Right = currentNode.Right;

                            if (parentNode == null) {
                                this.Root = leftmost;
                            } else {
                                if (currentNode.Value.CompareTo(parentNode.Value) < 0) {
                                    parentNode.Left = leftmost;
                                } else if (currentNode.Value.CompareTo(parentNode.Value) > 0) {
                                    parentNode.Right = leftmost;
                                }
                            }
                        }


                        return true;
                    }
                }

                return false;
            }
        }
    }


}
