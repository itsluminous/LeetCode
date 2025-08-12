class Solution:
    def numberOfWays(self, n: int, x: int) -> int:
        MOD = 1_000_000_007
        dp = [0] * (n+1)    # number of ways to achieve a given number
        dp[0] = 1

        for num in range(1, n+1):
            curr = num ** x
            if curr > n: break
            for i in range(n, curr-1, -1):
                dp[i] = (dp[i] + dp[i-curr]) % MOD

        return dp[n]