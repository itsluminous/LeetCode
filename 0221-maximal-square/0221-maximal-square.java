// Explaination - https://leetcode.com/problems/maximal-square/discuss/600149/Python-Thinking-Process-Diagrams-DP-Approach

// Using 1d array extra space
public class Solution {
    public int maximalSquare(char[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        int max = 0, diagLeftVal = 0;
        var dp = new int[n+1];  // all will be 0 by default
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var temp = dp[j+1];
                if(matrix[i][j] == '0')
                    dp[j+1] = 0;
                else{
                    // min of diagonal-up, left, up
                    dp[j+1] = Math.min(diagLeftVal, Math.min(dp[j], dp[j+1])) + 1;
                    max = Math.max(max, dp[j+1]);
                }
                diagLeftVal = temp;
            }
        }
        
        return max*max;
    }
}

// Accepted - Using 2d matrix extra space
class Solution2d {
    public int maximalSquare(char[][] matrix) {
        var m = matrix.length;
        var n = matrix[0].length;
        var max = 0;
        var dp = new int[m+1][];
        for(int i=0; i<=m; i++) dp[i] = new int[n+1];

        for(int i=1; i<=m; i++){
            for(int j=1; j<=n; j++){
                if(matrix[i-1][j-1] == '1')
                    // min of diagonal-up, left, up
                    dp[i][j] = 1 + Math.min(Math.min(dp[i-1][j], dp[i][j-1]), dp[i-1][j-1]);
                if(dp[i][j] > max) max = dp[i][j];
            }
        }
        return max*max;
    }
}