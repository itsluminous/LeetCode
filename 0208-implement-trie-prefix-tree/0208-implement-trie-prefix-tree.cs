public class Trie {
    TrieNode head;

    public Trie() {
        head = new TrieNode();
    }
    
    public void Insert(string word) {
        var node = head;
        foreach(var ch in word){
            var idx = ch-'a';
            if(node.next[idx] == null) node.next[idx] = new TrieNode();
            node = node.next[idx];
            node.prefix++;
        }
        node.word++;
    }
    
    public bool Search(string word) {
        var node = head;
        foreach(var ch in word){
            var idx = ch-'a';
            if(node.next[idx] == null) return false;
            node = node.next[idx];
        }
        return node.word > 0;
    }
    
    public bool StartsWith(string prefix) {
        var node = head;
        foreach(var ch in prefix){
            var idx = ch-'a';
            if(node.next[idx] == null) return false;
            node = node.next[idx];
        }
        return true;
    }
}

public class TrieNode {
    public int prefix; // to track how many words touch this trie node
    public int word;   // to track how many words end at this node
    public TrieNode[] next;
    
    public TrieNode(){
        next = new TrieNode[26];
        prefix = 0;
        word = 0;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */