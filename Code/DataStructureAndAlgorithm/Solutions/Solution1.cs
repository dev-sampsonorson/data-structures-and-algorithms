using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DataStructureAndAlgorithm.Core;
using System.Linq;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution1 : ISolution {

        string[] nemo;
        string[] everyone;
        string[] large;

        int[] boxes;

        public Solution1() {
            this.nemo = new string[] { "nemo" };
            this.everyone = new string[] {
                "dory", "bruce", "marlin", "nemo", "gill",
                "bloat", "nigel", "squirt", "darla", "hank"
            };
            this.large = Enumerable.Repeat("nemo", 100000).ToArray();
            this.boxes = new []{ 0, 1, 2, 3, 4, 5 };
        }

        public void Run() {
            // FindNemo(nemo);
            // FindNemo(everyone);
            FindNemo(large);
        }

        private void FindNemo(string[] array) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == "nemo") {
                    Console.WriteLine("Found NEMO!");
                }
            }
        }

        private void CompressAllBoxes(string[] boxes) {
            foreach(string box in boxes) {
                Console.WriteLine(box);
            }
        }

        private void LogFirstTwoBoxes(string[] boxes) {
            Console.WriteLine(boxes[0]); // O(1)
            Console.WriteLine(boxes[1]); // O(1)

            // O(1) + O(1) = O(2) = O(1)
        }

        // O(4n + 3)
        private int FunChallenge(int[] input) {
            int a = 10; // O(1)
            a = 50 + 3; // O(1)

            for (int i = 0; i < input.Length; i++) { // O(n)
                AnotherFunction(); // O(n)
                bool stranger = true; // O(n)
                a++; // O(n)
            }

            return a; // O(1)
        }

        private void AnotherFunction() {

        }

        // O(7n = 4) = O(n)
        private void AnotherFunChallenge(IList<string> input) {
            int a = 5;  // O(1)
            int b = 10; // O(1)
            int c = 50; // O(1)
            for (int i = 0; i < input.Count; i++) { // O(n)
                int x = i + 1; // O(n)
                int y = i + 2; // O(n)
                int z = i + 3; // O(n)
            }

            for (int j = 0; j < input.Count; j++) { // O(n)
                int p = j * 2; // O(n)
                int q = j * 2; // O(n)
            }
            string whoAmI = "I don't know"; // O(1)
        }

        // O(103 + 3*(n/2)) = O(1 + n/2) = O(n) - dropped the constants
        private void PrintFirstItemThenFirstHalfThenSayHi100Times(string[] items) {
            Console.WriteLine(items[0]); // O(1)

            double middleIndex = Math.Floor(items.Length / 2.0); // O(1)
            int index = 0; // O(1)

            while (index < middleIndex) { // O(n/2)
                Console.WriteLine(items[index]); // O(n/2)
                index++; // O(n/2)
            }

            for (int i = 0; i < 100; i++) { // O(100)
                Console.WriteLine("hi"); // O(100)
            }
        }

        // O(n + n) = O(2n) = O(n)
        private void compressBoxesTwice(string[] boxes) {
            foreach(string box in boxes) {
                Console.WriteLine(box);
            }

            foreach (string box in boxes) {
                Console.WriteLine(box);
            }
        }

        // O(n + n^2) = O(n^2)
        private void PrintAllNumbersThenAllPairSums(int[] numbers) {
            Console.WriteLine("these are the numbers:");
            foreach(int number in numbers) {
                Console.WriteLine(number);
            }

            Console.WriteLine("and these are their sums:");
            foreach(int firstNumber in numbers) {
                foreach(int secondNumber in numbers) {
                    Console.WriteLine(firstNumber + secondNumber);
                }
            }
        }

        private void NFacRuntimeFunc(int n) {
            for (int i = 0; i < n; i++) {
                NFacRuntimeFunc(n - 1);
            }
        }
    }
}
