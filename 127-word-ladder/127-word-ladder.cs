// BFS - O(M^2 * N), where M is size of dequeued word & N is size of word list
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var set = new HashSet<string>(wordList);
        if(!set.Contains(endWord)) return 0;
        
        var q = new Queue<string>();
        var visited = new HashSet<string>();
        visited.Add(beginWord);
        q.Enqueue(beginWord);
        
        var swaps = 1;
        
        while(q.Count > 0){
            var len = q.Count();
            for(var i=0; i<len; i++){
                var word = q.Dequeue();
                if(word.Equals(endWord)) return swaps;
                
                // try swapping each letter with all 26 alphabets
                for(var j=0; j<word.Length; j++){
                    for(var ch='a'; ch <= 'z'; ch++){
                        var sb = new StringBuilder(word);
                        sb[j] = ch;
                        var newWord = sb.ToString();
                        
                        if(set.Contains(newWord) && !visited.Contains(newWord)){
                            q.Enqueue(newWord);
                            visited.Add(newWord);
                        }
                    }
                }
            }
            swaps++;
        }
        
        return 0;
    }
}