class Solution {
    public int[] stringIndices(String[] wordsContainer, String[] wordsQuery) {
        var trie = buildTrie(wordsContainer);
        var n = wordsQuery.length;
        var ans = new int[n];
        for(var i=0; i<n; i++){
            var idx = matchWord(trie, wordsQuery[i].toCharArray());
            ans[i] = idx;
        }
        return ans;
    }
    
    private static int matchWord(TrieNode root, char[] word){
        var smallest = root.smallestWordIdx;
        var curr = root;
        for(var i=word.length-1; i>=0; i--){
            var ch = word[i]-'a';
            curr = curr.next[ch];
            if(curr == null) return smallest;
            smallest = curr.smallestWordIdx;
            
        }
        return smallest;
    }
    
    private static TrieNode buildTrie(String[] words){
        var root = new TrieNode(0);
        for(var i=0; i<words.length; i++){
            var curr = root;
            var word = words[i].toCharArray();
            // when biggest suffix is blank string, pick smallest word
            if(word.length < words[root.smallestWordIdx].length())
                root.smallestWordIdx = i;

            for(var j=word.length-1; j>=0; j--){
                var ch = word[j] - 'a';
                    
                if (curr.next[ch] == null) curr.next[ch] = new TrieNode(i);
                curr = curr.next[ch];

                var oldlen = words[curr.smallestWordIdx].length();
                var currlen = word.length;
                if(oldlen > currlen)
                    curr.smallestWordIdx = i;
            }
        }
        return root;
    }
}

public class TrieNode{
    public int smallestWordIdx;
    public TrieNode[] next;

    public TrieNode(int idx){
        smallestWordIdx = idx;
        next = new TrieNode[26];
    }
}

