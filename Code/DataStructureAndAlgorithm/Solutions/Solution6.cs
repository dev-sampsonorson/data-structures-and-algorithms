using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution6 : ISolution {
        public void Run() {
            this.ExecuteSolves<InputVoid, bool>(null);
        }

        private class First : ISolve<InputVoid, bool> {
            public string Description => "Trying out interger overflow";

            public bool Implementation(InputVoid input) {

                Console.WriteLine($"Math.Power: {Math.Pow(6, 10000000000000000000)}");


                return true;
            }
        }
    }
}
