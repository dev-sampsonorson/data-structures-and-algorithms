using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution30 : ISolution {
        public void Run() {
            List<Input30> inputs = new List<Input30>() {
                new Input30(new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
            };

            this.ExecuteSolves<Input30, int[]>(inputs);
        }

        private class Input30 : IInput {
            public int[] Items;
            public Input30(int[] items) => this.Items = items;
        }

        private class First : ISolve<Input30, int[]> {
            public string Description => "First implementation";

            public int[] Implementation(Input30 input) {
                List<int> list = (input.Items.Clone() as int[]).ToList();
                int len = list.Count;

                for (int i = 1; i < len; i++) {

                    int insertIndex = i;
                    for (int j = i - 1; j >= 0; j--) {

                        if (list[i] < list[j]) {
                            insertIndex = j;
                        } else {
                            break;
                        }
                    }

                    if (insertIndex != i) {
                        int itemToRemove = list[i];
                        list.RemoveAt(i);
                        list.Insert(insertIndex, itemToRemove);
                    }
                }


                return list.ToArray();
            }
        }
    }
}
