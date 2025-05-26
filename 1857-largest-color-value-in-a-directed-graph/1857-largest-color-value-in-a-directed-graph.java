// 1. topologically sort nodes so that we start with nodes with least incoming edges
// 2. for each such nodes, while traversing, find max of each color
class Solution {
    public int largestPathValue(String colors, int[][] edges) {
        var colours = colors.toCharArray();
        var n = colors.length();
        var inDegree = new int[n];
        var dp = new int[n][26];    // track how many of each color we can have, when starting with node i
        
        // make graph
        Set<Integer>[] graph = new HashSet[n];
        for(var edge : edges){
            if(graph[edge[0]] == null) graph[edge[0]] = new HashSet<Integer>();
            graph[edge[0]].add(edge[1]);
            inDegree[edge[1]]++;
        }

        // we want to process nodes with least inDegree first
        Queue<Integer> queue = new LinkedList<>();
        for(var i=0; i<n; i++){
            if(inDegree[i] == 0) queue.offer(i);
            dp[i][colours[i] - 'a'] = 1;
        }

        // BFS to find max length
        int visited = 0, ans = 0;
        while(!queue.isEmpty()){
            var node = queue.poll();
            visited++;

            // update ans if curr node has any color count exceeding ans
            var currMax = Arrays.stream(dp[node]).max().getAsInt();
            ans = Math.max(ans, currMax);

            // update color count for all neighbours
            if(graph[node] == null) continue;   // no neighbours
            for(var next : graph[node]){
                for(var c=0; c<26; c++){
                    var nextColor = colours[next]-'a' == c ? 1 : 0;
                    dp[next][c] = Math.max(dp[next][c], dp[node][c] + nextColor);
                }
                
                // add the next node to queue if it has 0 in degree
                inDegree[next]--;
                if(inDegree[next] == 0) queue.offer(next);
            }
        }

        if(visited == n) return ans;    // if we visited all nodes, then we found ans
        return -1;
    }
}