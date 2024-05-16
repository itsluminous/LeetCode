class Solution {
    int[][] dp;

    public int minPathCost(int[][] grid, int[][] moveCost) {
        int m = grid.length, n = grid[0].length, mincost = Integer.MAX_VALUE;
        dp = new int[m][n];

        // get min cost starting from each col
        for(var col=0; col<n; col++){
            var cost = getMinCost(grid, moveCost, 0, col);
            mincost = Math.min(mincost, cost);
        }
        return mincost;
    }

    private int getMinCost(int[][] grid, int[][] moveCost, int srcRow, int srcCol){
        if(srcRow == grid.length) return 0;
        if(srcRow == grid.length-1) return grid[srcRow][srcCol];
        if(dp[srcRow][srcCol] != 0) return dp[srcRow][srcCol];

        var n = grid[0].length;
        var srcNum = grid[srcRow][srcCol];
        var minCost = Integer.MAX_VALUE;
        
        for(var destCol=0; destCol<n; destCol++){
            var cost = getMinCost(grid, moveCost, srcRow+1, destCol);
            cost += grid[srcRow][srcCol] + moveCost[srcNum][destCol];
            minCost = Math.min(minCost, cost);
        }

        dp[srcRow][srcCol] = minCost;
        return minCost;
    }
}