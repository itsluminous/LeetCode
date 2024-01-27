// refer : https://leetcode.com/problems/k-inverse-pairs-array/solutions/1283053/k-inverse-pairs-c-dp-explained

public class Solution {
    public int KInversePairs(int n, int k) {
        const int MOD = 1_000_000_000 + 7;
        var dp = new int[k+1];

        for(var i=1; i<=n; i++){
            var tmpdp = new int[k+1];
            tmpdp[0] = 1;
            for(var j=1; j<=k; j++){
                var prev = (j-i) >= 0 ? dp[j-i] : 0;
                var val = (dp[j] + MOD - prev) % MOD;
                tmpdp[j] = (tmpdp[j-1] + val) % MOD;
            }

            dp = tmpdp;
        }

        var prevVal = k > 0 ? dp[k-1] : 0;
        return (dp[k] + MOD - prevVal) % MOD;
    }
}