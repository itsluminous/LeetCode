class Solution {
    public int minimumCost(String target, String[] words, int[] costs) {
        var n = target.length();
        var hm = new HashMap<String, Integer>();

        var dp = new int[n+1];
        Arrays.fill(dp, Integer.MAX_VALUE);
        dp[0] = 0;

        var trie = new Trie();
        for (var i=0; i < words.length; i++){
            if(!hm.containsKey(words[i])){
                trie.insert(words[i], i);
                hm.put(words[i], costs[i]);
            }   
            else if(hm.get(words[i]) > costs[i]){
                trie.insert(words[i], i);
                hm.put(words[i], costs[i]);
            }
        }
            

        for(var i=0; i<n; i++){
            if(dp[i] == Integer.MAX_VALUE) continue;

            var root = trie.root;
            for(var j=i; j<n; j++){
                root = root.children.get(target.charAt(j));
                if(root == null) break;
                
                if(root.index != -1) {
                    var wIdx = root.index;
                    dp[j+1] = Math.min(dp[j+1], dp[i] + costs[wIdx]);
                }
            }
        }

        return dp[n] == Integer.MAX_VALUE ? -1 : dp[n];
    }

    public class TrieNode {
        Map<Character, TrieNode> children = new HashMap<>();
        int index = -1;
    }

    public class Trie {
        public TrieNode root = new TrieNode();

        void insert(String word, int index) {
            TrieNode node = root;
            for (var ch : word.toCharArray()) 
                node = node.children.computeIfAbsent(ch, k -> new TrieNode());
            node.index = index;
        }
    }
}