public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);
        foreach(var edge in edges)
            uf.Union(edge[0], edge[1]);
        
        return uf.ConnectedCount();
    }
}

public class UnionFind{
    Dictionary<int, int[]> map; // key = node, val = [parent, connected node count, edges in this set]

    public UnionFind(int n){
        map = new();
        for(var i=0; i<n; i++)
            map[i] = [i, 1, 0];
    }

    public int Find(int x){
        if(map[x][0] == x) return x;
        map[x][0] = Find(map[x][0]);    // Path compression
        return map[x][0];
    }

    public void Union(int a, int b){
        // find parent of a and b
        var pa = Find(a);
        var pb = Find(b);

        // if both nodes are already connected
        if(pa == pb){
            map[pa][2]++;   // add one more edge
            return;
        }

        // if pb has more connected components, then we want to keep pb as parent
        if(map[pb][1] > map[pa][1])
            (pa, pb) = (pb, pa);
        
        map[pb][0] = pa;                // make pa as parent
        map[pa][1] += map[pb][1];       // accumulate nodes from both sets
        map[pa][2] += 1 + map[pb][2];   // accumulate edges from both sets + 1 for new edge
    }

    public int ConnectedCount(){
        var count = 0;
        foreach(var node in map.Keys){
            if(map[node][0] != node) continue;  // if not root node
            
            int nodes = map[node][1], edges = map[node][2];
            var expectedEdges = nodes * (nodes - 1) / 2;    // AP sum => 1:0, 2:1, 3:1+2, 4:1+2+3, 5:1+2+3+4
            if(edges == expectedEdges) count++;
        }

        return count;
    }
}