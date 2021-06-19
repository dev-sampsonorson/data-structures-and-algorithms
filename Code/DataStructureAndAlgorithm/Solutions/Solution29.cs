using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution29 : ISolution {
        public void Run() {
            List<Input29> inputs = new List<Input29>() {
                new Input29(new int[] { 6, 5, 3, 1, 8, 7, 2, 4 }),
                new Input29(new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
            };

            this.ExecuteSolves<Input29, int[]>(inputs);
        }

        private class Input29 : IInput {
            public int[] Items;
            public Input29(int[] items) => this.Items = items;
        }

        private class First : ISolve<Input29, int[]> {
            public string Description => "First implementation";

            public int[] Implementation(Input29 input) {
                int[] list = input.Items.Clone() as int[];
                int len = list.Length;

                for (int i = 0; i < len; i++) {
                    int smallestIndex = i;
                    for (int j = i + 1; j < len; j++) {
                        if (list[j] < list[smallestIndex])
                            smallestIndex = j;
                    }

                    int temp = list[i];
                    list[i] = list[smallestIndex];
                    list[smallestIndex] = temp;
                }


                return list;
            }
        }


    }
}
