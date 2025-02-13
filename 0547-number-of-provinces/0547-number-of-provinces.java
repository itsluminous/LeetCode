class Solution {
    public int findCircleNum(int[][] isConnected) {
        var n = isConnected.length;
        var uf = new UnionFind(n);

        for(var i=0; i<n-1; i++)
            for(var j=i+1; j<n; j++)
                if(isConnected[i][j] == 1)
                    uf.union(i, j);

        return uf.count;
    }

    class UnionFind{
        int[] parent, rank;
        public int count;

        public UnionFind(int n){
            count = n;
            rank = new int[n];
            parent = new int[n];
            for(var i=0; i<n; i++)
                parent[i] = i;
        }

        public void union(int n1, int n2){
            var p1 = find(n1);
            var p2 = find(n2);
            if(p1 == p2) return;

            if(rank[p1] > rank[p2])
                parent[p2] = p1;
            else {
                parent[p1] = p2;
                if(rank[p1] == rank[p2])
                    rank[p2]++;
            }
            count--;
        }

        public int find(int node){
            var p = parent[node];
            if(p == node)
                return p;
            return find(p);
        }
    }
}

// Accepted
class SolutionDFS {
    public int findCircleNum(int[][] isConnected) {
        int n = isConnected.length, province = 0;
        var visited = new boolean[n+1];
        for(var city=0; city<n; city++)
            if(dfs(isConnected, visited, city))
                province++;

        return province;
    }

    private boolean dfs(int[][] isConnected, boolean[] visited, int city){
        if(visited[city]) return false;
        visited[city] = true;

        for(var next=0; next<isConnected.length; next++){
            if(isConnected[city][next] == 0) continue;
            dfs(isConnected, visited, next);
        }
        return true;
    }
}