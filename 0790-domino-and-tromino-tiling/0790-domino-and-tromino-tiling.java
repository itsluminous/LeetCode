class Solution {
    public int numTilings(int n) {
        if(n <= 2) return n;
        var MOD = 1_000_000_007;

        var dp = new long[n+1];
        dp[0] = dp[1] = 1;
        dp[2] = 2;
        
        for(var i=3; i<=n; i++)
            dp[i] = (2L * dp[i-1] + dp[i-3]) % MOD;

        return (int)dp[dp.length-1];  // return last element
    }
}