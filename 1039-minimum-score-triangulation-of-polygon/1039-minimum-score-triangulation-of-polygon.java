class Solution {
    int[][] dp;
    
    public int minScoreTriangulation(int[] values) {
        var n = values.length;
        dp = new int[n][n];
        return dfs(values, 0, n-1);
    }

    private int dfs(int[] values, int i, int j){
        var res = Integer.MAX_VALUE;
        if(dp[i][j] != 0) return dp[i][j];  // already calculated weight
        if(j-i < 2) return 0;               // triangle not possible

        // try all triangles with two points as i and j and 3rd between them
        // https://leetcode.com/problems/minimum-score-triangulation-of-polygon/solutions/286753/c-with-picture
        for(var k=i+1; k<j; k++){
            var curr = values[i] * values[j] * values[k];
            var left = dfs(values, i, k);
            var right = dfs(values, k, j);
            res = Math.min(res, curr + left + right);
        }

        dp[i][j] = res;
        return res;
    }
}