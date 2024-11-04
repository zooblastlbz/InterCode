// P198: Count the depth of nesting parentheses in a string
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int Puzzle(string s) {

    int openClose = 0;
    int maxDepth = 0;
    foreach (char c in s) {
      
      if ( c == '(' ) {
        openClose++;
        if ( openClose > maxDepth )
          maxDepth = openClose;
      }
      else
      if ( c == ')' ) {
        openClose--;
        if ( openClose < 0 ) return 0;
      }
      // else: ignore c
    }
    return (openClose == 0) ? maxDepth : 0;
  }
}