class Solution:
    def findPermutationDifference(self, s: str, t: str) -> int:
        pos = [0]*26
        for i,ch in enumerate(s):
            pos[ord(ch)-ord('a')] = i
        
        ans = 0
        for i,ch in enumerate(t):
            ans += abs(pos[ord(ch)-ord('a')] - i)
        
        return ans