class Solution:
    def mergeAlternately(self, word1: str, word2: str) -> str:
        w1, w2 = len(word1), len(word2)
        i = j = 0

        ans = ''
        while i < w1 and j < w2:
            ans += word1[i] + word2[j]
            i += 1
            j += 1
        
        while i < w1:
            ans += word1[i]
            i += 1
        while j < w2:
            ans += word2[j]
            j += 1

        return ans