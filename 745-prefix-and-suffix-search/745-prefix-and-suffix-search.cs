/*
https://leetcode.com/problems/prefix-and-suffix-search/discuss/144432/Java-Beat-95-just-small-modifications-in-implementing-Trie.

Take "apple" as an example, we will insert add "apple{apple", "pple{apple", "ple{apple", "le{apple", "e{apple", "{apple" into the Trie Tree.
If the query is: prefix = "app", suffix = "le", we can find it by querying our trie for
"le { app".
We use '{' because in ASCii Table, '{' is next to 'z', so we just need to create new TrieNode[27] instead of 26.
Also, compared with tradition Trie, we add the attribute index in class TrieNode.
*/
public class TrieNode {
    public TrieNode[] children;
    public int index;
    public TrieNode() {
        index = 0;
        children = new TrieNode[27];
    }
}

public class WordFilter {
    TrieNode trie;

    public WordFilter(string[] words) {
        trie = new TrieNode();
        for(var index=0; index<words.Length; index++){
            var word = "{" + words[index];
            for(var i=0; i<word.Length; i++)
                //i+1 in substring to skip first '{' in word
                InsertInTrie(trie, word.Substring(i+1) + word, index);
        }
    }
    
    private void InsertInTrie(TrieNode trie, string word, int index){
        var curr = trie;
        foreach(var ch in word){
            var idx = ch - 'a';
            if(curr.children[idx] == null)
                curr.children[idx] = new TrieNode();
            curr = curr.children[idx];
            curr.index = index;
        }
    }
    
    public int F(string prefix, string suffix) {
        if(trie == null) return -1;
        var curr = trie;
        var searchstr = suffix + "{" + prefix;
        foreach(var ch in searchstr){
            if(curr.children[ch-'a'] == null) return -1;
            curr = curr.children[ch-'a'];
        }
        
        return curr.index;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */