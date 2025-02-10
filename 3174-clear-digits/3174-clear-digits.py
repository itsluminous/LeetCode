class Solution:
    def clearDigits(self, s: str) -> str:
        alpha = []
        for ch in s:
            if ch.isdigit():
                alpha.pop() # alpha will always have something
            else:
                alpha.append(ch)
        
        return ''.join(alpha)