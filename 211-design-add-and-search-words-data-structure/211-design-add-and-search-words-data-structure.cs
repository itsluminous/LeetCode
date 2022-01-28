public class WordDictionary {
    TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        var node = root;
        foreach(var ch in word){
            if(node.Next[ch-'a'] == null)
                node.Next[ch-'a'] = new TrieNode();
            node = node.Next[ch-'a'];
        }
        node.IsWord = true;
    }
    
    public bool Search(string word) {
        return Search(word, root);
    }
    
    private bool Search(string word, TrieNode node) {
        for(var i=0; i<word.Length; i++){
            var ch = word[i];
            if(ch == '.'){
                var j = 0;
                for(; j<26; j++){
                    if(node.Next[j] == null) continue;
                    var remainingStr = word.Substring(i + 1);
                    if(Search(remainingStr, node.Next[j])) return true;
                }
                if(j == 26) return false;
            }
            else if(node.Next[ch-'a'] == null)
                return false;
            else
                node = node.Next[ch-'a'];
        }
        return node.IsWord;
    }
}

public class TrieNode{
    public bool IsWord;
    public TrieNode[] Next = new TrieNode[26];
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */