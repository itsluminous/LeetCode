class Solution:
    def countConsistentStrings(self, allowed: str, words: List[str]) -> int:
        letters = [False] * 26
        for ch in allowed:
            letters[ord(ch) - ord('a')] = True
        
        consistent = 0
        for word in words:
            consistent += 1
            for ch in word:
                if not letters[ord(ch) - ord('a')]:
                    consistent -= 1
                    break

        return consistent