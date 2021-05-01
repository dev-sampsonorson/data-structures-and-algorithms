using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithm.Core {
    class SolutionInfo {

        public int Number { get; }
        public string Description { get; }

        public SolutionInfo(int number, string description) {
            this.Number = number;
            this.Description = description;
        }
    }
}
