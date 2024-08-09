public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int row = grid.Length, col = grid[0].Length;
        if(row < 3 || col < 3) return 0;

        var count = 0;
        for(var i=0; i<row-2; i++)
            for(var j=0; j<col-2; j++)
                count += IsMagicSquare(grid, i, j);
        
        return count;
    }

    private int IsMagicSquare(int[][] grid, int x, int y) {
        var diag1 = grid[x][y] + grid[x+1][y+1] + grid[x+2][y+2];
        var diag2 = grid[x][y+2] + grid[x+1][y+1] + grid[x+2][y];

        if(diag1 != diag2) return 0;

        // calculate row & col sum
        var seen = new bool[10];
        int[] rowsum = new int[3], colsum = new int[3];

        for(var i=0; i<3; i++){
            for(var j=0; j<3; j++){
                var num = grid[x+i][y+j];
                if(num == 0 || num > 9 || seen[num]) return 0;
                seen[num] = true;
                rowsum[i] += num;
                colsum[j] += num;
            }
        }

        if(rowsum[0] != diag1 || rowsum[1] != diag1 || rowsum[2] != diag1) return 0;
        if(colsum[0] != diag1 || colsum[1] != diag1 || colsum[2] != diag1) return 0;

        return 1;
    }
}