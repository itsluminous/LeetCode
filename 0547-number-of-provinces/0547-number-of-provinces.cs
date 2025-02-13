public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        var uf = new UnionFind(n);

        for(var i=0; i<n-1; i++)
            for(var j=i+1; j<n; j++)
                if(isConnected[i][j] == 1)
                    uf.Union(i, j);

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

        public void Union(int n1, int n2){
            var p1 = Find(n1);
            var p2 = Find(n2);
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

        public int Find(int node){
            var p = parent[node];
            if(p == node)
                return p;
            return Find(p);
        }
    }
}

// Accepted
public class SolutionDFS {
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length, province=0;
        var visited = new bool[n];  // to represent if that city is visited or not
        
        // loop through each city
        for(int i=0; i<n; i++){
            if(!visited[i]){    // if it is not part of a province already
                province++;
                visited[i] = true;
                Traverse(isConnected, visited, i, n);    // start traversing cities connected to i
            }
        }
        
        return province;
    }
    
    private void Traverse(int[][] isConnected, bool[] visited, int i, int n){
        for(int j=0; j<n; j++){
            if(i == j)  continue;   // source and destination are same cities
            
            if(isConnected[i][j] == 1 && !visited[j]){  // if j city is not visited and is connected to i
                visited[j] = true;
                Traverse(isConnected, visited, j, n);    // start traversing cities connected to j
            }
        }
    }
}