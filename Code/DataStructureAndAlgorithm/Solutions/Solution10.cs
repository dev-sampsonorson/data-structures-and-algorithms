using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution10 : ISolution {
        public void Run() {
            List<Input10> inputs = new List<Input10> {
                new Input10(new int[] { 0, 3, 4, 31 }, new int[] { 4, 6, 30 }),
                new Input10(new int[] { }, new int[] { 4, 6, 30 }),
                new Input10(new int[] { 0, 3, 4, 31 }, new int[] { }),
                new Input10(new int[] { 0, 3, 4 }, new int[] { 4, 6, 30 })
            };

            this.ExecuteSolves<Input10, int[]>(inputs, result => {
                foreach(var item in result) {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            });
        }

        private class Input10 : IInput {
            public int[] Left;
            public int[] Right;

            public Input10(int[] left, int[] right) {
                this.Left = left;
                this.Right = right;
            }
        }

        private class First : ISolve<Input10, int[]> {
            public string Description => "Merge Sorted Array";

            public int[] Implementation(Input10 input) {
                int[] first = input.Left;
                int[] second = input.Right;

                int f = 0, s = 0, fLength = first.Length, sLength = second.Length;
                int r = 0;

                if (fLength == 0) return second;
                if (sLength == 0) return first;

                int[] result = new int[fLength + sLength];

                while(f < fLength || s < sLength) {
                    if (f >= fLength && s < sLength) {
                        result[r] = second[s];
                        s += 1;
                        r += 1;
                        continue;
                    }                        

                    if (s >= sLength && f < fLength) {
                        result[r] = first[f];
                        f += 1;
                        r += 1;
                        continue;
                    }

                    if (first[f] <= second[s]) {
                        result[r] = first[f];
                        f += 1;
                        r += 1;
                    } else {
                        result[r] = second[s];
                        s += 1;
                        r += 1;
                    }
                }

                return result;
            }
        }

        private class Second : ISolve<Input10, int[]> {
            public string Description => "Andrei solution";

            public int[] Implementation(Input10 input) {
                if (input.Left.Length == 0) return input.Right;
                if (input.Right.Length == 0) return input.Left;

                List<int> mergedArray = new List<int>();
                int? array1Item = input.Left[0];
                int? array2Item = input.Right[0];
                int i = 1, j = 1;

                while (array1Item.HasValue || array2Item.HasValue) {
                    if (!array2Item.HasValue || array1Item < array2Item) {
                        mergedArray.Add(array1Item.Value);
                        array1Item = (i < input.Left.Length) ? input.Left[i] : default(int?);
                        i++;
                    } else {
                        mergedArray.Add(array2Item.Value);
                        array2Item = (j < input.Right.Length) ? input.Right[j] : default(int?);
                        j++;
                    }
                }

                return mergedArray.ToArray();
            }
        }
    }
}
