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
    public void Puzzle(int a, int b, int m)
    {
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1 >= -20 & x1 <= 20);

        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2 >= -20 & x2 <= 20);

        PexAssume.IsNotNull(x3);
        PexAssume.IsTrue(x3 < 10 & x3 > 0);

        // if (a == 7 & b == 2  & m == 5); // Pex hint
        // if (a == 4 & b == 11 & m == 4); // Pex hint
        int result1 = global::ReferenceCode.Puzzle(x1, x2, x3);
        int result2 = global::TryCode.Puzzle(x1, x2, x3);

        bool ans = (result1 == result2);
        if(!ans)
            throw new Exception(); 
    }
}