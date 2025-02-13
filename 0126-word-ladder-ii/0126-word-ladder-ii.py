class Solution:
    def findLadders(self, beginWord: str, endWord: str, wordList: List[str]) -> List[List[str]]:
        queue = deque([beginWord])
        words = set(wordList)
        visited = set()
        prevWordMap = defaultdict(list)     # to find prev word for any given word
        hasEnd = False                      # to know if endWord is possible or not

        if endWord not in words: return []
        
        # BFS to reach end word and track all relationships in prevWordMap
        while queue:
            levelvisit = set()  # words visited in curr level, using set to avoid duplicates
            for _ in range(len(queue)):
                word = queue.popleft()

                if word == endWord:
                    hasEnd = True
                    break  # because we are not interested in any sequence bigger than shortest
                
                for i in range(len(word)):
                    for ch in 'abcdefghijklmnopqrstuvwxyz':
                        newword = word[:i] + ch + word[i+1:]
                        if newword not in words or newword in visited: continue
                        
                        levelvisit.add(newword)
                        prevWordMap[newword].append(word)
            
            visited.update(levelvisit)
            queue.extend(levelvisit)
        
        if not hasEnd: return []

        # DFS to backtrack path from endWord to beginWord
        ans, path = [], []

        def dfs(word):
            path.append(word)
            if word == beginWord:
                ans.append(path[::-1])
                path.pop()
                return
            
            for next in prevWordMap[word]:
                dfs(next)
            path.pop()
        
        dfs(endWord)
        return ans 