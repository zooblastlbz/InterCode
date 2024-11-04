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
    public void Puzzle(int[] x1, int[] x2)
    {
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1.Length >= 5 & x1.Length <= 8);
        foreach (int v in x1) PexAssume.IsTrue(v >= 0 & v <= 10);

        int max = x1.Max(); 

        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2.Length > max);
        foreach (int v in x2) PexAssume.IsTrue(v >= 0 & v <= 10);

        int[] result1 = global::ReferenceCode.Puzzle(x1, x2);
        int[] result2 = global::TryCode.Puzzle(x1, x2);

        bool ans = Enumerable.SequenceEqual(result1,result2);
        if(!ans)
            throw new Exception(); 
    }
}