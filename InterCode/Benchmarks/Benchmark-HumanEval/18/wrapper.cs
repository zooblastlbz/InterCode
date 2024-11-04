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
    public void Puzzle(string x1, string x2){
        PexAssume.IsNotNull(x1);
        PexAssume.IsTrue(x1.Length >= 0 & x1.Length <= 8);
        foreach (char v in x1) PexAssume.IsTrue(v >= 'a' & v <= 'e');

        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x2.Length >= 1 & x2.Length <= 3);
        foreach (char v in x2) PexAssume.IsTrue(v >= 'a' & v <= 'e');
        
        int result = global::ReferenceCode.Puzzle(x1, x2);
        int resultTry = global::TryCode.Puzzle(x1, x2);

        bool ans = ValueEqualityHelper.AreEqual(result, resultTry);
        if (!ans)
            throw new Exception();
    }
}