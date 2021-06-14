using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution25 : ISolution {
        public void Run() {

            List<Input25> inputs = new List<Input25> {
                new Input25(5),
                new Input25(7),
                new Input25(10)
            };

            this.ExecuteSolves<Input25, int>(inputs);
        }

        private class Input25: IInput {
            public int Number;

            public Input25(int number) {
                this.Number = number;
            }
        }

        private class Recursive : ISolve<Input25, int> {
            public string Description => "Recursive Implementation - O(n)";

            public int Implementation(Input25 input) => CalcFactorial(input.Number);

            private int CalcFactorial(int n) {
                if (n == 1)
                    return 1;

                return n * CalcFactorial(n - 1);
            }
        }

        private class Iterative : ISolve<Input25, int> {
            public string Description => "Iterative Implementation - O(n)";

            public int Implementation(Input25 input) {
                if (input.Number == 1) return 1;

                int result = 1;
                for (int i = input.Number; i > 1; i--)
                    result *= i;

                return result;
            }
        }
    }
}
