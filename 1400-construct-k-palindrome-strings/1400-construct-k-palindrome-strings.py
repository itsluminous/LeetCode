class Solution:
    def canConstruct(self, s: str, k: int) -> bool:
        if len(s) < k: return False
        if len(s) == k: return True

        freq = [0] * 26
        for ch in s:
            freq[ord(ch) - ord('a')] += 1
        
        # count how many freq are odd
        odd = 0  
        for num in freq:
            if (num & 1) == 1: odd += 1
        
        # each odd freq will need to be in a separate palindrome string
        return odd <= k
        