class Solution {
    public int countCompleteComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);
        for(var edge : edges)
            uf.union(edge[0], edge[1]);
        
        return uf.connectedCount();
    }
}

class UnionFind{
    HashMap<Integer, int[]> map; // key = node, val = [parent, connected node count, edges in this set]

    public UnionFind(int n){
        map = new HashMap<>();
        for(var i=0; i<n; i++)
            map.put(i, new int[]{i, 1, 0});
    }

    public int find(int x){
        if(map.get(x)[0] == x) return x;
        map.get(x)[0] = find(map.get(x)[0]);    // Path compression
        return map.get(x)[0];
    }

    public void union(int a, int b){
        // find parent of a and b
        var pa = find(a);
        var pb = find(b);

        // if both nodes are already connected
        if(pa == pb){
            map.get(pa)[2]++;   // add one more edge
            return;
        }

        // if pb has more connected components, then we want to keep pb as parent
        if(map.get(pb)[1] > map.get(pa)[1]){
            var tmp = pa;
            pa = pb;
            pb = tmp;
        }
        
        map.get(pb)[0] = pa;                // make pa as parent
        map.get(pa)[1] += map.get(pb)[1];       // accumulate nodes from both sets
        map.get(pa)[2] += 1 + map.get(pb)[2];   // accumulate edges from both sets + 1 for new edge
    }

    public int connectedCount(){
        var count = 0;
        for(var node : map.keySet()){
            if(map.get(node)[0] != node) continue;  // if not root node
            
            int nodes = map.get(node)[1], edges = map.get(node)[2];
            var expectedEdges = nodes * (nodes - 1) / 2;    // AP sum => 1:0, 2:1, 3:1+2, 4:1+2+3, 5:1+2+3+4
            if(edges == expectedEdges) count++;
        }

        return count;
    }
}