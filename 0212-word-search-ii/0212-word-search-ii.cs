public class Solution {
    List<string> matches;

    public IList<string> FindWords(char[][] board, string[] words) {
        int m = board.Length, n = board[0].Length;
        matches = new List<string>();
        var trie = BuildTrie(words);

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                Match(board, trie, i, j);
                if(matches.Count == words.Length) return matches;
            }
        }
        return matches;
    }

    private void Match(char[][] board, TrieNode trie, int x, int y){
        int m = board.Length, n = board[0].Length;
        if(x == -1 || y == -1 || x == m || y == n) return;
        
        var ch = board[x][y];
        if(ch == '#' || trie.next[ch - 'a'] == null) return;
        trie = trie.next[ch - 'a'];

        // if found a word match
        if(trie.word != null){
            matches.Add(trie.word);
            trie.word = null;   // de-duplicate
        }

        // start dfs
        board[x][y] = '#';
        Match(board, trie, x-1, y);
        Match(board, trie, x+1, y);
        Match(board, trie, x, y-1);
        Match(board, trie, x, y+1);
        board[x][y] = ch;
    }

    private TrieNode BuildTrie(string[] words){
        var root = new TrieNode();
        foreach(var word in words){
            var curr = root;
            foreach(var ch in word){
                var idx = ch - 'a';
                if(curr.next[idx] == null)
                    curr.next[idx] = new TrieNode();
                curr = curr.next[idx];
            }
            curr.word = word;
        }
        return root;
    }
}

class TrieNode {
    public TrieNode[] next = new TrieNode[26];
    public string word;
}