// detailed explaination for how dp formula is derived
// https://leetcode.com/problems/domino-and-tromino-tiling/solutions/116581/detail-and-explanation-of-o-n-solution-why-dp-n-2-d-n-1-dp-n-3/
public class Solution {
    public int NumTilings(int n) {
        if(n <= 2) return n;
        var MOD = 1_000_000_007;

        var dp = new long[n+1];
        dp[0] = dp[1] = 1;
        dp[2] = 2;
        
        for(var i=3; i<=n; i++)
            dp[i] = (2L * dp[i-1] + dp[i-3]) % MOD;

        return (int)dp[^1];  // return last element
    }
}

// A more simple approach
// https://leetcode.com/problems/domino-and-tromino-tiling/solutions/1620975/c-python-simple-solution-w-images-explanation-optimization-from-brute-force-to-dp/