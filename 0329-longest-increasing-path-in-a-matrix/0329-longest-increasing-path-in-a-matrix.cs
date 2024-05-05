public class Solution {
    (int x, int y)[] dirs = new []{(0, -1), (0, 1), (-1, 0), (1, 0)};

    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var dp = new int[m,n];

        var longest = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var curr = LIS(matrix, dp, -1, i, j);
                longest = Math.Max(longest, curr);
            }
        }
        return longest;
    }

    private int LIS(int[][] matrix, int[,] dp, int prev, int i, int j){
        int m = matrix.Length, n = matrix[0].Length;
        if(i == -1 || j == -1 || i == m || j == n || matrix[i][j] <= prev) return 0;
        if(dp[i,j] > 0) return dp[i,j];
        
        var longest = 0;
        foreach(var (x, y) in dirs)
            longest = Math.Max(longest, LIS(matrix, dp, matrix[i][j], i+x, j+y));
        dp[i,j] = 1 + longest;
        return dp[i,j];
    }
}