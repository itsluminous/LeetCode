public class Solution {
    int MAX_NUM = 10;
    int[][] dp;

    public int minimumOperations(int[][] grid) {
        int rows = grid.length, cols = grid[0].length;
        initializeDP(cols, MAX_NUM+1);
        
        // store freq of each number from 0 to 9, in each column in the grid
        var freq = new int[cols][MAX_NUM];
        for(var i=0; i<rows; i++)
            for(var j=0; j<cols; j++)
                freq[j][grid[i][j]]++;
        
        // now try all numbers from 0 to 9 for each column
        return minimumOperations(freq, 0, MAX_NUM, rows, cols);
    }

    private int minimumOperations(int[][] freq, int colIdx, int prevVal, int rows, int cols){
        if(colIdx == cols) return 0;
        if(dp[colIdx][prevVal] != -1) return dp[colIdx][prevVal];

        var min = Integer.MAX_VALUE;
        // try all numbers from 0 to 9 for colIdx column
        for(var i=0; i<MAX_NUM; i++){
            if(i == prevVal) continue;
            var operations = rows - freq[colIdx][i] + minimumOperations(freq, colIdx+1, i, rows, cols);
            min = Math.min(min, operations);
        }

        dp[colIdx][prevVal] = min;
        return min;
    }

    private void initializeDP(int cols, int num){
        dp = new int[cols][num];
        for(var i=0; i<cols; i++)
            for(var j=0; j<num; j++)
                dp[i][j] = -1;
    }
}