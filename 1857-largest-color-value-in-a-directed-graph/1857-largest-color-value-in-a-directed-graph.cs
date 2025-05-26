// 1. topologically sort nodes so that we start with nodes with least incoming edges
// 2. for each such nodes, while traversing, find max of each color
public class Solution {
    public int LargestPathValue(string colors, int[][] edges) {
        var n = colors.Length;
        var inDegree = new int[n];
        var dp = new int[n,26];    // track how many of each color we can have, when starting with node i
        
        // make graph
        var graph = new HashSet<int>[n];
        foreach(var edge in edges){
            if(graph[edge[0]] == null) graph[edge[0]] = new HashSet<int>();
            graph[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        // we want to process nodes with least inDegree first
        var queue = new Queue<int>();
        for(var i=0; i<n; i++){
            if(inDegree[i] == 0) queue.Enqueue(i);
            dp[i,colors[i] - 'a'] = 1;
        }

        // BFS to find max length
        int visited = 0, ans = 0;
        while(queue.Count > 0){
            var node = queue.Dequeue();
            visited++;

            // update ans if curr node has any color count exceeding ans
            var currMax = 0;
            for(int c = 0; c < 26; c++)
                currMax = Math.Max(currMax, dp[node, c]);
            ans = Math.Max(ans, currMax);

            // update color count for all neighbours
            if(graph[node] == null) continue;   // no neighbours
            foreach(var next in graph[node]){
                for(var c=0; c<26; c++){
                    var nextColor = colors[next]-'a' == c ? 1 : 0;
                    dp[next,c] = Math.Max(dp[next,c], dp[node,c] + nextColor);
                }
                
                // add the next node to queue if it has 0 in degree
                inDegree[next]--;
                if(inDegree[next] == 0) queue.Enqueue(next);
            }
        }

        if(visited == n) return ans;    // if we visited all nodes, then we found ans
        return -1;
    }
}