using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution6 : ISolution {
        public void Run() {
            this.ExecuteSolves<Empty, bool>(null);
        }

        private class First : ISolve<Empty, bool> {
            public string Description => "Trying out interger overflow";

            public bool Implementation(Empty input) {

                Console.WriteLine($"Math.Power: {Math.Pow(6, 10000000000000000000)}");


                return true;
            }
        }
    }
}
