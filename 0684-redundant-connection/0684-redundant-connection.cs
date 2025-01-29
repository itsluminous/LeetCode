public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var uf = new UnionFind(edges.Length + 1);
        foreach(var edge in edges){
            int x = edge[0], y = edge[1];
            if(!uf.Union(x, y))
                return [x, y];
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
    
    private int Find(int node){
        if(parent[node] != node)
            parent[node] = Find(parent[node]);
        return parent[node];
    }
    
    public bool Union(int n1, int n2){
        var n1_p = Find(n1);
        var n2_p = Find(n2);
        if(n1_p == n2_p) return false;

        parent[n1_p] = parent[n2_p];
        return true;
    }
}