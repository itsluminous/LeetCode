class Solution {
    public int numTilings(int n) {
        if(n <= 2) return n;

        var MOD = 1_000_000_007;
        var dp = new long[n+1];
        dp[0] = 1;  // only one way : no arrangement
        dp[1] = 1;  // only one way : |
        dp[2] = 2;  // two ways : || or =
        dp[3] = 5;  // |= or ||| or =| or rɹ or L⅂  

        // https://leetcode.com/problems/domino-and-tromino-tiling/solutions/116581/detail-and-explanation-of-o-n-solution-why-dp-n-2-d-n-1-dp-n-3/
        for(var i=4; i<=n; i++)
            dp[i] = (2L * dp[i-1] + dp[i-3]) % MOD;

        return (int)dp[n];
    }
}

// A more simple approach
// https://leetcode.com/problems/domino-and-tromino-tiling/solutions/1620975/c-python-simple-solution-w-images-explanation-optimization-from-brute-force-to-dp/