class Solution:
    def countPalindromicSubsequence(self, s: str) -> int:
        n = len(s)
        first = [n] * 26
        last = [0] * 26

        for i, ch in enumerate(s):
            first[ord(ch) - ord('a')] = min(first[ord(ch) - ord('a')], i)
            last[ord(ch) - ord('a')] = i
        
        ans = 0
        for i in range(26):
            if first[i]+1 < last[i]:
                ans += len(set(s[first[i]+1:last[i]]))
        
        return ans