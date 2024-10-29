public class Solution {
    int[,] dp;

    public int MaxMoves(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, moves = 0;
        dp = new int[m,n];
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                dp[i,j] = -1;

        for(var i=0; i<m; i++){
            var curr = GetMoves(grid, i, 0);
            moves = Math.Max(moves, curr);
        }

        return moves;
    }

    private int GetMoves(int[][] grid, int r, int c){
        int m = grid.Length, n = grid[0].Length, moves = 0;
        if(c == n-1) return 0;
        if(dp[r,c] != -1) return dp[r,c];

        // above row
        if(r > 0 && grid[r-1][c+1] > grid[r][c])
            moves = Math.Max(moves, 1 + GetMoves(grid, r-1, c+1));
        
        // same row
        if(grid[r][c+1] > grid[r][c])
            moves = Math.Max(moves, 1 + GetMoves(grid, r, c+1));

        // next row
        if(r < m-1 && grid[r+1][c+1] > grid[r][c])
            moves = Math.Max(moves, 1 + GetMoves(grid, r+1, c+1));
        
        dp[r,c] = moves;
        return moves;
    }
}