class Solution {
    public List<String> stringMatching(String[] words) {
        // build trie for each permutation of each string
        var root = new TrieNode();
        for(var word : words)
            for(var start = 0; start < word.length(); start++)
                insertWord(root, word.substring(start));
        
        // find substrings
        var matching = new ArrayList<String>();
        for(var word: words)
            if(isSubstring(root, word))
                matching.add(word);
        
        return matching;
    }

    private void insertWord(TrieNode root, String word){
        var curr = root;
        for(var ch : word.toCharArray()){
            if(curr.children[ch-'a'] == null)
                curr.children[ch-'a'] = new TrieNode();
            curr = curr.children[ch-'a'];
            curr.frequency++;
        }
    }

    private boolean isSubstring(TrieNode root, String word){
        var curr = root;
        for(var ch : word.toCharArray())
            curr = curr.children[ch-'a'];

        return curr.frequency > 1;  // freq = 1 is same word
    }
}

class TrieNode {
    int frequency;
    TrieNode[] children;

    TrieNode() {
        frequency = 0;
        children = new TrieNode[26];
    }
}