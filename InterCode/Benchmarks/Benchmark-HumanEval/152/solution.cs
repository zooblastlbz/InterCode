using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] game, int[] guess)
    {
        return game.Zip(guess, (x, y) => Math.Abs(x - y)).ToArray();
    }
}