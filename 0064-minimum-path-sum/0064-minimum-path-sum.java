class Solution {
    public int minPathSum(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++){
                if(i==0 && j==0) continue;                  // if this is the top-left corner
                if(i==0) grid[i][j] += grid[i][j-1];        // if this is first row, only way is from left side
                else if(j==0) grid[i][j] += grid[i-1][j];   // if this is first col, only way is from top  
                else grid[i][j] += Math.min(grid[i][j-1],grid[i-1][j]);
            }
        return grid[m-1][n-1];
    }
}

// accepted - using extra space
class SolutionExtra {
    int[][] dp;

    public int minPathSum(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        dp = new int[m][n];
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                dp[i][j] = -1;

        return minPathSum(grid, 0, 0);
    }

    private int minPathSum(int[][] grid, int x, int y){
        int m = grid.length, n = grid[0].length;
        if(x == m || y == n) return Integer.MAX_VALUE;
        if(x == m-1 && y == n-1) return grid[x][y];
        if(dp[x][y] != -1) return dp[x][y];

        var downSum = minPathSum(grid, x+1, y);
        var rightSum = minPathSum(grid, x, y+1);
        dp[x][y] = grid[x][y] + Math.min(downSum, rightSum);
        return dp[x][y];
    }
}