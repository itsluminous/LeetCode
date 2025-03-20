public class Solution {
    public int[] MinimumCost(int n, int[][] edges, int[][] query) {
        var uf = new UnionFind(n);
        foreach(var edge in edges)
            uf.Union(edge[0], edge[1], edge[2]);
        
        var ans = new int[query.Length];
        for(var i=0; i<query.Length; i++)
            ans[i] = uf.Cost(query[i][0], query[i][1]);

        return ans;
    }
}

public class UnionFind{
    int[] and;      // AND value of graph with root i
    int[] parent;   // parent of any node i
    int[] rank;     // rank for each graph with root as i

    public UnionFind(int n){
        and = new int[n];
        rank = new int[n];
        parent = new int[n];
        for(var i=0; i<n; i++){
            parent[i] = i;          // self parent initially
            rank[i] = 1;            // equal rank initially
            and[i] = 131071;        // 11111111111111111 initially = 131071 (because 0 <= w <= 10^5)
        }
    }

    public int Find(int v){
        if(parent[v] == v) return v;
        return Find(parent[v]);
    }

    public void Union(int u, int v, int w){
        // find parent of u and v
        var pu = Find(u);
        var pv = Find(v);

        // if pv is higher ranked, swap with pu
        // because we will later make pu as parent
        if(rank[pv] > rank[pu])
            (pu, pv) = (pv, pu);
        
        // make pu as parent
        parent[pv] = pu;
        rank[pu] += rank[pv];
        and[pu] = and[pu] & and[pv] & w;
    }

    public int Cost(int u, int v){
        var pu = Find(u);
        var pv = Find(v);

        if(pu != pv) return -1; // not connected
        return and[pu];
    }
}