// Prim's algo for Min Spanning Tree
public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length, mstCost = 0, edgesUsed = 0;
        var inMST = new bool[n];    // track nodes included in MST
        var minDist = new int[n];
        
        // set all nodes dist as infinity, except first (as it will be dist to self)
        minDist[0] = 0; // distance from node 0 to 0
        for(var i=1; i<n; i++) minDist[i] = int.MaxValue;
        
        while(edgesUsed < n){
            var currMinEdge = int.MaxValue;
            var currNode = -1;
            
            // Pick least weight node which is not in MST.
            for(var node = 0; node < n; node++){
                if(!inMST[node] && currMinEdge > minDist[node]){
                    currMinEdge = minDist[node];
                    currNode = node;
                }
            }
            
            mstCost += currMinEdge;
            edgesUsed++;
            inMST[currNode] = true;
            
            // Update distance of adjacent nodes of current node.
            for(var nextNode = 0; nextNode < n; nextNode++){
                var dist = Math.Abs(points[currNode][0] - points[nextNode][0]) 
                         + Math.Abs(points[currNode][1] - points[nextNode][1]);
                if(!inMST[nextNode] && minDist[nextNode] > dist)
                    minDist[nextNode] = dist;
            }
        }
        
        return mstCost;
    }
}



// Accepted - Kruskal's Algorithm for Min Spanning Tree
public class Solution1 {
    public int MinCostConnectPoints(int[][] points) {
        var n = points.Length;
        
        // get all edges in graph
        var edges = new List<int[]>();
        for(var src = 0; src < n; src++){
            for(var dest = src+1; dest < n; dest++){
                var dist = Math.Abs(points[src][0] - points[dest][0]) 
                         + Math.Abs(points[src][1] - points[dest][1]);
                edges.Add(new []{dist, src, dest});
            }
        }
        
        // sort edges in ascending order of distance
        edges = edges.OrderBy(e => e[0]).ToList();
        
        var uf = new UnionFind(n);
        int mstCost = 0, edgesUsed = 0;
        
        foreach(var e in edges){
            if(edgesUsed == n) break;   // all nodes are connected now
            
            int dist = e[0], node1 = e[1], node2 = e[2];
            if(!uf.Connected(node1, node2)){
                uf.Union(node1, node2);
                mstCost += dist;
                edgesUsed++;
            }
        }
        
        return mstCost;
    }
}

public class UnionFind{
    int[] id;
    
    public UnionFind(int n){
        id = new int[n];
        for(int i=0; i<n; i++)
            id[i] = i;  // all are self parent initially
    }
    
    public int Find(int f){
        if(id[f] != f)
            id[f] = Find(id[f]);
        return id[f];
    }
    
    public void Union(int f1, int f2){
        var f1_p = Find(f1);
        var f2_p = Find(f2);
        id[f1_p] = id[f2_p];    // ideally we should check which one is small and change their parent
    }
    
    public bool Connected(int f1, int f2){
        return Find(f1) == Find(f2);
    }
}