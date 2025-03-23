class Solution {
    public int countPaths(int n, int[][] roads) {
        var MOD = 1_000_000_007;
        var adj = makeGraph(n, roads);
        
        // min dist from 0 to any node
        var minDist = new long[n];
        for(var i=1; i<n; i++) minDist[i] = Long.MAX_VALUE;

        // no. of ways to reach node i
        var pathCount = new int[n];
        pathCount[0] = 1;

        // start bfs from node 0
        var queue = new PriorityQueue<long[]>(Comparator.comparingLong(a -> a[1]));
        queue.offer(new long[]{0, 0});   // 0 can reach 0 in 0 time

        while(!queue.isEmpty()){
            var curr = queue.poll();
            long currNode = curr[0], currDist = curr[1];
            if(currDist > minDist[(int)currNode]) continue;   // we already found better way to reach this node

            // add next reachable nodes in queue
            for(var next : adj[(int)currNode]){
                long nextNode = next[0], nextDist = currDist + next[1];
                if(nextDist > minDist[(int)nextNode]) continue;    // already found shorter path
                if(nextDist == minDist[(int)nextNode]){
                    pathCount[(int)nextNode] = (pathCount[(int)nextNode] + pathCount[(int)currNode]) % MOD;
                }
                else {
                    minDist[(int)nextNode] = nextDist;
                    pathCount[(int)nextNode] = pathCount[(int)currNode];
                    queue.offer(new long[]{nextNode, nextDist});
                }
            }
        }

        return pathCount[(int)n-1];
    }

    private List<int[]>[] makeGraph(int n, int[][] roads){
        List<int[]>[] adj = new ArrayList[n];
        for(var i=0; i<n; i++) adj[i] = new ArrayList<>();

        for(var road : roads){
            int u = road[0], v = road[1], w = road[2];
            adj[u].add(new int[]{v, w});
            adj[v].add(new int[]{u, w});
        }

        return adj;
    }
}