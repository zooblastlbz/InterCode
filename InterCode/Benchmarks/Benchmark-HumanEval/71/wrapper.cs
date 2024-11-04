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
    public void Puzzle(double x1, double x2, double x3){
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1 > 0.5 & x1 < 20.0);
        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2 > 0.5 & x2 < 20.0);
        PexAssume.IsNotNull(x3);
        PexAssume.IsTrue(x3 > 0.5 & x3 < 20.0);
        double result = global::ReferenceCode.Puzzle(x1, x2, x3);
        double resultTry = global::TryCode.Puzzle(x1, x2, x3);

        bool ans = ValueEqualityHelper.AreEqual(result, resultTry);
        if (!ans)
            throw new Exception();
    }
}