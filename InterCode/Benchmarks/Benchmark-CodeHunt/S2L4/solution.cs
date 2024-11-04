//  P193 (source: 2.2 from zone BOP Semi Final, April 2014): Compute LCM(X,Y)
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  // Compute the lowest (least) common multiple of a and b
  // => use Euclid's algorithm to compute lcm(a,b) = |ab|/gcd(a,b)
  public static int Puzzle(int a, int b) {
    
    int n = a*b;
    while(b != 0) {
        int t = b;
        b = a % b;
        a = t;
    }
    return n/a;
  }
}