//  P265:  Test if char c appears in "imagine cup"
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static bool Puzzle(char c) {
    return "imagine cup".IndexOf(c) >= 0;
  }
}