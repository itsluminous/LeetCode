public class Solution {
    Dictionary<int, List<string>> dp;

    public IList<string> WordBreak(string s, IList<string> wordDict) {
        var trie = BuildTrie(wordDict);

        dp = new Dictionary<int, List<string>>();
        return DFS(trie, s, 0);
    }

    private List<String> DFS(TrieNode trieRoot, string s, int start){
        if(dp.ContainsKey(start)) return dp[start];

        var trie = trieRoot;
        var list = new List<string>();
        if(start == s.Length){
            list.Add("");
            return list;
        }

        var sb = new StringBuilder();
        var idx = start;
        while(idx < s.Length){
            var chIdx = s[idx] - 'a';
            if(trie.next[chIdx] == null) return list;
            
            sb.Append(s[idx++]);
            trie = trie.next[chIdx];

            if(trie.word != null){
                var sublist = DFS(trieRoot, s, idx);
                if(sublist == null) continue;
                foreach(var sub in sublist){
                    if(sub == string.Empty) list.Add(sb.ToString());
                    else list.Add(sb.ToString() + " " + sub);
                }
            }
        }

        dp[start] = list;
        return list;
    }

    private TrieNode BuildTrie(IList<string> words){
        var trieRoot = new TrieNode();
        foreach(var word in words){
            var trie = trieRoot;
            foreach(var ch in word){
                var idx = ch - 'a';
                if(trie.next[idx] == null)
                    trie.next[idx] = new TrieNode();
                trie = trie.next[idx];
            }
            trie.word = word;
        }

        return trieRoot;
    }
}

class TrieNode {
    public TrieNode[] next = new TrieNode[26];
    public string word;
}