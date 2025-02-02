class Solution:
    def maxDifference(self, s: str) -> int:
        freq = [0] * 26
        for ch in s:
            freq[ord(ch) - ord('a')] += 1

        oddFreq, evenFreq = 0, 101
        for f in freq:
            if f == 0: continue
            if (f & 1) == 1: oddFreq = max(oddFreq, f)
            else: evenFreq = min(evenFreq, f)

        return oddFreq - evenFreq