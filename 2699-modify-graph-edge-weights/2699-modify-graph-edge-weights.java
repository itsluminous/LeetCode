class Solution {
    public int[][] modifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        // create adjList and distance matrix
        var adjList = createAdjList(n, edges);
        var distances = createMatrix(n, edges, source); // to track min distance in two passes

        // find shortest path assuming all -1 are 1
        runDijkastra(edges, adjList, distances, source, 0, 0);
        var diff = target - distances[destination][0];
        if(diff < 0) return new int[][]{};

        // find shortest path with appropriate value of -1 edges
        runDijkastra(edges, adjList, distances, source, diff, 1);
        diff = target - distances[destination][1];
        if(diff > 0) return new int[][]{};

        // set all remaining -1 as 1
        for(var edge : edges)
            if(edge[2] == -1) edge[2] = 1;
        
        return edges;
    }

    private List<int[]>[] createAdjList(int n, int[][] edges){
        List<int[]>[] adjList = new ArrayList[n];
        for(var i=0; i<n; i++)
            adjList[i] = new ArrayList<>();
        
        for(var i=0; i<edges.length; i++){
            int node1 = edges[i][0], node2 = edges[i][1];
            adjList[node1].add(new int[]{node2, i});
            adjList[node2].add(new int[]{node1, i});
        }

        return adjList;
    }

    private int[][] createMatrix(int n, int[][] edges, int source){
        var distances = new int[n][2];
        Arrays.fill(distances[source], 0);
        for(var i=0; i<n; i++)
            if(i != source)
                distances[i][0] = distances[i][1] = Integer.MAX_VALUE;

        return distances;
    }

    private void runDijkastra(int[][] edges, List<int[]>[] adjList, int[][] distances, int source, int difference, int pass){
        var n = adjList.length;
        var pq = new PriorityQueue<int[]>((a, b) -> a[1] - b[1]);
        pq.offer(new int[]{source , 0});
        distances[source][pass] = 0;

        while(!pq.isEmpty()){
            var curr = pq.poll();
            int currNode = curr[0], currDist = curr[1];
            if(currDist > distances[currNode][pass]) continue;

            for(var next : adjList[currNode]){
                int nextNode = next[0], edgeIdx = next[1];
                var weight = edges[edgeIdx][2] == -1 ? 1 : edges[edgeIdx][2];   // consider -1 as 1

                // assign appropriate weight to -1 edge in pass 1
                if(pass == 1 && edges[edgeIdx][2] == -1){
                    var newWeight = difference + distances[nextNode][0] - distances[currNode][1];
                    if(newWeight > weight)
                        edges[edgeIdx][2] = weight = newWeight; 
                }

                if (distances[nextNode][pass] > distances[currNode][pass] + weight) {
                    distances[nextNode][pass] = distances[currNode][pass] + weight;
                    pq.offer(new int[]{nextNode, distances[nextNode][pass]});
                }
            }
        }
    }
}