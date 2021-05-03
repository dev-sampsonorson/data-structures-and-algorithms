using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution5 : ISolution {
        public void Run() {
            int[] q1 = new int[] { 1, 2, 3, 9 };
            int[] q2 = new int[] { 1, 2, 4, 4 };

            int sum1 = 8;
            int sum2 = 8;

            //bool result = Code1(q1, sum1);
            bool result = Code3(q2, sum2);


            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// sorted array
        /// integer array
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sum"></param>
        /// <returns></returns>

        private bool Code1(int[] array, int sum) {
            for (int i = 0; i < array.Length; i++) {
                for (int j = i + 1; j < array.Length; j++) {
                    if ((array[i] + array[j]) == sum) {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Code2(int[] array, int sum) {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < array.Length; i++) {
                int complement = sum - array[i];
                if (set.Contains(array[i]))
                    return true;
                
                set.Add(complement);
            }

            return false;
        }

        private bool Code3(int[] array, int sum) {
            int startIndex = 0, endIndex = array.Length - 1;

            while (startIndex < endIndex) {
                int currentSum = array[startIndex] + array[endIndex];

                if (currentSum > sum) {
                    // start + end > sum
                    endIndex -= 1;
                } else if (currentSum < sum) {
                    // start + end < sum
                    startIndex += 1;
                } else {
                    return true;
                }
            }

            return false;
        }
    }
}
