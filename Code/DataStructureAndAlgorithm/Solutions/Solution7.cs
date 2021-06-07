using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution7 : ISolution {
        public void Run() {
            this.ExecuteSolves<InputVoid, bool>(null);
        }

        private class First : ISolve<InputVoid, bool> {
            public string Description => "Array tryout";

            public bool Implementation(InputVoid input) {
                List<string> strings = new List<string> { "a", "b", "c", "d" };
                // on a 32 bit system, meaning having 4 shelves to store the letter "a" in 0s and 1s
                // 4 letters
                // 4*4 = 16 bytes
                Display("initial", strings);


                // grab 3rd item
                Console.WriteLine($"third item: {strings[2]}");
                Display("third item accessed", strings);


                // push, add
                strings.Add("e"); // O(1)
                Display("added, pushed e", strings);

                // pop, access
                string lastItem = strings[strings.Count - 1]; // O(1)
                Display($"accessed, popped last item: {lastItem}", strings);

                // unshift, add at beginning
                strings.Insert(0, "x"); // O(n)
                Display("inserted, ushifted x", strings);

                // splice, add at middle
                strings.Insert(2, "alien");
                Display("inserted at middle, splice alien", strings); // O(n)

                // remove, delete
                strings.RemoveAt(0);
                Display("removed at position", strings); // O(n)


                return true;
            }

            private void Display(string label, List<string> list) {
                Console.WriteLine($"{label}");

                foreach (var item in list)
                    Console.Write($"{item}, ");

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
