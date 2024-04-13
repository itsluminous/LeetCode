class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        trie = Trie()
        for str in strs:
            self.addWordToTrie(trie, str)
        return self.findLCP(trie, strs[0], len(strs))

    def addWordToTrie(self, root, str):
        trie = root
        for ch in str:
            idx = ord(ch) - ord('a')
            if not trie.next[idx]:
               trie.next[idx] = Trie()
            trie = trie.next[idx]
            trie.count += 1
    
    def findLCP(self, root, str, count):
        trie = root
        ans = []
        for i,ch in enumerate(str):
            idx = ord(ch) - ord('a')
            if not trie.next[idx] or trie.next[idx].count < count: break
            ans.append(ch)
            trie = trie.next[idx]

        return ''.join(ans)

class Trie:
    def __init__(self):
        self.count = 0
        self.next = [None] * 26