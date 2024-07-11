class Solution:
    def reverseParentheses(self, s: str) -> str:
        n = len(s)
        stack = []
        pair = [0]*n  # index which has open bracket, will have index of closing bracket as value

        for idx, ch in enumerate(s):
            if ch == '(':
                stack.append(idx)
            elif ch == ')':
                openIdx = stack.pop()
                pair[idx], pair[openIdx] = openIdx, idx

        ans = []
        idx, dir = 0, 1
        while idx < n:
            if s[idx] == '(' or s[idx] == ')':
                idx = pair[idx]
                dir = -dir
            else:
                ans.append(s[idx])
            idx += dir

        return ''.join(ans)