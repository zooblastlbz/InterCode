//  P167: find k-th largest element in an array
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int Puzzle(int[] a, int k) {
    int[] b = new int[a.Length];
    for(int i=0; i<a.Length; i++) {
        b[i] =  a[i];
    }
    Array.Sort(b);
    return b[k];
  }
}