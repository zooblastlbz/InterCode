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
    public void Puzzle(int x1, int x2)
    {
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1 >= 1 & x1 <= 8);

        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x2 >= 1 & x2 <= 8);
        // if (x==5&y==1 | x==3&y==8);
        int[][] result1 = global::ReferenceCode.Puzzle(x1, x2);
        int[][] result2 = global::TryCode.Puzzle(x1, x2);

        bool ans = (result1.Length == result2.Length);
        if (ans) 
        {
            for(int i = 0; i < result1.Length; i++) 
            {
                ans = ans & Enumerable.SequenceEqual(result1[i],result2[i]);
            }
        }
        if(!ans)
            throw new Exception(); 
    }
}