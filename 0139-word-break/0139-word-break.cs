public class Solution {
    bool[] seen;

    public bool WordBreak(string s, IList<string> wordDict) {
        var trie = BuildTrie(wordDict);

        seen = new bool[s.Length];
        return DFS(trie, s, 0);
    }

    private bool DFS(TrieNode trieRoot, string s, int idx){
        if(idx == s.Length) return true;
        if(seen[idx]) return false;
        seen[idx] = true;

        var trie = trieRoot;
        while(idx < s.Length){
            var chIdx = s[idx++] - 'a';
            if(trie.next[chIdx] == null) return false;

            trie = trie.next[chIdx];
            if(trie.word != null && DFS(trieRoot, s, idx))
                return true;
        }
        
        return false;
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

// Accepted - bad performance
public class SolutionBad {
    Dictionary<string,bool> memo = new Dictionary<string,bool>();

    public bool WordBreak(string s, IList<string> wordDict) {
        if(s.Length == 0) return true;
        if(memo.ContainsKey(s)) return memo[s];
        foreach(var word in wordDict){
            if(s.StartsWith(word)){
                if(WordBreak(s.Substring(word.Length), wordDict))
                    return true;
            }
        }
        memo[s] = false;
        return false;
    }
}