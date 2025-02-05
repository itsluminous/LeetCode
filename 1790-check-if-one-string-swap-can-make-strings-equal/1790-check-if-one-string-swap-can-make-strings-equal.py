class Solution:
    def areAlmostEqual(self, s1: str, s2: str) -> bool:
        idx = -1   # index of first mismatch
        
        for i in range(len(s1)):
            if s1[i] == s2[i]: continue
            if idx == -2: return False # 1 swap was already done
            if idx == -1: idx = i      # first mismatch
            elif s1[idx] != s2[i] or s1[i] != s2[idx]: return False  # swapping won't help
            else: idx = -2

        return idx < 0