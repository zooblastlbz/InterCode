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
    public void Puzzle(string[] x1, string x2){
        PexAssume.IsNotNull(x1);
        PexAssume.IsNotNull(x2);
        PexAssume.IsTrue(x1.Length >= 0 & x1.Length <= 5);
        PexAssume.IsTrue(x2.Length >= 1 & x2.Length <= 2);
        foreach (string s in x1){ 
            PexAssume.IsNotNull(s);
            PexAssume.IsTrue(s.Length >= 0 & s.Length <= 20);
            foreach (char v in s)
                PexAssume.IsTrue((v >= 'a') & (v <= 'e'));
        }
        foreach (char v in x2) PexAssume.IsTrue(v >= 'a' & v <= 'e');
        string[] result = global::ReferenceCode.Puzzle(x1, x2);
        string[] resultTry = global::TryCode.Puzzle(x1, x2);

        bool ans = ValueEqualityHelper.AreEqual(result, resultTry);
        if (!ans)
            throw new Exception();
    }
}