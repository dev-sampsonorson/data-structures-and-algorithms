using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataStructureAndAlgorithm.Core {
    public static class SolutionHelper {
        public static void ExecuteSolves<TInput>(this ISolution instance, List<TInput> inputs) where TInput : class, IInput {
            Type[] types = instance.GetType().GetNestedTypes(BindingFlags.NonPublic);

            foreach (Type t in types) {
                if (t.FindInterfaces((Type t, Object o) => t.Name.StartsWith(o.ToString()), "ISolve").Length <= 0)
                    continue;

                ISolve<TInput, bool> solveInstance = Activator.CreateInstance(t) as ISolve<TInput, bool>;

                Console.WriteLine($"{solveInstance.GetType().Name}: {solveInstance.Description}");
                for (int i = 0; i < inputs.Count; i++) {
                    bool result = solveInstance.Implementation(inputs[i]);
                    Console.WriteLine($"Input {i + 1}, Result: {result}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
