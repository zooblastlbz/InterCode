//  P264: advance letter codes by Fibonacci numbers
// Used in Imagine Cup 2014
using System;

//timeout=80
public class ReferenceCode {
  public static string Puzzle(string s) {
    char[] c = new char[s.Length];
    int fib1 = 0;
    int fib = 1;
    for (int i = 0; i < c.Length; i++) {
      c[i] = (char)(((s[i] - 'a') + fib) % 26 + 'a');
      int k = fib1;
      fib1 = fib;
      fib += k;
    }
    return new string(c);
  }
}