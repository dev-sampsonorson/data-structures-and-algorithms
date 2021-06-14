using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution26 : ISolution {
        public void Run() {
            List<Input26> inputs = new List<Input26>() {
                new Input26(3),
                new Input26(8),
                new Input26(0),
                new Input26(1),
            };

            this.ExecuteSolves<Input26, int>(inputs);
        }

        private class Input26 : IInput {
            public int Index;

            public Input26(int index) => this.Index = index;
        }

        private class Recursive : ISolve<Input26, int> {
            public string Description => "Recursive Implementation - O(2^n)";

            public int Implementation(Input26 input) {
                return CalcFibonacciByIndex(input.Index);
            }

            private int CalcFibonacciByIndex(int index) {
                if (index == 0) return 0;
                if (index == 1) return 1;

                return CalcFibonacciByIndex(index - 2) + CalcFibonacciByIndex(index - 1);
            }
        }

        private class Iterative : ISolve<Input26, int> {
            public string Description => "Iterative Implementation - O(n)";

            public int Implementation(Input26 input) {
                int index = input.Index;

                if (index == 0) return 0;
                if (index == 1) return 1;

                int[] result = new int[index + 1];
                result[0] = 0;
                result[1] = 1;

                for (int i = 2; i <= index; i++) {
                    result[i] = result[i - 2] + result[i - 1];
                }

                return result[index];
            }
        }

        private class IterativeV2 : ISolve<Input26, int> {
            public string Description => "IterativeV2 Implementation - O(n)";

            public int Implementation(Input26 input) {
                int index = input.Index;

                int first = 0;
                int second = 1;

                for (int i = 1; i <= index; i++) {
                    /*int temp = first;
                    first = second;
                    second = temp + first;*/

                    (first, second) = (second, first + second);
                }

                return first;
            }
        }
    }
}
