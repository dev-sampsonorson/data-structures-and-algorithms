using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;
using System.Linq;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution9 : ISolution {
        public void Run() {
            List<Input9> inputs = new List<Input9> {
                new Input9("Hi My name is Andrei")
            };

            try {
                this.ExecuteSolves<Input9, string>(inputs);
            } catch(Exception ex) {
                Console.WriteLine("Invalid input");
            }
        }

        private class Input9 : IInput {
            public string Data;

            public Input9(string data) => this.Data = data;
        }

        private class First : ISolve<Input9, string> {
            public string Description => "Reverse a string";

            public string Implementation(Input9 input) {
                // check our input
                if (input.Data.Length < 2)
                    throw new Exception("Invalid input for First");

                string s = input.Data;
                string reversed = string.Empty;

                for (int i = s.Length - 1; i >= 0; i--) {
                    reversed += s[i];
                }

                return reversed;
            }
        }

        private class Second : ISolve<Input9, string> {
            public string Description => "Reverse a string";

            public string Implementation(Input9 input) {
                if (input.Data.Length < 2)
                    throw new Exception("Invalid input for First");

                string s = input.Data;

                char[] sChars = s.ToCharArray();
                Array.Reverse(sChars);
                return String.Join("", new string(sChars));
            }
        }
    }
}
