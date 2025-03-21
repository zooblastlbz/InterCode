//  P153 (source: 2.5 from zone BOP Qualifying Round, April 2014): Find maximum difference between 2 elements in an array
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  // Compute the largest span between any two values in the array
  public static int Puzzle(int[] a) {
    

    if ( a.Length < 2 )
      return 0;

    int min=a[0], max=a[0];
    foreach (int v in a) {
      if (v < min) min = v;
      if (v > max) max = v;
    }
    return (max - min);
  }
}