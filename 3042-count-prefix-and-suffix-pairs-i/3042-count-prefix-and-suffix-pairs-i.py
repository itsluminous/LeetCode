class Solution:
    def countPrefixSuffixPairs(self, words: List[str]) -> int:
        n = len(words)
        count = 0
        for i in range(n - 1):
            str1 = words[i]
            for j in range(i + 1, n):
                if self.is_prefix_and_suffix(str1, words[j]):
                    count += 1
        return count

    def is_prefix_and_suffix(self, str1, str2):
        return len(str1) <= len(str2) and str2.startswith(str1) and str2.endswith(str1)