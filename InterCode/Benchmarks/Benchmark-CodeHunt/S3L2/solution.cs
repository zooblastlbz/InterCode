// P139: (ICSE2)  Compute sum of n-th and n-1st Fibonacci numbers
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int Puzzle(int x) {
    int valueA = 0;
    int valueB = 1;
    int r = 0;
    bool everyOther = true;
    for (int i = 0; i < x; i++) {
      if (everyOther) {
        valueA += valueB;
        everyOther = false;
        r = valueA;
      } else {
        valueB += valueA;
        everyOther = true;
        r = valueB;
      }
    }
    return r;
  }
}