public class Solution {
    int[,] dp;

    public int MinPathCost(int[][] grid, int[][] moveCost) {
        int m = grid.Length, n = grid[0].Length, mincost = int.MaxValue;
        dp = new int[m,n];

        // get min cost starting from each col
        for(var col=0; col<n; col++){
            var cost = GetMinCost(grid, moveCost, 0, col);
            mincost = Math.Min(mincost, cost);
        }
        return mincost;
    }

    private int GetMinCost(int[][] grid, int[][] moveCost, int srcRow, int srcCol){
        if(srcRow == grid.Length) return 0;
        if(srcRow == grid.Length-1) return grid[srcRow][srcCol];
        if(dp[srcRow,srcCol] != 0) return dp[srcRow,srcCol];

        var n = grid[0].Length;
        var srcNum = grid[srcRow][srcCol];
        var minCost = int.MaxValue;
        
        for(var destCol=0; destCol<n; destCol++){
            var cost = GetMinCost(grid, moveCost, srcRow+1, destCol);
            cost += grid[srcRow][srcCol] + moveCost[srcNum][destCol];
            minCost = Math.Min(minCost, cost);
        }

        dp[srcRow,srcCol] = minCost;
        return minCost;
    }
}