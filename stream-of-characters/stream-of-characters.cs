public class StreamChecker {

    TrieNode root;
    StringBuilder sb;
    
    public StreamChecker(string[] words) {
        root = new TrieNode();
        sb = new StringBuilder();
        CreateTrie(words);
    }
    
    public bool Query(char letter) {
        sb.Append(letter);
        var node = root;
        for(var i=sb.Length-1; i>=0 && node!=null; i--){    // search for word in reverse order of sb
            var idx = sb[i]-'a';
            node = node.next[idx];
            if(node != null && node.isWord) return true;    // found matching word in trie
        }
        return false;
    }
    
    private void CreateTrie(string[] words) {
        foreach(var word in words){
            var node = root;
            for(var i=word.Length-1; i>=0; i--){        // save words in reverse order
                var idx = word[i]-'a';
                if(node.next[idx] == null)              // if there is no existing path for this char, create it
                    node.next[idx] = new TrieNode();
                node = node.next[idx];
            }
            node.isWord = true;
        }
    }
}

public class TrieNode{
    public bool isWord;
    public TrieNode[] next = new TrieNode[26];
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */