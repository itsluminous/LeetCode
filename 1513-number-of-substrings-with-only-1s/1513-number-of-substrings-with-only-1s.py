class Solution:
    def numSub(self, s: str) -> int:
        MOD = 1_000_000_007
        ans = ones = 0

        for ch in s:
            if ch == '1':
                ones += 1
            elif ones != 0:
                ans += (ones + 1) * ones // 2
                ans %= MOD
                ones = 0

        if ones != 0:
            ans += (ones + 1) * ones // 2
            ans %= MOD

        return ans