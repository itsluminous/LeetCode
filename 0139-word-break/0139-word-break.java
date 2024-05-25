class Solution {
    HashSet<Integer> seen;

    public boolean wordBreak(String s, List<String> wordDict) {
        var trie = buildTrie(wordDict);

        seen = new HashSet<>();
        return dfs(trie, s.toCharArray(), 0);
    }

    private boolean dfs(TrieNode trieRoot, char[] s, int idx){
        if(idx == s.length) return true;
        if(seen.contains(idx)) return false;
        seen.add(idx);

        var trie = trieRoot;
        while(idx < s.length){
            var chIdx = s[idx++] - 'a';
            if(trie.next[chIdx] == null) return false;

            trie = trie.next[chIdx];
            if(trie.word != null && dfs(trieRoot, s, idx))
                return true;
        }
        
        return false;
    }

    private TrieNode buildTrie(List<String> words){
        var trieRoot = new TrieNode();
        for(var word : words){
            var trie = trieRoot;
            for(var ch : word.toCharArray()){
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
    TrieNode[] next = new TrieNode[26];
    String word;
}