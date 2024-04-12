public class Solution {
    public String longestCommonPrefix(String[] strs) {
        var trie = new Trie();
        for(var str : strs)
            addWordToTrie(trie, str);
        return findLCP(trie, strs[0].toCharArray(), strs.length);
    }

    private void addWordToTrie(Trie root, String str){
        var trie = root;
        for(var ch : str.toCharArray()){
            if(trie.next[ch-'a'] == null)
                trie.next[ch-'a'] = new Trie();
            
            trie = trie.next[ch-'a'];
            trie.count++;
        }
    }

    private String findLCP(Trie root, char[] str, int count){
        var trie = root;
        var sb = new StringBuilder();
        for(var i=0; i<str.length; i++){
            var idx = str[i]-'a';
            if(trie.next[idx] == null || trie.next[idx].count < count) break;
            sb.append(str[i]);
            trie = trie.next[idx];
        }

        return sb.toString();
    }
}

class Trie{
    public int count;
    public Trie[] next;

    public Trie(){
        count = 0;
        next = new Trie[26];
    }
}