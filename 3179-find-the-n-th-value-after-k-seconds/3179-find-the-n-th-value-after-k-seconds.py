class Solution:
    def valueAfterKSeconds(self, n: int, k: int) -> int:
        MOD = 1_000_000_007;
        dp = [1] * n
        
        for i in range(1, k+1):
            for j in range(1, n):
                dp[j] = (dp[j-1] + dp[j]) % MOD
        
        return dp[n-1]