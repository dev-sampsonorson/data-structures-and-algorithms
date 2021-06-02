using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution12 : ISolution {

        private class Input12 : IInput {
            public int[] Nums;
            public int Target;

            public Input12(int[] nums, int target) {
                this.Nums = nums;
                this.Target = target;
            }
        }

        public void Run() {
            List<Input12> input = new List<Input12> {
                new Input12(new [] { 2, 7, 11, 15 }, 9),
                new Input12(new [] { 3, 2, 4 }, 6),
                new Input12(new [] { 3, 3 }, 6),
                new Input12(new [] { 2, 5, 3, 7, 11, 15 }, 9),
            };

            this.ExecuteSolves<Input12, int[]>(input);

        }

        private class First : ISolve<Input12, int[]> {
            public string Description => "First solution";

            public int[] Implementation(Input12 input) {
                IDictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < input.Nums.Length; i++) {
                    int complement = input.Target - input.Nums[i];

                    if (!map.ContainsKey(complement))
                        map.Add(input.Nums[i], i);
                    else
                        return new[] { map[complement], i };
                }

                return new int[] { };
            }
        }
    }
}
