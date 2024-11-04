// P202: Generate the string of binary digits for n
  // Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static string Puzzle(int n) {
    
    if ( n == 0 ) return "0";

    string output = "";
    while ( n != 0 ) {
      output = ((n%2 == 0) ? "0":"1")+output;
      n >>= 1;
    }
    return output;
  }
}