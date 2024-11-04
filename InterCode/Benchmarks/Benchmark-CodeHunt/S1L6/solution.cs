// P194: Count words in a string
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
  public static int Puzzle(string s) {
    string[] list = s.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
    return list.Length;
  }
}