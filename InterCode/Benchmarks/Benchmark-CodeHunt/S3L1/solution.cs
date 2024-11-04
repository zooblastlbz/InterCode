// P152: Filter retaining only values >= threshold -- a crude noise filter
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int[] Puzzle(int[] a, int t) {
    
    
    int[] output = new int[a.Length];
    for (int i=0; i<a.Length; i++) {
      int v = a[i];
      output[i] = (Math.Abs(v) >= t) ? v : 0;
    }
    return output;
  }
}