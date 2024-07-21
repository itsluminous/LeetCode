class Solution:
    def maxOperations(self, s: str) -> int:
        count = prev = 0
        
        for i in range(len(s) - 2, -1, -1):
            if s[i] == '1':
                prev = prev + 1 if s[i + 1] == '0' else prev
                count += prev

        return count