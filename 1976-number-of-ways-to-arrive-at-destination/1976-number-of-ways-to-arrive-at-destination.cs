public class Solution {
    public int CountPaths(int n, int[][] roads) {
        var MOD = 1_000_000_007;
        var adj = MakeGraph(n, roads);
        
        // min dist from 0 to any node
        var minDist = new long[n];
        for(var i=1; i<n; i++) minDist[i] = long.MaxValue;

        // no. of ways to reach node i
        var pathCount = new int[n];
        pathCount[0] = 1;

        // start bfs from node 0
        var queue = new PriorityQueue<long[], long>();
        queue.Enqueue([0, 0], 0);   // 0 can reach 0 in 0 time

        while(queue.Count > 0){
            var curr = queue.Dequeue();
            long currNode = curr[0], currDist = curr[1];
            if(currDist > minDist[currNode]) continue;   // we already found better way to reach this node

            // add next reachable nodes in queue
            foreach(var next in adj[currNode]){
                long nextNode = next[0], nextDist = currDist + next[1];
                if(nextDist > minDist[nextNode]) continue;    // already found shorter path
                if(nextDist == minDist[nextNode]){
                    pathCount[nextNode] = (pathCount[nextNode] + pathCount[currNode]) % MOD;
                }
                else {
                    minDist[nextNode] = nextDist;
                    pathCount[nextNode] = pathCount[currNode];
                    queue.Enqueue([nextNode, nextDist], nextDist);
                }
            }
        }

        return pathCount[n-1];
    }

    private List<int[]>[] MakeGraph(int n, int[][] roads){
        var adj = new List<int[]>[n];
        for(var i=0; i<n; i++) adj[i] = new();

        foreach(var road in roads){
            int u = road[0], v = road[1], w = road[2];
            adj[u].Add([v, w]);
            adj[v].Add([u, w]);
        }

        return adj;
    }
}