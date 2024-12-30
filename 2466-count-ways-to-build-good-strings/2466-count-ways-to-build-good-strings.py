class Solution:
    def countGoodStrings(self, low: int, high: int, zero: int, one: int) -> int:
        mod = 1_000_000_007
        dp = [0] * (high + 1)
        dp[0] = 1  # only one way to have string of length 0

        # fill the dp
        for i in range(1, high+1):
            if i >= zero:
                # can reach dp[i] by adding "zero" no. of 0
                dp[i] += dp[i-zero]
            
            if i >= one:
                # can reach dp[i] by adding "one" no. of 1
                dp[i] += dp[i-one]
            
            dp[i] %= mod

        # count the good strings in range(low, high)
        count = 0
        for i in range(low, high+1):
            count += dp[i]
            count %= mod

        return count