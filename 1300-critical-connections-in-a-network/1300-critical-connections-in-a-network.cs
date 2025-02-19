// Tarjan's algorithm
public class Solution {
    IList<IList<int>> criticalConn;     // list of critical connections
    int[] rank;                         // to find cycle in trraversal

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var adj = MakeGraph(n, connections);
        criticalConn = new List<IList<int>>();
        rank = new int[n];
        Array.Fill(rank, -1);   // mark all as unvisited

        DFS(adj, 0, 0, -1);     // starting dfs from 0 node (picked randomly), with no parent
        return criticalConn;
    }

    private int DFS(List<int>[] adj, int node, int depth, int parent){
        if(rank[node] != -1) return rank[node];   // already visited the node

        rank[node] = depth;
        var minDepth = depth;

        foreach(var next in adj[node]){
            if(next == parent) continue; // ignore parent node
            
            var neighborRank = rank[next];
            var neighborDepth = DFS(adj, next, depth+1, node);
            minDepth = Math.Min(minDepth, neighborDepth);

            // if child has higher depth, then there is no other way to reach child
            // hence a critical connection
            if(neighborRank == -1 && neighborDepth > depth)
                criticalConn.Add([node, next]);
        }

        return minDepth;
    }

    private List<int>[] MakeGraph(int n, IList<IList<int>> connections){
        var adj = new List<int>[n];
        for(var i=0; i<n; i++) adj[i] = new();

        foreach(var conn in connections){
            int n1 = conn[0], n2 = conn[1];
            adj[n1].Add(n2);
            adj[n2].Add(n1);
        }

        return adj;
    }
}