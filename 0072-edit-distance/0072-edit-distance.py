class Solution:
    def minDistance(self, word1: str, word2: str) -> int:
        len1, len2 = len(word1), len(word2)
        self.dp = [[-1] * len2 for _ in range(len1)]
        return self.getDistance(word1, word2, 0, 0)

    def getDistance(self, word1: str, word2: str, w1: int, w2: int) -> int:
        len1, len2 = len(word1), len(word2)
        if w1 == len1 and w2 == len2: return 0              # no further changes needed
        if w1 == len1: return len2 - w2                     # insert all remaining chars
        if w2 == len2: return len1 - w1                     # delete remaining chars
        if self.dp[w1][w2] != -1: return self.dp[w1][w2]    # already evaluated

        dist = 0
        
        # if chars at curr index in both words match
        if word1[w1] == word2[w2]:
            dist = self.getDistance(word1, word2, w1+1, w2+1)
        else:
            dist = 1 + self.getDistance(word1, word2, w1+1, w2+1)           # replace
            dist = min(dist, 1 + self.getDistance(word1, word2, w1+1, w2))  # delete
            dist = min(dist, 1 + self.getDistance(word1, word2, w1, w2+1))  # insert

        self.dp[w1][w2] = dist
        return dist