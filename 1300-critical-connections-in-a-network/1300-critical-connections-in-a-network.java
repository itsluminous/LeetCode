// Tarjan's algorithm
class Solution {
    List<List<Integer>> criticalConn;   // list of critical connections
    int[] rank;                         // to find cycle in trraversal

    public List<List<Integer>> criticalConnections(int n, List<List<Integer>> connections) {
        var adj = makeGraph(n, connections);
        criticalConn = new ArrayList<>();
        rank = new int[n];
        Arrays.fill(rank, -1);   // mark all as unvisited

        dfs(adj, 0, 0, -1);      // starting dfs from 0 node (picked randomly), with no parent
        return criticalConn;
    }

    private int dfs(List<Integer>[] adj, int node, int depth, int parent){
        if(rank[node] != -1) return rank[node];   // already visited the node

        rank[node] = depth;
        var minDepth = depth;

        for(var next : adj[node]){
            if(next == parent) continue; // ignore parent node
            
            var neighborRank = rank[next];
            var neighborDepth = dfs(adj, next, depth+1, node);
            minDepth = Math.min(minDepth, neighborDepth);

            // if child has higher depth, then there is no other way to reach child
            // hence a critical connection
            if(neighborRank == -1 && neighborDepth > depth)
                criticalConn.add(Arrays.asList(node, next));
        }

        return minDepth;
    }

    private List<Integer>[] makeGraph(int n, List<List<Integer>> connections){
        var adj = new ArrayList[n];
        for(var i=0; i<n; i++) adj[i] = new ArrayList<>();

        for(var conn : connections){
            int n1 = conn.get(0), n2 = conn.get(1);
            adj[n1].add(n2);
            adj[n2].add(n1);
        }

        return adj;
    }
}