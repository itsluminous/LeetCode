class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        s = list(s)
        stack = []

        for i,ch in enumerate(s):
            if ch == '(':
                stack.append(i)
            elif ch == ')' and stack:
                stack.pop()
            elif ch == ')':
                s[i] = ''

        while stack:
            s[stack.pop()] = ''

        return ''.join(s)

# Accepted, using separate array for marker
class SolutionUsingArr:
    def minRemoveToMakeValid(self, s: str) -> str:
        stack = []
        remove_idx = [False] * len(s)

        for i,ch in enumerate(s):
            if ch == '(':
                stack.append(i)
            elif ch == ')' and stack:
                stack.pop()
            elif ch == ')':
                remove_idx[i] = True

        while stack:
            remove_idx[stack.pop()] = True

        sb = []
        for i,ch in enumerate(s):
            if not remove_idx[i]:
                sb.append(ch)

        return ''.join(sb)