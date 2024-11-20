class Solution:
    def takeCharacters(self, s: str, k: int) -> int:
        if k == 0: return 0    # special case

        freq = [0] * 3
        for ch in s:
            freq[ord(ch) - ord('a')] += 1
        if freq[0] < k or freq[1] < k or freq[2] < k: return -1    # not possible

        freq = [0] * 3  # reset the counter
        
        n, r = len(s), len(s)-1
        # count how many chars we need if we take only right side
        while r >= 0:
            freq[ord(s[r]) - ord('a')] += 1
            if freq[0] >= k and freq[1] >= k and freq[2] >= k: break
            r -= 1
        ans = n-r

        # increment l one by one, and try to remove chars from right
        for l in range(n):
            if(l > r): break
            freq[ord(s[l]) - ord('a')] += 1
            while r < n and freq[ord(s[r]) - ord('a')] > k:
                freq[ord(s[r]) - ord('a')] -= 1
                r += 1
            ans = min(ans, 1 + l + n - r)

        return ans