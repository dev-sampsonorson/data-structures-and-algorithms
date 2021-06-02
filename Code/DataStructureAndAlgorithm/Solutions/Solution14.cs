using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution14 : ISolution {

        private class Input14 : IInput {
            public int[] Nums;

            public Input14(int[] nums) {
                this.Nums = nums;
            }
        }

        public void Run() {
            List<Input14> input = new List<Input14> {
                new Input14(new [] { 0, 1, 0, 3, 12 }),
                new Input14(new [] { 0 }),
            };

            this.ExecuteSolves<Input14, int[]>(input);

        }

        private class First : ISolve<Input14, int[]> {
            public string Description => "First solution";

            public int[] Implementation(Input14 input) {
                int size = input.Nums.Length;
                int[] nums = new int[size];
                input.Nums.CopyTo(nums, 0);

                if (size == 1 || size == 0)
                    return nums;

                for (int i = 0; i < size; i++) {
                    if (nums[i] != 0)
                        continue;

                    ShiftLeft(i, nums);
                    nums[size - 1] = 0;
                }

                return nums;
            }

            public void ShiftLeft(int startIndex, int[] nums) {
                for (int i = startIndex; i < nums.Length - 1; i++) {
                    nums[i] = nums[i + 1];
                }
            }

        }



        private class Second : ISolve<Input14, int[]> {
            public string Description => "Second solution";

            public int[] Implementation(Input14 input) {
                int size = input.Nums.Length;
                int[] nums = new int[size];
                input.Nums.CopyTo(nums, 0);

                if (size == 1 || size == 0)
                    return nums;

                int replaceIndex = 0;
                for (int i = 0; i < size; i++) {
                    if (nums[i] != 0) {
                        nums[replaceIndex] = nums[i];
                        replaceIndex++;
                    }
                }

                while (replaceIndex < size)
                    nums[replaceIndex++] = 0;

                return nums;
            }

        }
    }
}
