public class Solution {
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        // create adjList and distance matrix
        var adjList = CreateAdjList(n, edges);
        var distances = CreateMatrix(n, edges, source); // to track min distance in two passes

        // find shortest path assuming all -1 are 1
        RunDijkastra(edges, adjList, distances, source, 0, 0);
        var diff = target - distances[destination,0];
        if(diff < 0) return new int[0][];

        // find shortest path with appropriate value of -1 edges
        RunDijkastra(edges, adjList, distances, source, diff, 1);
        diff = target - distances[destination,1];
        if(diff > 0) return new int[0][];

        // set all remaining -1 as 1
        foreach(var edge in edges)
            if(edge[2] == -1) edge[2] = 1;
        
        return edges;
    }

    private List<int[]>[] CreateAdjList(int n, int[][] edges){
        var adjList = new List<int[]>[n];
        for(var i=0; i<n; i++)
            adjList[i] = new List<int[]>();
        
        for(var i=0; i<edges.Length; i++){
            int node1 = edges[i][0], node2 = edges[i][1];
            adjList[node1].Add(new int[]{node2, i});
            adjList[node2].Add(new int[]{node1, i});
        }

        return adjList;
    }

    private int[,] CreateMatrix(int n, int[][] edges, int source){
        var distances = new int[n,2];
        for(var i=0; i<n; i++)
            if(i != source)
                distances[i,0] = distances[i,1] = int.MaxValue;
            else 
                distances[i,0] = 0;

        return distances;
    }

    private void RunDijkastra(int[][] edges, List<int[]>[] adjList, int[,] distances, int source, int difference, int pass){
        var n = adjList.Length;
        var pq = new PriorityQueue<int[], int>();
        pq.Enqueue(new int[]{source , 0}, 0);
        distances[source,pass] = 0;

        while(pq.Count > 0){
            var curr = pq.Dequeue();
            int currNode = curr[0], currDist = curr[1];
            if(currDist > distances[currNode,pass]) continue;

            foreach(var next in adjList[currNode]){
                int nextNode = next[0], edgeIdx = next[1];
                var weight = edges[edgeIdx][2] == -1 ? 1 : edges[edgeIdx][2];   // consider -1 as 1

                // assign appropriate weight to -1 edge in pass 1
                if(pass == 1 && edges[edgeIdx][2] == -1){
                    var newWeight = difference + distances[nextNode,0] - distances[currNode,1];
                    if(newWeight > weight)
                        edges[edgeIdx][2] = weight = newWeight; 
                }

                if (distances[nextNode,pass] > distances[currNode,pass] + weight) {
                    distances[nextNode,pass] = distances[currNode,pass] + weight;
                    pq.Enqueue(new int[]{nextNode, distances[nextNode,pass]}, distances[nextNode,pass]);
                }
            }
        }
    }
}