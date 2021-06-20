using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution31 : ISolution {
        public void Run() {
            List<Input31> inputs = new List<Input31>() {
                new Input31(new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 }),
                new Input31(new int[] { 6, 5, 3, 1, 8, 7, 2, 4 })
            };

            this.ExecuteSolves<Input31, int[]>(inputs);
        }

        private class Input31 : IInput {
            public int[] Items;
            public Input31(int[] items) => this.Items = items;
        }

        private class First : ISolve<Input31, int[]> {
            public string Description => "First implementation";

            public int[] Implementation(Input31 input) {
                List<int> list = (input.Items.Clone() as int[]).ToList();
                int len = list.Count;

                return MergeSort(list).ToArray();
            }

            private List<int> MergeSort(List<int> list) {
                if (list.Count == 1) {
                    return list;
                }

                int len = list.Count;
                int mid = (int)Math.Floor(list.Count / 2.0);

                List<int> left = list.GetRange(0, mid);
                List<int> right = list.GetRange(mid, len - mid);

                return Merge(MergeSort(left), MergeSort(right));
            }

            private List<int> Merge(List<int> left, List<int> right) {
                List<int> newList = new List<int>();

                int leftIndex = 0, rightIndex = 0;
                while (leftIndex < left.Count && rightIndex < right.Count) {
                    if (right[rightIndex] < left[leftIndex]) {
                        newList.Add(right[rightIndex]);
                        rightIndex += 1;
                    } else {
                        newList.Add(left[leftIndex]);
                        leftIndex += 1;
                    }
                }

                if (leftIndex < left.Count) {
                    for (int i = leftIndex; i < left.Count; i++)
                        newList.Add(left[i]);
                }

                if (rightIndex < right.Count) {
                    for (int i = rightIndex; i < right.Count; i++)
                        newList.Add(right[i]);
                }

                return newList;
            }
        }
    }
}
