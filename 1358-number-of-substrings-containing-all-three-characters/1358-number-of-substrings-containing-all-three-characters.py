class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        n, count = len(s), 0
        freq = [0] * 3

        a = ord('a')
        l = 0
        for r in range(0, n):
            freq[ord(s[r]) - a] += 1
            # every time we find all a,b,c - we can expand it to end of string potentially
            while freq[0] > 0 and freq[1] > 0 and freq[2] > 0:
                count += n - r
                freq[ord(s[l]) - a] -= 1
                l += 1

        return count