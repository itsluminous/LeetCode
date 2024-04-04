# maxDepth is going to be max open brackets at any time
class Solution:
    def maxDepth(self, s: str) -> int:
        max_depth = open_brackets = 0

        for ch in s:
            if ch == '(':
                open_brackets += 1;
                max_depth = max(max_depth, open_brackets)
            elif ch == ')':
                open_brackets -= 1;
        
        return max_depth