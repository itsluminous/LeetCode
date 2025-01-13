class Solution:
    def minimumLength(self, s: str) -> int:
        # count freq of each char
        freq = [0] * 26
        for ch in s:
            freq[ord(ch) - ord('a')] += 1
        
        # try to reduce all freq to 1 (for odd) & 2 (for even)
        removed = 0
        for num in freq:
            if (num < 3): continue  # can't reduce it
            if (num & 1) == 1: removed += num - 1    # odd freq
            else: removed += num - 2     # even freq
        
        return len(s) - removed
