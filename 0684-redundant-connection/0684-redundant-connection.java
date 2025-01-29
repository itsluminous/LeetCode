class Solution {
    public int[] findRedundantConnection(int[][] edges) {
        var uf = new UnionFind(edges.length + 1);
        for(var edge : edges){
            int x = edge[0], y = edge[1];
            if(!uf.union(x, y))
                return new int[]{x, y};
        }
        
        return new int[]{};
    }
}

public class UnionFind{
    int[] parent;
    
    public UnionFind(int n){
        parent = new int[n];
        for(int i=0; i<n; i++)
            parent[i] = i;  // all are self parent initially
    }
    
    private int find(int node){
        if(parent[node] != node)
            parent[node] = find(parent[node]);
        return parent[node];
    }
    
    public boolean union(int n1, int n2){
        var n1_p = find(n1);
        var n2_p = find(n2);
        if(n1_p == n2_p) return false;

        parent[n1_p] = parent[n2_p];
        return true;
    }
}