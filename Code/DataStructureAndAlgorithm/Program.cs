using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        private static IList<SolutionInfo> solutionInfoList = new List<SolutionInfo> {
            new SolutionInfo(1, "Find Nemo"),
            new SolutionInfo(2, "Print All Pairs"),
            new SolutionInfo(3, "Boooooo"),
            new SolutionInfo(4, "Common terms in array"),
            new SolutionInfo(5, "Has pair with sum"),
            new SolutionInfo(6, "Integer overflow"),
            new SolutionInfo(7, "Array tryout"),
            new SolutionInfo(8, "My array implementation"),
            new SolutionInfo(9, "Reverse string"),
            new SolutionInfo(10, "Merge sorted array"),
            new SolutionInfo(11, "Longest word"),
            new SolutionInfo(12, "Two sum"),
            new SolutionInfo(13, "Maximum Subarray"),
            new SolutionInfo(14, "Move Zeroes"),
            new SolutionInfo(15, "Contains Duplicate"),
            new SolutionInfo(16, "Rotate Array"),
            new SolutionInfo(17, "Hash Table"),
            new SolutionInfo(18, "First Recurring Character"),
            new SolutionInfo(19, "Linked List"),
            new SolutionInfo(20, "Doubly Linked List"),
        };

        static void Main(string[] args)
        {

            foreach(var s in solutionInfoList) {
                Console.WriteLine($"{s.Number, -3}: {s.Description}");
            }

            Console.WriteLine();
            Console.WriteLine("Choose a solution number:");

            int.TryParse(Console.ReadLine(), out int solutionNumber);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();


            // Get Solution
            ISolution solution = CreateSolution(solutionNumber);

            // Benchnmark & Execute Solution
            var ms = BenchmarkTime(solution);
            Console.WriteLine($"Elaspsed Time: {ms} ms");
        }

        private static ISolution CreateSolution(int solutionNumber) {
            string className = $"Solution{solutionNumber}";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().SingleOrDefault(x => x.Name == className);

            return type != null ? Activator.CreateInstance(type) as ISolution : null;
        }

        private static double BenchmarkTime(ISolution solution) {
            var t0 = Stopwatch.StartNew();
            solution.Run();
            t0.Stop();
            return t0.Elapsed.TotalMilliseconds;
        }
    }
}
