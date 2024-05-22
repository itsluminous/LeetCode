class Solution {
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