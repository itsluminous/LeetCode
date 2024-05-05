class Solution {
    int[][] dirs = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};

    public int longestIncreasingPath(int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        var dp = new int[m][n];

        var longest = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var curr = lis(matrix, dp, -1, i, j);
                longest = Math.max(longest, curr);
            }
        }
        return longest;
    }

    private int lis(int[][] matrix, int[][] dp, int prev, int i, int j){
        int m = matrix.length, n = matrix[0].length;
        if(i == -1 || j == -1 || i == m || j == n || matrix[i][j] <= prev) return 0;
        if(dp[i][j] > 0) return dp[i][j];
        
        var longest = 0;
        for(var dir : dirs)
            longest = Math.max(longest, lis(matrix, dp, matrix[i][j], i+dir[0], j+dir[1]));
        dp[i][j] = 1 + longest;
        return dp[i][j];
    }
}