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
    public void Puzzle(int[] x1)
    {
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1.Length >= 2 & x1.Length <= 20);
        foreach (int v in x1) PexAssume.IsTrue(v >= -50 & v <= 50);
        int result1 = global::ReferenceCode.Puzzle(x1);
        int result2 = global::TryCode.Puzzle(x1);

        bool ans = (result1 == result2);
        if(!ans)
            throw new Exception(); 
    }
}