class Solution:
    def longestSubsequence(self, s: str, k: int) -> int:
        # pick all digits from right till it does not exceed k
        num, power = 0, 1
        idx, cnt = len(s) - 1, 0
        while idx >= 0 and num + power <= k:
            if s[idx] == '1':
                num += power
            power <<= 1
            cnt += 1
            idx -= 1

        # prefix all 0's
        while idx >= 0:
            if s[idx] == '0':
                cnt += 1
            idx -= 1

        return cnt