class Solution:
    def commonChars(self, words: List[str]) -> List[str]:
        # count occurrence of all chars in first word
        prev = [0] * 26
        for ch in words[0]:
            idx = ord(ch) - ord('a')
            prev[idx] += 1
        
        # count occurrence of all common chars in other strings
        for i in range(1, len(words)):
            curr = [0] * 26
            for ch in words[i]:
                idx = ord(ch) - ord('a')
                curr[idx] = min(prev[idx], curr[idx] + 1)
            prev = curr

        # find all chars that are common, along with frequency
        ans = []
        for i in range(26):
            for j in range(prev[i]):
                ans.append(chr(ord('a') + i))
        
        return ans