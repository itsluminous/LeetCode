class Solution {
    HashMap<Integer, List<String>> dp;

    public List<String> wordBreak(String s, List<String> wordDict) {
        var trie = buildTrie(wordDict);

        dp = new HashMap<>();
        return dfs(trie, s.toCharArray(), 0);
    }

    private List<String> dfs(TrieNode trieRoot, char[] s, int start){
        if(dp.containsKey(start)) return dp.get(start);

        var trie = trieRoot;
        var list = new ArrayList<String>();
        if(start == s.length){
            list.add("");
            return list;
        }

        var sb = new StringBuilder();
        var idx = start;
        while(idx < s.length){
            var chIdx = s[idx] - 'a';
            if(trie.next[chIdx] == null) return list;
            
            sb.append(s[idx++]);
            trie = trie.next[chIdx];

            if(trie.word != null){
                var sublist = dfs(trieRoot, s, idx);
                if(sublist == null) continue;
                for(var sub : sublist){
                    if(sub.isEmpty()) list.add(sb.toString());
                    else list.add(sb.toString() + " " + sub);
                }
            }
        }

        dp.put(start, list);
        return list;
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