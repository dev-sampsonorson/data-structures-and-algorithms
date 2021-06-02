using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution13 : ISolution {

        private class Input13 : IInput {
            public int[] Nums;

            public Input13(int[] nums) {
                this.Nums = nums;
            }
        }

        public void Run() {
            List<Input13> input = new List<Input13> {
                new Input13(new [] { -1, 7 }),
                new Input13(new [] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }),
                new Input13(new [] { 1 }),
                new Input13(new [] { 5, 4, -1, 7, 8 }),
            };

            this.ExecuteSolves<Input13, int>(input);
        }

        private class First : ISolve<Input13, int> {
            public string Description => "First solution";

            public int Implementation(Input13 input) {
                int[] nums = input.Nums;
                int currSum = 0;
                int max = nums[0];

                foreach (int n in nums) {
                    currSum += n;
                    currSum = Math.Max(currSum, n);
                    max = Math.Max(currSum, max);
                }

                return max;
            }
        }

        private class Second : ISolve<Input13, int> {
            public string Description => "Second solution";

            public int Implementation(Input13 input) {
                int[] nums = input.Nums;
                int size = nums.Length;
                int[] prefixSum = new int[size];
                int s = -1, e = 0, max = nums[0];

                for (int i = 0; i < size; i++) {
                    prefixSum[i] = nums[i] + (i == 0 ? 0 : prefixSum[i - 1]);
                }

                for (int j = 0; j < size; j++) {
                    int startN = s == -1 ? 0 : prefixSum[s];
                    max = Math.Max(max, prefixSum[j] - startN);
                    if (prefixSum[j] < startN)
                        s = j;
                }

                return max;
            }
        }
    }
}
