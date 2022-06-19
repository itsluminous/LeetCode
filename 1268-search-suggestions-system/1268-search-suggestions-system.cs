public class Solution {
    TrieNode root;
    
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        root = new TrieNode();
        CreateTrie(products);
        
        var result = new List<IList<string>>();
        var empty = new List<string>();
        foreach(var ch in searchWord){
            var idx = ch-'a';
            if(root != null) root = root.next[idx];
                
            if(root == null)  // no product matches the prefix
                result.Add(empty);
            else
                result.Add(root.suggestion);
        }
        return result;
    }
    
    private void CreateTrie(string[] words) {
        foreach(var word in words){
            var node = root;
            foreach(var ch in word){
                var idx = ch-'a';
                if(node.next[idx] == null) 
                    node.next[idx] = new TrieNode();
                node = node.next[idx];
                node.suggestion.Add(word);
                // always keep only 3 suggestions in list
                node.suggestion = node.suggestion.OrderBy(x => x).Take(3).ToList();
            }
        }
    }
}

public class TrieNode{
    public TrieNode[] next = new TrieNode[26];
    public List<string> suggestion = new List<string>();
}