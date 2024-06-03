class Solution:
    def appendCharacters(self, s: str, t: str) -> int:
        tIdx, tLen = 0, len(t)

        for sIdx in range(0, len(s)):
            if t[tIdx] == s[sIdx]: tIdx += 1
            if tIdx == tLen: break

        return tLen - tIdx