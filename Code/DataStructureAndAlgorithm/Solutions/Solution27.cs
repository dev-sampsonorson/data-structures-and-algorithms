using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution27 : ISolution {
        public void Run() {
            List<Input27> inputs = new List<Input27>() {
                new Input27("yoyo mastery")
            };

            this.ExecuteSolves<Input27, string>(inputs);
        }

        private class Input27 : IInput {
            public string Value;

            public Input27(string value) => this.Value = value;
        }

        private class Recursive : ISolve<Input27, string> {
            public string Description => "Recursive Implementation";

            public string Implementation(Input27 input) {
                return this.ReverseString(input.Value);
            }

            private string ReverseString(string value) {
                if (value.Length == 1) return value;

                return ReverseString(value.Substring(1)) + value.Substring(0, 1);
            }
        }

        private class Iterative : ISolve<Input27, string> {
            public string Description => "Iterative Implementation";

            public string Implementation(Input27 input) {
                char[] value = input.Value.ToCharArray();
                //string[] value = new[] { input.Value }; ;
                int len = value.Length;

                int left = 0, right = len - 1;

                while(left < right) {
                    //var temp = value[left];
                    //value[left] = value[right];
                    //value[right] = temp;

                    (value[left], value[right]) = (value[right], value[left]);

                    left += 1;
                    right -= 1;
                }

                return string.Join("", value);
            }
        }
    }
}
