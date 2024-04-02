class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False
        
        sval = [0]*256
        tval = [0]*256

        for i in range(len(s)):
            sch, tch = s[i], t[i]
            if sval[ord(sch)] != tval[ord(tch)]:
                return False
            sval[ord(sch)] = tval[ord(tch)] = i + 1

        return True