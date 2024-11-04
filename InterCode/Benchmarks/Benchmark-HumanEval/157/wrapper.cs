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
    public void Puzzle(int x1, int x2, int x3){
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1 >= 1 & x1 <=100);
        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2 >= 1 & x2 <=100);
        PexAssume.IsNotNull(x3);
        PexAssume.IsTrue(x3 >= 1 & x3 <=100);
        bool result = global::ReferenceCode.Puzzle(x1, x2, x3);
        bool resultTry = global::TryCode.Puzzle(x1, x2, x3);

        bool ans = ValueEqualityHelper.AreEqual(result, resultTry);
        if (!ans)
            throw new Exception();
    }
}