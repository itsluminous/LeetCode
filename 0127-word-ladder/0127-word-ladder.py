class Solution:
    def ladderLength(self, beginWord: str, endWord: str, wordList: List[str]) -> int:
        wordSet = set(wordList)
        if endWord not in wordSet: return 0

        queue = deque()
        queue.append(beginWord)

        steps = 1
        while queue:
            steps += 1
            for _ in range(len(queue)):
                word = queue.popleft()
                if self.transformWord(wordSet, queue, word, endWord):
                    return steps
        
        return 0
    
    def transformWord(self, wordSet, queue, word, endWord):
        for i in range(len(word)):
            chars = list(word)
            for ch in range(ord('a'), ord('z') + 1):
                chars[i] = chr(ch)
                newWord = ''.join(chars)
                if newWord == endWord:
                    return True
                if newWord in wordSet:
                    queue.append(newWord)
                    wordSet.remove(newWord)
        
        return False
