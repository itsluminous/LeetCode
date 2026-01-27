class Solution {
    public int minCost(int n, int[][] edges) {
        List<int[]>[] edgeList = new ArrayList[n];
        for(var i=0; i<n; i++) edgeList[i] = new ArrayList<>();

        for(var edge : edges){
            int u = edge[0], v = edge[1], w = edge[2];
            edgeList[u].add(new int[]{v, w});
            edgeList[v].add(new int[]{u, 2 * w});
        }

        // Dijkastra
        var visited = new boolean[n];
        var minDist = new int[n];
        Arrays.fill(minDist, Integer.MAX_VALUE);
        var pq = new PriorityQueue<int[]>(Comparator.comparingInt(a -> a[0]));
        pq.offer(new int[]{0, 0});  // [distance, node]

        while(!pq.isEmpty()){
            var curr = pq.poll();
            int node = curr[1], dist = curr[0];
            if(node == n-1) return dist;    // reached destination
            if(visited[node]) continue;

            visited[node] = true;
            for(var next : edgeList[node]){
                int nd = next[0], wt = next[1];
                if(minDist[nd] > dist + wt){
                    minDist[nd] = dist + wt;
                    pq.offer(new int[]{minDist[nd], nd});
                }
            }
        }

        return -1;
    }
}