public class Solution {
    public int MinimumCost(string target, string[] words, int[] costs) {
        var n = target.Length;
        var dict = new Dictionary<string, int>();

        var dp = Enumerable.Repeat(int.MaxValue, n+1).ToArray();
        dp[0] = 0;

        var trie = new Trie();
        for (var i=0; i < words.Length; i++){
            if(!dict.ContainsKey(words[i])){
                trie.Insert(words[i], i);
                dict[words[i]] = costs[i];
            }   
            else if(dict[words[i]] > costs[i]){
                trie.Insert(words[i], i);
                dict[words[i]] = costs[i];
            }
        }

        for(var i=0; i<n; i++){
            if(dp[i] == int.MaxValue) continue;

            var root = trie.root;
            for(var j=i; j<n; j++){
                if(!root.children.ContainsKey(target[j])) break;
                root = root.children[target[j]];
                
                if(root.index != -1) {
                    var wIdx = root.index;
                    dp[j+1] = Math.Min(dp[j+1], dp[i] + costs[wIdx]);
                }
            }
        }

        return dp[n] == int.MaxValue ? -1 : dp[n];
    }

    public class TrieNode {
        public Dictionary<char, TrieNode> children = new();
        public int index = -1;
    }

    public class Trie {
        public TrieNode root = new TrieNode();

        public void Insert(string word, int index) {
            var node = root;
            foreach(var ch in word){
                if(!node.children.ContainsKey(ch))
                    node.children[ch] = new TrieNode();
                node =   node.children[ch];
            }   
            node.index = index;
        }
    }
}