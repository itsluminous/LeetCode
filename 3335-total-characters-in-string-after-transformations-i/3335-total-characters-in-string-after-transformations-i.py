class Solution:
    def lengthAfterTransformations(self, s: str, t: int) -> int:
        self.MOD = 1_000_000_007
        ans = 0
        dp = self.lengthAfterNTransformations()

        for ch in s:
            idx = ord(ch) - ord('a') + t
            ans = (ans + dp[idx]) % self.MOD

        return ans

    # function to find length of "a" after N transformations
    def lengthAfterNTransformations(self):
        n = 100026 # total 10^5 transformations are allowed, so 10^5 + 26 (buffer)
        dp = [1] * n    # length will be 1 till z (because transformation has not happened)
        for i in range(26, n):
            dp[i] = (dp[i-26] + dp[i-25]) % self.MOD   # 26 steps to double from a, 25 from b
        return dp