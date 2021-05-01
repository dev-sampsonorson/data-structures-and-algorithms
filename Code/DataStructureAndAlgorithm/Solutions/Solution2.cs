using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution2 : ISolution {

        string[] boxes;

        public Solution2() {
            this.boxes = new string[]{ "a", "b", "c", "d", "e" };
        }
        public void Run() {
            // O(n * n) = O(n^2)
            for (int i = 0; i < this.boxes.Length; i++) {
                for (int j = i + 1; j < this.boxes.Length; j++) {
                    Console.WriteLine($"Pair {this.boxes[i]}, {this.boxes[j]}");
                }
            }
        }
    }
}
