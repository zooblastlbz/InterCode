// P173: Map(a[],f[]) -- apply f[a[i]]
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int[] Puzzle(int[] a, int[] f) {

    int[] output = new int[a.Length];
    for (int i=0; i<a.Length; i++) {
      int x = a[i];
      if ( 0 <= x & x < f.Length ) {
        output[i] = f[x];
      } else {
        output[i] = 0;
      }
    }
    return output;
  }
}