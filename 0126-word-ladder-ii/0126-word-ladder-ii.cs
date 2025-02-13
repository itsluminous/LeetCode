public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var words = new HashSet<string>(wordList);
        var visited = new HashSet<string>();
        var prevWordMap = new Dictionary<string, List<string>>();     // to find prev word for any given word
        var hasEnd = false;  // to know if endWord is possible or not

        if(!words.Contains(endWord)) return new List<IList<string>>();
        
        // BFS to reach end word and track all relationships in prevWordMap
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);

        while (queue.Count > 0) {
            var levelvisit = new HashSet<string>();  // words visited in curr level, using set to avoid duplicates
            for (int k = queue.Count; k > 0; k--) {
                var word = queue.Dequeue();

                if (word == endWord) {
                    hasEnd = true;
                    break;  // because we are not interested in any sequence bigger than shortest
                }
                
                for (int i = 0; i < word.Length; i++) {
                    var chars = word.ToCharArray();
                    for (char ch = 'a'; ch <= 'z'; ch++) {
                        chars[i] = ch;
                        var newWord = new string(chars);
                        if(!words.Contains(newWord) || visited.Contains(newWord)) continue;

                        levelvisit.Add(newWord);
                        if(!prevWordMap.ContainsKey(newWord)) prevWordMap[newWord] = new List<string>();
                        prevWordMap[newWord].Add(word);
                    }
                }
            }
            
            visited.UnionWith(levelvisit);
            foreach(var w in levelvisit) queue.Enqueue(w);
        }
        
        if(!hasEnd) return new List<IList<string>>();

        // DFS to backtrack path from endWord to beginWord
        var ans = new List<IList<string>>();
        var path = new List<string>();

        void DFS(string word) {
            path.Add(word);
            if (word == beginWord) {
                var newPath = new List<string>(path);
                newPath.Reverse();
                ans.Add(newPath);
            }
            else {
                foreach (var next in prevWordMap[word])
                    DFS(next);
            }
                
            path.RemoveAt(path.Count - 1);
        }
        
        DFS(endWord);
        return ans;
    }
}