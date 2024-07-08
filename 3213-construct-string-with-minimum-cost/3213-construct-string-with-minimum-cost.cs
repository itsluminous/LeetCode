public class Solution {
    public int MinimumCost(string target, string[] words, int[] costs) {
        var n = target.Length;
        var dict = new Dictionary<string, int>();

        var dp = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        dp[0] = 0;

        var trie = new Trie();
        for (var i = 0; i < words.Length; i++) {
            if (!dict.ContainsKey(words[i])) {
                trie.Insert(words[i], i);
                dict[words[i]] = costs[i];
            } else if (dict[words[i]] > costs[i]) {
                trie.Insert(words[i], i);
                dict[words[i]] = costs[i];
            }
        }

        for (var i = 0; i < n; i++) {
            if (dp[i] == int.MaxValue) continue;

            var root = trie.root;
            for (var j = i; j < n; j++) {
                root = root.children[target[j] - 'a'];
                if (root == null) break;

                if (root.index != -1) {
                    var wIdx = root.index;
                    dp[j + 1] = Math.Min(dp[j + 1], dp[i] + costs[wIdx]);
                }
            }
        }

        return dp[n] == int.MaxValue ? -1 : dp[n];
    }

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public int index = -1;
    }

    public class Trie {
        public TrieNode root = new TrieNode();

        public void Insert(string word, int index) {
            var node = root;
            foreach (var ch in word) {
                if (node.children[ch - 'a'] == null)
                    node.children[ch - 'a'] = new TrieNode();
                node = node.children[ch - 'a'];
            }
            node.index = index;
        }
    }
}