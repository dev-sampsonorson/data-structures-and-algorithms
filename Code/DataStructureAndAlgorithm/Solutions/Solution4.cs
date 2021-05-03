using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;
using System.Linq;

namespace DataStructureAndAlgorithm.Solutions {

    /// <summary>
    /// Given 2 arrays, create a function that let's a user know 
    /// (true/false) whether these two arrays contain any common items
    /// 
    /// should return false
    /// string[] array1 = new string[] { "a", "b", "c", "x" };
    /// string[] array2 = new string[] { "z", "y", "i" };
    /// 
    /// should return true
    /// string[] array1 = new string[] { "a", "b", "c", "x" };
    /// string[] array2 = new string[] { "z", "y", "x" };
    /// 
    /// 2 parameters - arrays - no size limit
    /// return true of false
    /// </summary>
    public class Solution4 : ISolution {
        public void Run() {
            string[] array1 = new string[] { "a", "b", "c", "x" };
            string[] array2 = new string[] { "z", "y", "i" };
            //bool result = Code2(array1, array2);

            string[] array3 = new string[] { "a", "b", "c", "x" };
            string[] array4 = new string[] { "z", "y", "x" };
            //bool result = Code2(array3, array4);

            bool result = Code3(array1, array2);

            Console.WriteLine($"Result: {result}");

        }


        // O(a*b) 
        public bool Code1(string[] arr1, string[] arr2) {
            for (int i = 0; i < arr1.Length; i++) {
                for (int j = 0; j < arr2.Length; j++) {
                    if (arr2[j] == arr1[i])
                        return true;
                }
            }

            return false;
        }
        
        public bool Code2(string[] arr1, string[] arr2) {
            Dictionary<string, bool> lookup = new Dictionary<string, bool>();

            for (int i = 0; i < arr1.Length; i++)
                lookup.Add(arr1[i], false);

            for (int i = 0; i < arr2.Length; i++) {
                if (!lookup.ContainsKey(arr2[i]))
                    lookup.Add(arr2[i], false);
                else
                    return true;
            }

            return false;
        }

        public bool Code3(string[] arr1, string[] arr2) {
            return arr1.Any(item => arr2.Contains(item));
        }
    }
}
