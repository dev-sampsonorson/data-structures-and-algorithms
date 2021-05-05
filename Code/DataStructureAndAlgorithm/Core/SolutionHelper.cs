using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataStructureAndAlgorithm.Core {
    public static class SolutionHelper {
        public static void ExecuteSolves<TInput, TReturn>(this ISolution instance, List<TInput> inputs, Action<TReturn> callback = null) where TInput : class, IInput {
            Type[] types = instance.GetType().GetNestedTypes(BindingFlags.NonPublic);

            foreach (Type t in types) {
                Type[] interfaceTypes = t.FindInterfaces((Type t, Object o) => t.Name.StartsWith(o.ToString()), "ISolve");
                if (interfaceTypes.Length <= 0)
                    continue;

                TReturn[] result;
                ISolve<TInput, TReturn> solveInstance = Activator.CreateInstance(t) as ISolve<TInput, TReturn>;

                Console.WriteLine($"{solveInstance.GetType().Name}: {solveInstance.Description}");

                if (interfaceTypes[0].GetGenericArguments()[0].Name == "Empty") {
                    result = new TReturn[1];
                    result[0] = solveInstance.Implementation(null);
                } else {
                    result = new TReturn[inputs.Count];
                    for (int i = 0; i < inputs.Count; i++) {
                        result[i] = solveInstance.Implementation(inputs[i]);
                    }
                }

                for (int i = 0; i < result.Length; i++) {
                    Console.WriteLine($"Input {i + 1}, Result: {result[i]}");
                    if (callback != null) callback.Invoke(result[i]);
                }




                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
