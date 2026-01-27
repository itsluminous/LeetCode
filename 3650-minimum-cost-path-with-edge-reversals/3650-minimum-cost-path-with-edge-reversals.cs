public class Solution {
    public int MinCost(int n, int[][] edges) {
        var edgeList = new List<int[]>[n];
        for(var i=0; i<n; i++) edgeList[i] = new List<int[]>();

        foreach(var edge in edges){
            int u = edge[0], v = edge[1], w = edge[2];
            edgeList[u].Add([v, w]);
            edgeList[v].Add([u, 2 * w]);
        }

        // Dijkastra
        var visited = new bool[n];
        var minDist = new int[n];
        Array.Fill(minDist, int.MaxValue);
        var pq = new PriorityQueue<int[], int>();
        pq.Enqueue([0, 0], 0);  // [distance, node]

        while(pq.Count > 0){
            var curr = pq.Dequeue();
            int node = curr[1], dist = curr[0];
            if(node == n-1) return dist;    // reached destination
            if(visited[node]) continue;

            visited[node] = true;
            foreach(var next in edgeList[node]){
                int nd = next[0], wt = next[1];
                if(minDist[nd] > dist + wt){
                    minDist[nd] = dist + wt;
                    pq.Enqueue([minDist[nd], nd], minDist[nd]);
                }
            }
        }

        return -1;
    }
}