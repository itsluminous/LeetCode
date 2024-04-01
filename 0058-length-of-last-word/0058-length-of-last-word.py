class Solution:
    def lengthOfLastWord(self, s: str) -> int:
        prev_len = 0
        len = 0
        
        for i,ch in enumerate(s):
            if ch == ' ' and len > 0:
                prev_len = len
                len = 0
            elif ch == ' ':
                continue
            else:
                len += 1
        
        return len if len > 0 else prev_len

# Accepted - using inbuilt Split
class SolutionTrim:
    def lengthOfLastWord(self, s: str) -> int:
        words = s.strip().split()
        return len(words[-1])