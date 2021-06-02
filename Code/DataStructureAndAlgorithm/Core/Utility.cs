using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithm.Core {
    public static class Utility {

        public static void PrintArray<T>(T[] array) {
            Console.Write("[");
            Console.Write($"{string.Join(", ", array)}");
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
