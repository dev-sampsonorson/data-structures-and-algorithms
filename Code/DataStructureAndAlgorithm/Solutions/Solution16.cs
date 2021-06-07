using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution16 : ISolution {

        private class Input16 : IInput {
            public int[] Nums;
            public int Steps;

            public Input16(int[] nums, int steps) {
                this.Nums = nums;
                this.Steps = steps;
            }
        }

        public void Run() {
            List<Input16> input = new List<Input16> {
                new Input16(new [] { 1, 2, 3, 4, 5, 6, 7 }, 3),
                new Input16(new [] { -1, -100, 3, 99 }, 2),
            };

            this.ExecuteSolves<Input16, int[]>(input);

        }

        private class First : ISolve<Input16, int[]> {
            public string Description => "First solution";

            public int[] Implementation(Input16 input) {
                int[] nums = input.Nums;
                int size = input.Nums.Length;
                int steps = input.Steps;

                int[] result = new int[size];

                for (int i = 0; i < size; i++) {
                    int p = (i + steps) % size;

                    result[p] = nums[i];
                }

                return result;
            }

        }

        private class Second : ISolve<Input16, int[]> {
            public string Description => "Second solution";

            public int[] Implementation(Input16 input) {
                int[] nums = input.Nums;
                int size = input.Nums.Length;
                int steps = input.Steps;
                HashSet<int> set = new HashSet<int>();

                int i = 0;
                int moves = 0;
                int item = nums[i];

                while (moves < size) {
                    int p = (i + steps) % size;

                    if (!set.Contains(p)) {
                        int temp = nums[p];
                        nums[p] = item;
                        item = temp;

                        set.Add(p);
                        moves += 1;
                    } else {
                        p += 1;
                        item = nums[p];
                    }

                    i = p;
                }

                return nums;
            }

        }
    }
}
