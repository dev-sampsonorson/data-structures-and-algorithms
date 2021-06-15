using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution28 : ISolution {
        public void Run() {
            List<Input28> inputs = new List<Input28>() {
                new Input28(new int[] { 6, 5, 3, 1, 8, 7, 2, 4 }),
                new Input28(new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
            };

            this.ExecuteSolves<Input28, int[]>(inputs);
        }

        private class Input28 : IInput {
            public int[] Items;
            public Input28(int[] items) => this.Items = items;
        }

        private class First : ISolve<Input28, int[]> {
            public string Description => "First implementation";

            public int[] Implementation(Input28 input) {
                int[] list = input.Items;

                int len = list.Length;
                int lastIndex = len - 1;
                int passes = 0;

                while(lastIndex > 0) {

                    int left = 0, right = 1;
                    bool swap = false;
                    while (right <= lastIndex) {
                        if (list[left] > list[right]) {
                            int temp = list[right];
                            list[right] = list[left];
                            list[left] = temp;

                            swap = true;
                        }

                        right += 1;
                        left += 1;
                    }

                    passes += 1;


                    if (!swap) break;
                    lastIndex -= 1;
                }
                Console.WriteLine($"Passes: {passes}");

                return list;
            }
        }

        private class Second : ISolve<Input28, int[]> {
            public string Description => "Second implementation";

            public int[] Implementation(Input28 input) {
                int[] list = input.Items.Clone() as int[];
                int len = list.Length;

                for (int i = 1; i <= len; i++) {
                    bool swap = false;
                    for (int j = 0; j < len - i; j++) {
                        if (list[j] > list[j + 1]) {
                            int temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;

                            swap = true;
                        }
                    }

                    if (!swap) break;
                }

                return list;
            }
        }

    }
}
