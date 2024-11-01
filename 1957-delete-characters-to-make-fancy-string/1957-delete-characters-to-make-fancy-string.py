class Solution:
    def makeFancyString(self, s: str) -> str:
        if len(s) < 3: return s

        preprev, prev = s[0], s[1]
        sb = [preprev, prev]

        for i in range(2, len(s)):
            curr = s[i]
            if curr == prev and curr == preprev: continue
            
            sb.append(curr)
            preprev = prev
            prev = curr

        return ''.join(sb)