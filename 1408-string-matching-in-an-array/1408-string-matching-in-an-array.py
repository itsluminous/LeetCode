class Solution:
    def stringMatching(self, words: List[str]) -> List[str]:
        # build trie for each permutation of each string
        root = TrieNode()
        for word in words:
            for start in range(len(word)):
                self.insertWord(root, word[start:])
        
        # find substrings
        matching = []
        for word in words:
            if self.isSubstring(root, word):
                matching.append(word)
        
        return matching
    
    def insertWord(self, root, word):
        curr = root
        for ch in word:
            index = ord(ch) - ord('a')
            if curr.children[index] is None:
                curr.children[index] = TrieNode()
            curr = curr.children[index]
            curr.frequency += 1

    def isSubstring(self, root, word):
        curr = root
        for ch in word:
            index = ord(ch) - ord('a')
            curr = curr.children[index]
        
        return curr.frequency > 1  # freq = 1 is same word

class TrieNode:
    def __init__(self):
        self.frequency = 0
        self.children = [None] * 26