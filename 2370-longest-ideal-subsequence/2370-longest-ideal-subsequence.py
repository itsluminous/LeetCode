class Solution:
    def longestIdealString(self, s: str, k: int) -> int:
        dp = [0]*26     # to count the max subsequence for every char, from right
        n, ans = len(s), 1

        for i in range(n-1, -1, -1):
            ch = ord(s[i])-ord('a')
            # the "ch" can only allow chars on left side of alphabet with diff <= k or right side with diff >= k
            smallest = max(0, ch-k)
            largest = min(25, ch+k)

            max_val = 0
            for j in range(smallest, largest+1):
                max_val = max(max_val, dp[j])

            dp[ch] = 1 + max_val
            ans = max(ans, dp[ch])
        
        return ans