using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution18 : ISolution {

        private class Input18 : IInput {
            public int[] Nums;

            public Input18(int[] nums) {
                this.Nums = nums;
            }
        }

        public void Run() {
            List<Input18> input = new List<Input18> {
                new Input18(new [] { 2,5,1,2,3,5,1,2,4 }),
                new Input18(new [] { 2,1,1,2,3,5,1,2,4 }),
                new Input18(new [] { 2,3,4,5 }),
                new Input18(new [] { 1, 1 }),
                new Input18(new [] { 1, 2 }),
            };

            this.ExecuteSolves<Input18, int?>(input);
        }

        private class First : ISolve<Input18, int?> {
            public string Description => "First Solution";

            public int? Implementation(Input18 input) {
                int size = input.Nums.Length;
                int[] nums = input.Nums;
                IDictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < size; i++) {
                    if (map.ContainsKey(nums[i]))
                        return nums[i];
                    else
                        map.Add(nums[i], i);
                }

                return null;
            }
        }

        private class Second : ISolve<Input18, int?> {
            public string Description => "Second Solution";

            public int? Implementation(Input18 input) {
                int size = input.Nums.Length;
                int[] nums = input.Nums;

                int pos = int.MaxValue;

                for (int i = 0; i < size; i++) {
                    for (int j = i + 1; j < size; j++) {
                        if (nums[i] == nums[j]) {
                            pos = j < pos ? j : pos;
                        }
                    }
                }

                return pos == int.MaxValue ? (int?)null : nums[pos];
            }
        }
    }
}
