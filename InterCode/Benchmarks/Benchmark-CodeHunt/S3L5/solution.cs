// P261: Knight's moves on a chessboard
// Used in Imagine Cup 2014
using System;

public class ReferenceCode {
    static int[] deltaX = {-2, -2, -1, -1,  1,  1,  2,  2};
    static int[] deltaY = {-1,  1, -2,  2, -2,  2, -1,  1};

    public static int[][] Puzzle(int x, int y) {
        
        int[] moves = new int[8];
        int moveIndex = 0;
        for( int i=0; i<8; i++ ) {
            int xx = x+deltaX[i];
            if (xx < 1 | xx > 8) continue;
            int yy = y+deltaY[i];
            if (yy < 1 | yy > 8) continue;
            moves[moveIndex++] = (xx << 8) | yy;
        }
        int[][] result = new int[moveIndex][];
        for(int i=0; i<moveIndex; i++) {
            int val = moves[i];
            result[i] = new int[] { val>>8, val&0xFF };
        }
        return result;
    }
}