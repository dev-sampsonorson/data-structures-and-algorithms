﻿using System;
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
        };

        static void Main(string[] args)
        {

            foreach(var s in solutionInfoList) {
                Console.WriteLine($"{s.Number}: {s.Description}");
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
