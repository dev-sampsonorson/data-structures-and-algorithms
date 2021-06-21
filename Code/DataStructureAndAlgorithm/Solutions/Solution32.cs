using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution32 : ISolution {
        public void Run() {
            List<Input32> inputs = new List<Input32>() {
                new Input32(new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 }),
                new Input32(new int[] { 6, 5, 3, 1, 8, 7, 2, 4 }),
                new Input32(new int[] { 10, 16, 8, 12, 15, 6, 3, 9, 5 })
            };

            this.ExecuteSolves<Input32, int[]>(inputs);
        }

        private class Input32 : IInput {
            public int[] Items;
            public Input32(int[] items) => this.Items = items;
        }

        private class First : ISolve<Input32, int[]> {
            public string Description => "First implementation";

            public int[] Implementation(Input32 input) {
                List<int> list = (input.Items.Clone() as int[]).ToList();
                int len = list.Count;

                QuickSort(list, 0, len - 1);

                return list.ToArray();
            }

            private void QuickSort(List<int> list, int left, int right) {

                if (left < right) {
                    int partitionIndex = Partition(list, left, right);

                    QuickSort(list, left, partitionIndex);
                    QuickSort(list, partitionIndex + 1, right);
                }
            }

            private int Partition(List<int> list, int left, int right) {

                int pivot = list[left];
                int i = left;
                int j = right + 1;

                while(i < j) {
                    do i++;
                    while (i < list.Count && list[i] <= pivot);

                    do j--;
                    while (j >= 0 && list[j] > pivot);

                    if (i < j)
                        (list[i], list[j]) = (list[j], list[i]);
                }

                (list[left], list[j]) = (list[j], list[left]);

                return j;
            }
        }
    }
}
