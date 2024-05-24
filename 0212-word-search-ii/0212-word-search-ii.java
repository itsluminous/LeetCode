class Solution {
    List<String> matches;

    public List<String> findWords(char[][] board, String[] words) {
        int m = board.length, n = board[0].length;
        matches = new ArrayList<String>();
        var trie = buildTrie(words);

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                match(board, trie, i, j);
                if(matches.size() == words.length) return matches;
            }
        }
        return matches;
    }

    private void match(char[][] board, TrieNode trie, int x, int y){
        int m = board.length, n = board[0].length;
        if(x == -1 || y == -1 || x == m || y == n) return;
        
        var ch = board[x][y];
        if(ch == '#' || trie.next[ch - 'a'] == null) return;
        trie = trie.next[ch - 'a'];

        // if found a word match
        if(trie.word != null){
            matches.add(trie.word);
            trie.word = null;   // de-duplicate
        }

        // start dfs
        board[x][y] = '#';
        match(board, trie, x-1, y);
        match(board, trie, x+1, y);
        match(board, trie, x, y-1);
        match(board, trie, x, y+1);
        board[x][y] = ch;
    }

    private TrieNode buildTrie(String[] words){
        var root = new TrieNode();
        for(var word : words){
            var curr = root;
            for(var ch : word.toCharArray()){
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
    TrieNode[] next = new TrieNode[26];
    String word;
}