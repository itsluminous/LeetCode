class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        var trie = BuildTrie(dictionary);
        var words = sentence.Split(" ");
        for(var i=0; i < words.Length; i++){
            var match = MatchWord(trie, words[i]);
            if(match != null)
                words[i] = match;
        }

        return String.Join(' ', words);
    }

    private TrieNode BuildTrie(IList<string> dictionary){
        var root = new TrieNode();
        foreach(var word in dictionary){
            var curr = root;
            foreach(var ch in word){
                var idx = ch - 'a';
                if(curr.next[idx] == null)
                    curr.next[idx] = new TrieNode();
                curr = curr.next[idx];
            }
            curr.word = word;
        }

        return root;
    }

    private String MatchWord(TrieNode trieRoot, String word){
        var curr = trieRoot;
        foreach(var ch in word){
            var idx = ch - 'a';
            if(curr.next[idx] == null) return null;
            curr = curr.next[idx];
            if(curr.word != null) return curr.word;
        }

        return null;
    }
}

class TrieNode {
    public TrieNode[] next = new TrieNode[26];
    public String word;
}