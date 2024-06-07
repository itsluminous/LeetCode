class Solution {
    public String replaceWords(List<String> dictionary, String sentence) {
        var trie = buildTrie(dictionary);
        var words = sentence.split(" ");
        for(var i=0; i < words.length; i++){
            var match = matchWord(trie, words[i]);
            if(match != null)
                words[i] = match;
        }

        return String.join(" ", words);
    }

    private TrieNode buildTrie(List<String> dictionary){
        var root = new TrieNode();
        for(var word : dictionary){
            var curr = root;
            for(var ch : word.toCharArray()){
                var idx = ch - 'a';
                if(curr.next[idx] == null)
                    curr.next[idx] = new TrieNode();
                curr = curr.next[idx];
            }
            curr.word = word;
        }

        return root;
    }

    private String matchWord(TrieNode trieRoot, String word){
        var curr = trieRoot;
        for(var ch : word.toCharArray()){
            var idx = ch - 'a';
            if(curr.next[idx] == null) return null;
            curr = curr.next[idx];
            if(curr.word != null) return curr.word;
        }

        return null;
    }
}

class TrieNode {
    TrieNode[] next = new TrieNode[26];
    String word;
}