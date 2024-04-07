public class Solution {
    public int[] MinimumCost(int n, int[][] edges, int[][] query) {
        var uf = new UnionFind(n);
        foreach(var edge in edges){
            uf.Union(edge[0], edge[1], edge[2]);
        }
        
        var ans = new int[query.Length];
        for(var i=0; i<query.Length; i++){
            // if same src & destination
            if(query[i][0] == query[i][1]){     
                ans[i] = 0;
                continue;
            }
            // if src & dest are completely different graphs
            if(!uf.Connected(query[i][0], query[i][1])){
                ans[i] = -1;
                continue;
            }
            // find out the and value when src & dest are connected
            ans[i] = uf.Find(query[i][0]).andVal;
        }
        
        return ans;
    }
}

public class UnionFind{
    VertAnd[] id;
    
    public UnionFind(int n){
        id = new VertAnd[n];
        for(int i=0; i<n; i++)
            id[i] = new VertAnd(i);
    }
    
    public VertAnd Find(int v){
        if(id[v].parent != v)
            id[v] = Find(id[v].parent);
        return id[v];
    }
    
    public void Union(int v1, int v2, int w){
        var v1_p = Find(v1);
        var v2_p = Find(v2);
        v1_p.andVal = v1_p.andVal & v2_p.andVal & w;
        id[v2_p.parent] = v1_p;
    }
    
    public bool Connected(int v1, int v2){
        return Find(v1) == Find(v2);
    }
}

public class VertAnd{
    const int ALLONEBIT = 131071;
    public int parent;
    public int andVal;
    
    public VertAnd(int p, int a = ALLONEBIT){
        parent = p;
        andVal = a;
    }
}