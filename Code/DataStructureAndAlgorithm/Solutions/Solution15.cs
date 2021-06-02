using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution15 : ISolution {

        private class Input15 : IInput {
            public int[] Nums;

            public Input15(int[] nums) {
                this.Nums = nums;
            }
        }

        public void Run() {
            List<Input15> input = new List<Input15> {
                new Input15(new [] { 1, 2, 3, 1 }),
                new Input15(new [] { 1, 2, 3, 4 }),
                new Input15(new [] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }),
            };

            this.ExecuteSolves<Input15, bool>(input);

        }

        private class First : ISolve<Input15, bool> {
            public string Description => "First solution";

            public bool Implementation(Input15 input) {
                HashSet<int> set = new HashSet<int>();

                foreach(int n in input.Nums) {
                    if (!set.Contains(n))
                        set.Add(n);
                    else
                        return true;
                }

                return false;
            }

        }
    }
}
