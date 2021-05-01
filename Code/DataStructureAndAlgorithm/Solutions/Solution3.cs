using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution3 : ISolution {
        int[] n;

        public Solution3() {
            n = new int[] { 1, 2, 3, 4, 5 };
        }

        // Space Complexity = O(1)
        public void Run() {
            for (int i = 0; i < n.Length; i++) {
                Console.WriteLine("boooooo!");
            }
        }

        // Space Complexity = O(n)
        private string[] ArrayOfHiNTimes(int n) {
            string[] hiArray = new string[n];
            for (int i = 0; i < n; i++) {
                hiArray[i] = "hi";
            }
            return hiArray;
        }

        private void FindFirstAndNth() {
            string[] array = new string[] { "hi", "my", "teddy" };
            string firstValue = array[0]; // O(1)
            string nthValue = array[array.Length - 1]; // O(1)
        }


        private class Tweet {
            public string Message;
            public int Date;

            public Tweet(string message, int date) {
                this.Message = message;
                this.Date = date;
            }
        }

        private void CompareDateOfTweets() {
            Tweet[] tweets = new Tweet[] {
                new Tweet("hi", 2012),
                new Tweet("my", 2014),
                new Tweet("teddy", 2018)
            };

            // Time Complexity - O(n^2)

            string variable = "dfaewrewqrewrwqrewqrewqrwqrwrewqrqw";
            int count = variable.Length;
        }
    }
}
