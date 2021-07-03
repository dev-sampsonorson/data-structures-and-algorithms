using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution33 : ISolution {
        public void Run() {
            List<Input33> inputs = new List<Input33>() {
                new Input33(new string[] { "5", "2", "C", "D", "+" }),
                new Input33(new string[] { "5", "-2", "4", "C", "D", "+" })
            };

            this.ExecuteSolves<Input33, int>(inputs);
        }

        private class Input33 : IInput {
            public string[] Items;
            public Input33(string[] items) => this.Items = items;
        }

        private class First : ISolve<Input33, int> {
            public string Description => "First implementation";

            public int Implementation(Input33 input) {

                int totalPoints = 0;
                Stack<int> points = new Stack<int>();

                foreach (var p in input.Items) {
                    int point = 0;

                    if (p == "+") {
                        int top = points.Pop();
                        int following = points.Peek();

                        point = top + following;
                        points.Push(top);
                        points.Push(point);
                    } else if (p == "D") {
                        point = points.Peek() * 2;
                        points.Push(point);
                    } else if (p == "C") {
                        point = points.Pop() * -1;
                    } else {
                        point = Int32.Parse(p);
                        points.Push(point);
                    }

                    totalPoints += point;
                }

                return totalPoints;
            }
        }
    }
}
