public class Solution {
    public int MakeConnected(int n, int[][] connections) {
        var cables = connections.Length;
        if(cables < n-1) return -1;

        var uf = new UnionFind(n);
        foreach(var conn in connections)
            if(uf.Union(conn[0], conn[1]))
                cables--;

        return uf.sets - 1;
    }
}

internal class UnionFind {
    int[] parent;
    int[] rank;
    internal int sets;

    internal UnionFind(int n){
        sets = n;
        parent = new int[n];
        rank = new int[n];
        for(var i=0; i<n; i++){
            parent[i] = i;
            rank[i] = 1;
        }
    }

    internal int Find(int node){
        if(parent[node] == node)
            return node;
        return Find(parent[node]);
    }

    internal bool Union(int n1, int n2){
        var p1 = Find(n1);
        var p2 = Find(n2);
        if(p1 == p2) return false;

        if(rank[p1] > rank[p2])
            (p1, p2) = (p2, p1);

        parent[p1] = p2;
        rank[p2]++;
        sets--;
        return true;
    }
}