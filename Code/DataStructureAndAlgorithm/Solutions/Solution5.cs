using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;
using System.Reflection;
using System.Linq;

namespace DataStructureAndAlgorithm.Solutions {
    /// <summary>
    /// sorted array
    /// integer array
    /// 
    /// </summary>
    public class Solution5 : ISolution {
        public void Run() {

            List<Input5> inputs = new List<Input5> {
                new Input5(new int[] { 1, 2, 3, 9 }, 8),
                new Input5(new int[] { 1, 2, 4, 4 }, 8),
                new Input5(new int[] { 1, 2, 3, 4, 6, 7 }, 9),
                new Input5(new int[] { 6, 4, 3, 2, 1, 7 }, 9),
            };

            this.ExecuteSolves<Input5>(inputs);

            /*List<ISolve<Input5, bool>> solves = new List<ISolve<Input5, bool>> {
                new First(),
                new Second(),
                new Third()
            };

            for (int j = 0; j < solves.Count; j++) {
                Console.WriteLine($"{solves[j].GetType().Name}");
                for (int i = 0; i < inputs.Count; i++) {
                    bool result = solves[j].Implementation(inputs[i]);
                    Console.WriteLine($"Input {i + 1}, Result: {result}");
                }
                Console.WriteLine();
                Console.WriteLine();

            }*/
        }

        /*private void ExecuteSolves<TInput>(ISolution instance, List<TInput> inputs) where TInput : class, IInput {
            Type[] types = instance.GetType().GetNestedTypes(BindingFlags.NonPublic);

            foreach (Type t in types) {
                if (t.FindInterfaces((Type t, Object o) => t.Name.StartsWith(o.ToString()), "ISolve").Length <= 0) 
                    continue;

                ISolve<TInput, bool> solveInstance = Activator.CreateInstance(t) as ISolve<TInput, bool>;

                Console.WriteLine($"{solveInstance.GetType().Name}");
                for (int i = 0; i < inputs.Count; i++) {
                    bool result = solveInstance.Implementation(inputs[i]);
                    Console.WriteLine($"Input {i + 1}, Result: {result}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }*/

        private class Input5 : IInput {
            public int[] Data;
            public int Sum;

            public Input5(int[] data, int sum) {
                this.Data = data;
                this.Sum = sum;
            }
        }

        private class First : ISolve<Input5, bool> {

            private int[] array;
            private int sum;

            public bool Implementation(Input5 input) {
                this.array = input.Data;
                this.sum = input.Sum;

                for (int i = 0; i < this.array.Length; i++) {
                    for (int j = i + 1; j < this.array.Length; j++) {
                        if ((this.array[i] + array[j]) == this.sum) {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        private class Second : ISolve<Input5, bool> {

            private int[] array;
            private int sum;

            public bool Implementation(Input5 input) {
                this.array = input.Data;
                this.sum = input.Sum;

                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < this.array.Length; i++) {
                    int complement = this.sum - this.array[i];
                    if (set.Contains(this.array[i]))
                        return true;

                    set.Add(complement);
                }

                return false;
            }
        }

        private class Third : ISolve<Input5, bool> {

            private int[] array;
            private int sum;

            public bool Implementation(Input5 input) {
                this.array = input.Data;
                this.sum = input.Sum;

                int startIndex = 0, endIndex = array.Length - 1;

                while (startIndex < endIndex) {
                    int currentSum = this.array[startIndex] + this.array[endIndex];

                    if (currentSum > this.sum) {
                        // start + end > sum
                        endIndex -= 1;
                    } else if (currentSum < this.sum) {
                        // start + end < sum
                        startIndex += 1;
                    } else {
                        return true;
                    }
                }

                return false;
            }
        }
    }

}
