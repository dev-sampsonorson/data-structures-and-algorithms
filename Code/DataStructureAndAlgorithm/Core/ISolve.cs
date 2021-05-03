using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithm.Core {
    public interface ISolve<TInput, TResult> where TInput : IInput {
        string Description { get; }
        TResult Implementation(TInput input);
    }
}
