public class Solution {
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery) {
        var trie = BuildTrie(wordsContainer);
        var n = wordsQuery.Length;
        var ans = new int[n];
        for(var i=0; i<n; i++){
            var idx = MatchWord(trie, wordsQuery[i]);
            ans[i] = idx;
        }
        return ans;
    }
    
    private static int MatchWord(TrieNode root, string word){
        var smallest = root.smallestWordIdx;
        var curr = root;
        for(var i=word.Length-1; i>=0; i--){
            var ch = word[i]-'a';
            curr = curr.next[ch];
            if(curr == null) return smallest;
            smallest = curr.smallestWordIdx;
            
        }
        return smallest;
    }
    
    private static TrieNode BuildTrie(string[] words){
        var root = new TrieNode(0);
        for(var i=0; i<words.Length; i++){
            var curr = root;
            var word = words[i];
            // when biggest suffix is blank string, pick smallest word
            if(word.Length < words[root.smallestWordIdx].Length)
                root.smallestWordIdx = i;

            for(var j=word.Length-1; j>=0; j--){
                var ch = word[j] - 'a';
                    
                if (curr.next[ch] == null) curr.next[ch] = new TrieNode(i);
                curr = curr.next[ch];

                var oldlen = words[curr.smallestWordIdx].Length;
                var currlen = word.Length;
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