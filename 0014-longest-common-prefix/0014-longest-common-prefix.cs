public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var trie = new Trie();
        foreach(var str in strs)
            AddWordToTrie(trie, str);
        return FindLCP(trie, strs[0], strs.Length);
    }

    private void AddWordToTrie(Trie root, string str){
        var trie = root;
        foreach(var ch in str){
            if(trie.Next[ch-'a'] == null)
                trie.Next[ch-'a'] = new Trie();
            
            trie = trie.Next[ch-'a'];
            trie.Count++;
        }
    }

    private string FindLCP(Trie root, string str, int count){
        var trie = root;
        var sb = new StringBuilder();
        for(var i=0; i<str.Length; i++){
            var idx = str[i]-'a';
            if(trie.Next[idx] == null || trie.Next[idx].Count < count) break;
            sb.Append(str[i]);
            trie = trie.Next[idx];
        }

        return sb.ToString();
    }
}

public class Trie{
    public int Count;
    public Trie[] Next;

    public Trie(){
        Count = 0;
        Next = new Trie[26];
    }
}