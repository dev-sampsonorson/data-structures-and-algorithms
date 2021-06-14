using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution24 : ISolution {
        public void Run() {
            this.ExecuteSolves<InputVoid, ReturnVoid>(null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First Implementation";

            public ReturnVoid Implementation(InputVoid input) {
                var graph = new Graph<int>();
                graph.AddVertex(0);
                graph.AddVertex(1);
                graph.AddVertex(2);
                graph.AddVertex(3);
                graph.AddVertex(4);
                graph.AddVertex(5);
                graph.AddVertex(6);
                graph.AddEdge(3, 1);
                graph.AddEdge(3, 4);
                graph.AddEdge(4, 2);
                graph.AddEdge(4, 5);
                graph.AddEdge(1, 2);
                graph.AddEdge(1, 0);
                graph.AddEdge(0, 2);
                graph.AddEdge(6, 5);

                graph.ShowConnections();


                return null;
            }
        }

        private class Graph<TNode> {

            public int NumberOfNodes { get; private set; }
            public IDictionary<TNode, List<TNode>> AdjacentList { get; private set; }

            public Graph() {
                AdjacentList = new Dictionary<TNode, List<TNode>>();
            }

            public void AddVertex(TNode node) {
                if (!this.AdjacentList.ContainsKey(node)) {
                    this.AdjacentList.Add(node, new List<TNode>());
                    this.NumberOfNodes += 1;
                }
            }

            public void AddEdge(TNode leftNode, TNode rightNode) {
                if (this.AdjacentList.ContainsKey(leftNode)) {
                    if (!this.AdjacentList[leftNode].Contains(rightNode))
                        this.AdjacentList[leftNode].Add(rightNode);
                }

                if (this.AdjacentList.ContainsKey(rightNode)) {
                    if (!this.AdjacentList[rightNode].Contains(leftNode))
                        this.AdjacentList[rightNode].Add(leftNode);
                }
            }

            public void ShowConnections() {
                foreach(var pair in AdjacentList) {
                    string connections = "";
                    foreach (var node in pair.Value)
                        connections += $"{node.ToString()}, ";

                    Console.WriteLine($"{pair.Key}: [{(connections.Length > 2 ? connections.Substring(0, connections.Length - 2) : "")}]");
                }
            }
        }
    }
}
