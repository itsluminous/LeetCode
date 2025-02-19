class Solution {
    public int makeConnected(int n, int[][] connections) {
        var cables = connections.length;
        if(cables < n-1) return -1;

        var uf = new UnionFind(n);
        for(var conn : connections)
            if(uf.union(conn[0], conn[1]))
                cables--;

        return uf.sets - 1;
    }
}

class UnionFind {
    int[] parent;
    int[] rank;
    int sets;

    UnionFind(int n){
        sets = n;
        parent = new int[n];
        rank = new int[n];
        for(var i=0; i<n; i++){
            parent[i] = i;
            rank[i] = 1;
        }
    }

    int find(int node){
        if(parent[node] == node)
            return node;
        return find(parent[node]);
    }

    boolean union(int n1, int n2){
        var p1 = find(n1);
        var p2 = find(n2);
        if(p1 == p2) return false;

        if(rank[p1] > rank[p2]){
            parent[p2] = p1;
            rank[p1]++;
        }
        else{
            parent[p1] = p2;
            rank[p2]++;
        }
        sets--;
        return true;
    }
}