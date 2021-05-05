using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution11 : ISolution {
        public void Run() {
            List<Input11> input = new List<Input11> {
                new Input11("fun&!! time"),
                new Input11("I love dogs")
            };

            this.ExecuteSolves<Input11, string>(input);
        }

        private class Input11 : IInput {
            public string Sentence;

            public Input11(string sentence) {
                this.Sentence = sentence;
            }
        }

        private class First : ISolve<Input11, string> {
            public string Description => "First solution";

            public string Implementation(Input11 input) {

                (string word, int length) longestWord = (string.Empty, 0);
                string[] words = input.Sentence.Split(' ');

                foreach (string w in words) {
                    int count = 0;
                    for (int i = 0; i < w.Length; i++) {
                        if (!char.IsPunctuation(w[i])) {
                            count += 1;
                        }
                    }

                    longestWord = longestWord.length >= count ? longestWord : (w, count);
                }

                return longestWord.word;
            }
        }
    }
}
