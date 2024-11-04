using System;
using System.Linq;
using Microsoft.Pex.Framework;
using System.Collections.Generic;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>This class contains parameterized unit tests for Program</summary>
//[PexClass(typeof(global::Program), MaxRuns = 1)]
[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
[TestClass]
public partial class ProgramTest
{
    /// <summary>Test stub for Sort(Int32[])</summary>
    [PexMethod(MaxBranches = 100000, MaxConditions = 4000)]
    public void Puzzle(int[] x1, int x2)
    {
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1.Length >= 4 & x1.Length <= 20);
        foreach(int v in x1) PexAssume.IsTrue(v>=-100 & v<=100);

        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2 >= 0 & x2 < x1.Length);

        int result1 = global::ReferenceCode.Puzzle(x1, x2);
        int result2 = global::TryCode.Puzzle(x1, x2);

        bool ans = (result1 == result2);
        if(!ans)
            throw new Exception(); 
    }
}