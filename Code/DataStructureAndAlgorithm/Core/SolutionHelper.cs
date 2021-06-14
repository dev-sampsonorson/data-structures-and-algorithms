using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Collections;

namespace DataStructureAndAlgorithm.Core {
    public static class SolutionHelper {

        /// <summary>
        /// Execute solves
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <typeparam name="TReturn">Return type</typeparam>
        /// <param name="instance">Solution instance</param>
        /// <param name="inputs">List of inputs of TInput type</param>
        /// <param name="callback">Callback that receives result of type TReturn</param>
        public static void ExecuteSolves<TInput, TReturn>(this ISolution instance, List<TInput> inputs, Action<TReturn> callback = null) where TInput : class, IInput {
            Type[] types = instance.GetType().GetNestedTypes(BindingFlags.NonPublic);

            foreach (Type t in types) {
                Type[] interfaceTypes = t.FindInterfaces((Type t, Object o) => t.Name.StartsWith(o.ToString()), "ISolve");
                if (interfaceTypes.Length <= 0)
                    continue;

                TReturn[] result;
                ISolve<TInput, TReturn> solveInstance = Activator.CreateInstance(t) as ISolve<TInput, TReturn>;

                bool doesReturnValue = typeof(TReturn).Name != typeof(ReturnVoid).Name;

                Console.WriteLine($"{solveInstance.GetType().Name}: {solveInstance.Description}");

                if (interfaceTypes[0].GetGenericArguments()[0].Name == typeof(InputVoid).Name) {
                    result = new TReturn[1];

                    if (doesReturnValue)
                        result[0] = solveInstance.Implementation(null);
                    else
                        solveInstance.Implementation(null);
                } else {
                    result = new TReturn[inputs.Count];
                    for (int i = 0; i < inputs.Count; i++) {
                        if (doesReturnValue)
                            result[i] = solveInstance.Implementation(inputs[i]);
                        else
                            solveInstance.Implementation(inputs[i]);
                    }
                }

                if (doesReturnValue) {
                    for (int i = 0; i < result.Length; i++) {
                        Type resultType = result[i]?.GetType();

                        if (result[i] == null || resultType == null)
                            DisplayNullResult<TReturn>(i);

                        if (resultType != null && resultType.IsArray)
                            DisplayArrayResult<TReturn>(i, result[i] as Array);

                        if (resultType != null && (resultType.IsValueType || resultType.IsAssignableFrom(typeof(string))))
                            DisplayValueTypeResult<TReturn>(i, result[i]);

                        if (callback != null) callback.Invoke(result[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void DisplayArrayResult<TResult>(int inputIndex, Array result) {

            Console.Write($"Input {inputIndex + 1}, Result: ");
            Console.Write("[");
            Console.Write($"{string.Join(", ", result.Cast<object>())}");
            Console.Write("]");
            Console.WriteLine();
        }

        private static void DisplayValueTypeResult<TResult>(int inputIndex, TResult result){
            Console.WriteLine($"Input {inputIndex + 1}, Result: {result}");
        }

        private static void DisplayNullResult<TResult>(int inputIndex) {
            Console.WriteLine($"Input {inputIndex + 1}, Result: null");

        }
    }
}
