class Solution:
    def getWordsInLongestSubsequence(self, words: List[str], groups: List[int]) -> List[str]:
        n, maxLenIdx = len(words), 0
        maxLen = [0] * n    # length of longest subsequence till index i
        prevIdx = [-1] * n  # index of the last word which led to maxLen

        for i in range(n):
            for j in range(i-1, -1, -1):
                if (maxLen[j] < maxLen[i] or
                    groups[i] == groups[j] or
                    len(words[i]) != len(words[j]) or
                    not self.ham_dist_one(words[i], words[j])
                ): continue
                prevIdx[i] = j
                maxLen[i] = maxLen[j] + 1
                if maxLen[maxLenIdx] < maxLen[i]: maxLenIdx = i

        ans = []
        while maxLenIdx >= 0:
            ans.append(words[maxLenIdx])
            maxLenIdx = prevIdx[maxLenIdx]

        ans.reverse()
        return ans

    def ham_dist_one(self, word1, word2):
        dist = 0
        for i in range(len(word1)):
            if word1[i] == word2[i]: continue
            if dist == 1: return False
            dist += 1
        return dist == 1