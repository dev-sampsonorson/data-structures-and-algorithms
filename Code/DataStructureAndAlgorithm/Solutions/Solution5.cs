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

                // Third doesn't work with this unsorted
                new Input5(new int[] { 6, 4, 3, 2, 1, 7 }, 9),
            };

            this.ExecuteSolves<Input5, bool>(inputs);
        }

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

            public string Description => "Works with sorted and unsorted data";

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

            public string Description => "Works with sorted and unsorted data";

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

            public string Description => "This solution doesn't work with unsorted data";

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
