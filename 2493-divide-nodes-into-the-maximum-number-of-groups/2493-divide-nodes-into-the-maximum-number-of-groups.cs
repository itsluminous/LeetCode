public class Solution {
    public int MagnificentSets(int n, int[][] edges) {
        // make adj list and union find set
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++) adjList[i] = new List<int>();
        var uf = new UnionFind(n);

        foreach(var edge in edges){
            int n1 = edge[0] - 1, n2 = edge[1] - 1;
            adjList[n1].Add(n2);
            adjList[n2].Add(n1);
            uf.Union(n1, n2);
        }

        // calculate max groups possible for each connected graph
        var numOfGroups = new Dictionary<int, int>();
        for(var node=0; node<n; node++){
            var groups = GetNumOfGroups(adjList, node, n);
            if(groups == -1) return -1; // the graph is not bi-partite
            
            var root = uf.Find(node);
            if(!numOfGroups.ContainsKey(root)) numOfGroups[root] = groups;
            else numOfGroups[root] = Math.Max(numOfGroups[root], groups);
        }

        // result is sum of max groups possible for each disconnected graph
        var ans = 0;
        foreach(var count in numOfGroups.Values)
            ans += count;
        
        return ans;
    }

    private int GetNumOfGroups(List<int>[] adjList, int src, int n){
        var deepestGroup = 0;

        var seen = new int[n];  // in which group did we see i-th node
        for(var i=0; i<n; i++) seen[i] = -1;

        var queue = new Queue<int>();
        queue.Enqueue(src);
        seen[src] = 0;

        // BFS to calculate groups count
        while(queue.Count > 0){
            for(var i=queue.Count; i>0; i--){
                var node = queue.Dequeue();
                foreach(var next in adjList[node]){
                    // if we are seeing "next" first time, put it in new group
                    if(seen[next] == -1){
                        seen[next] = deepestGroup + 1;
                        queue.Enqueue(next);
                    }
                    // if next node is in same group, then it is invalid graph
                    else if(seen[next] == deepestGroup)
                        return -1;
                }
            }
            deepestGroup++;
        }

        return deepestGroup;
    }
}

public class UnionFind{
    int[] parent;
    int[] depth;    // will be used to keep tree balanced
    
    public UnionFind(int n){
        parent = new int[n];
        depth = new int[n];
        for(var i=0; i<n; i++){
            parent[i] = i;  // all are self parent initially
            depth[i] = 1;   // only one node in each set initially
        }
    }
    
    public int Find(int node){
        if(parent[node] != node)
            parent[node] = Find(parent[node]);
        return parent[node];
    }
    
    public void Union(int n1, int n2){
        var n1_p = Find(n1);
        var n2_p = Find(n2);
        if(n1_p == n2_p) return;

        if(depth[n1_p] >= depth[n2_p]){
            var temp = n1_p;
            n1_p = n2_p;
            n2_p = temp;
        }
        
        parent[n1_p] = n2_p;
        if(depth[n1_p] == depth[n2_p]) depth[n2_p]++;
    }
}