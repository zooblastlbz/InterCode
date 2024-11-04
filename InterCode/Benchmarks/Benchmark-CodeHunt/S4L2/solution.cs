// P191: Compute n choose m, i.e. n!/(m! * (n-m)!)
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int Puzzle(int n, int m) {
    int c = 1;
    for (int i = n;   i > m; i--) c *= i; // m! cancels out
    for (int j = n-m; j > 1; j--) c /= j; // (n-m)!
    return c;
  }
}