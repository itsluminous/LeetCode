class Solution {
    public int valueAfterKSeconds(int n, int k) {
        var MOD = 1_000_000_007;
        var dp = new int[n];
        for(var i=0; i<n; i++) dp[i] = 1;
        
        for(var i=1; i<=k; i++)
            for(var j=1; j<n; j++)
                dp[j] = (dp[j-1] + dp[j]) % MOD;
        
        return dp[n-1];
    }
}