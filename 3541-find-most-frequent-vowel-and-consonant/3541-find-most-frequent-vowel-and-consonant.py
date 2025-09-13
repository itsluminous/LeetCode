class Solution:
    def maxFreqSum(self, s: str) -> int:
        vowels = set('aeiou')
        freq = [0] * 26
        v = c = 0

        for ch in s:
            freq[ord(ch)-ord('a')] += 1
            if ch in vowels: v = max(v, freq[ord(ch)-ord('a')])
            else: c = max(c, freq[ord(ch)-ord('a')])

        return v + c