class Solution:
    def isPrefixOfWord(self, sentence: str, searchWord: str) -> int:
        words = sentence.split()
        for i, word in enumerate(words):
            if searchWord == word[:len(searchWord)]:
                return i+1
        return -1