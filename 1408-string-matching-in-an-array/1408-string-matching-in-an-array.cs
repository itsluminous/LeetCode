public class Solution {
    public IList<string> StringMatching(string[] words) {
        // build trie for each permutation of each string
        var root = new TrieNode();
        foreach(var word in words)
            for(var start = 0; start < word.Length; start++)
                InsertWord(root, word.Substring(start));
        
        // find substrings
        var matching = new List<string>();
        foreach(var word in words)
            if(IsSubstring(root, word))
                matching.Add(word);
        
        return matching;
    }

    private void InsertWord(TrieNode root, string word){
        var curr = root;
        foreach(var ch in word){
            if(curr.children[ch-'a'] == null)
                curr.children[ch-'a'] = new TrieNode();
            curr = curr.children[ch-'a'];
            curr.frequency++;
        }
    }

    private bool IsSubstring(TrieNode root, string word){
        var curr = root;
        foreach(var ch in word)
            curr = curr.children[ch-'a'];

        return curr.frequency > 1;  // freq = 1 is same word
    }
}

public class TrieNode {
    public int frequency;
    public TrieNode[] children;

    public TrieNode() {
        frequency = 0;
        children = new TrieNode[26];
    }
}