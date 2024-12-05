class Solution:
    def canChange(self, start: str, target: str) -> bool:
        n, sIdx, tIdx = len(start), 0, 0

        while sIdx < n or tIdx < n:
            # skip all blanks
            while sIdx < n and start[sIdx] == '_': sIdx += 1
            while tIdx < n and target[tIdx] == '_': tIdx += 1

            # either both string should be over, or none
            if sIdx == n and tIdx == n: return True
            if sIdx == n or tIdx == n: return False

            if start[sIdx] != target[tIdx] or \
                (sIdx < tIdx and start[sIdx] == 'L') or \
                (sIdx > tIdx and start[sIdx] == 'R'):
                return False

            sIdx += 1
            tIdx += 1
        return True