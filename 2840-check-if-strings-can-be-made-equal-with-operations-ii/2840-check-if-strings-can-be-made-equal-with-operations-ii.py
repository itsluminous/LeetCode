class Solution:
    def checkStrings(self, s1: str, s2: str) -> bool:
        n = len(s1)
        oddFreq, evenFreq = [0]*26, [0]*26
        for i in range(0,n,2): evenFreq[ord(s1[i]) - ord('a')] += 1
        for i in range(1,n,2): oddFreq[ord(s1[i]) - ord('a')] += 1

        for i in range(0,n,2):
            evenFreq[ord(s2[i]) - ord('a')] -= 1
            if evenFreq[ord(s2[i]) - ord('a')] < 0: return False
        for i in range(1,n,2):
            oddFreq[ord(s2[i]) - ord('a')] -= 1
            if oddFreq[ord(s2[i]) - ord('a')] < 0: return False
        return True