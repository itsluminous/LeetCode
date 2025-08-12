public class Solution {
    int MOD = 1_000_000_007;

    public int NumberOfWays(int n, int x) {
        var dp = new long[n+1]; // number of ways to achieve a given number
        dp[0] = 1;

        for(var num=1; num<=n; num++){
            var curr = (int)Math.Pow(num, x);
            if(curr > n) break;
            for(var i=n; i>=curr; i--)
                dp[i] = (dp[i] + dp[i-curr]) % MOD;
        }

        return (int)dp[n];
    }
}