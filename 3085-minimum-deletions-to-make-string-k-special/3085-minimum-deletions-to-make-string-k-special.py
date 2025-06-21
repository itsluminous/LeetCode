class Solution:
    def minimumDeletions(self, word: str, k: int) -> int:
        freq = [0] * 26
        for ch in word: freq[ord(ch) - ord('a')] += 1

        uniq_freq = set(freq)

        min_remove = float('inf')
        # we assume each freq as smallest in answer, and then check which numbers need to be removed to make it true
        for min_freq in uniq_freq:
            if min_freq == 0: continue

            curr_remove = 0
            for f in freq:
                if f < min_freq: curr_remove += f
                elif f > min_freq + k: curr_remove += f - min_freq - k

            min_remove = min(min_remove, curr_remove)

        return min_remove