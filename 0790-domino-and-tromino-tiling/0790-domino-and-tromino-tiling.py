class Solution:
    def numTilings(self, n: int) -> int:
        if n <= 2: return n

        MOD = 1_000_000_007
        dp = [0] * (n+1)
        dp[0] = 1  # only one way : no arrangement
        dp[1] = 1  # only one way : |
        dp[2] = 2  # two ways : || or =
        dp[3] = 5  # |= or ||| or =| or rɹ or L⅂  

        # https://leetcode.com/problems/domino-and-tromino-tiling/solutions/116581/detail-and-explanation-of-o-n-solution-why-dp-n-2-d-n-1-dp-n-3/
        for i in range(4, n+1):
            dp[i] = (2 * dp[i-1] + dp[i-3]) % MOD

        return dp[n]

# A more simple approach
# https://leetcode.com/problems/domino-and-tromino-tiling/solutions/1620975/c-python-simple-solution-w-images-explanation-optimization-from-brute-force-to-dp/