class Solution {
    public int numberOfPaths(int[][] grid, int k) {
        var MOD = 1_000_000_007;
        int m = grid.length, n = grid[0].length, ans = 0;
        var dp = new long[m+1][n+1][k];

        var rem = grid[0][0] % k;
        dp[1][1][rem] = 1;  // 1 way to reach this

        for(var i=1; i<=m; i++){
            for(var j=1; j<=n; j++){
                if(i == 1 && j == 1) continue;  // starting case

                rem = grid[i-1][j-1] % k;
                for(var r=0; r<k; r++){
                    var newRem = (r + k - rem) % k;
                    dp[i][j][r] = (dp[i-1][j][newRem] + dp[i][j-1][newRem]) % MOD;
                }
            }
        }

        return (int)dp[m][n][0];
    }
}