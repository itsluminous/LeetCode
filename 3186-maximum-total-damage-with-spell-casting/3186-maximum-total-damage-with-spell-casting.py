class Solution:
    def maximumTotalDamage(self, power: List[int]) -> int:
        n = len(power)
        dp = [0] * (n+1)
        max_dp = ans = 0

        power.sort()
        l = 0
        for r in range(n):
            # if curr power is same as prev
            if power[r] == power[max(0, r-1)]:
                dp[r+1] = power[r] + dp[r]
                ans = max(ans, dp[r+1])
            else:
                # move l to find best dp value
                while power[r] > power[l] + 2:
                    l += 1
                    max_dp = max(max_dp, dp[l])
                dp[r+1] = power[r] + max_dp
                ans = max(ans, dp[r+1])

        return ans