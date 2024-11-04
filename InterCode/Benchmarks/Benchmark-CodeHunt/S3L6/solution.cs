// P169: Compute the set difference of a\b
// Used in Imagine Cup 2014
using System;

public static class ReferenceCode {
  public static int[] Puzzle(int[] a, int[] b) {
    
    if (a.Length == 0) return new int[]{};

    
    int[] counts = new int[256];
    int total = 0;

    foreach (int v in a) {
      counts[v]++;
      if (counts[v]==1) total++;
    }
    foreach (int v in b) {
      if (counts[v]>0) total--;
      counts[v]=0;
    }

    int[] output = new int[total];
    int i=0;
    for (int j=0; j<counts.Length; j++) {
      if (counts[j] > 0) output[i++] = j;
    }

    return output;
  }
}