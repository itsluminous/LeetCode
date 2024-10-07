class Solution:
    def minLength(self, s: str) -> int:
        stack = []
        for ch in s:
            if not stack:
                stack.append(ch)
            elif stack[-1] == 'A' and ch == 'B':
                stack.pop()
            elif stack[-1] == 'C' and ch == 'D':
                stack.pop()
            else:
                stack.append(ch)
        return len(stack)