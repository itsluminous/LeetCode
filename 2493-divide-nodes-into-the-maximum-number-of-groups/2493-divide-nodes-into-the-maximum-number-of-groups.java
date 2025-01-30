class Solution {
    public int magnificentSets(int n, int[][] edges) {
        // make adj list and union find set
        List<Integer>[] adjList = new ArrayList[n];
        for(var i=0; i<n; i++) adjList[i] = new ArrayList<>();
        var uf = new UnionFind(n);

        for(var edge : edges){
            int n1 = edge[0] - 1, n2 = edge[1] - 1;
            adjList[n1].add(n2);
            adjList[n2].add(n1);
            uf.union(n1, n2);
        }

        // calculate max groups possible for each connected graph
        Map<Integer, Integer> numOfGroups = new HashMap<>();
        for(var node=0; node<n; node++){
            var groups = getNumOfGroups(adjList, node, n);
            if(groups == -1) return -1; // the graph is not bi-partite
            
            var root = uf.find(node);
            numOfGroups.put(root, Math.max(numOfGroups.getOrDefault(root, 0), groups));
        }

        // result is sum of max groups possible for each disconnected graph
        var ans = 0;
        for(var count : numOfGroups.values())
            ans += count;
        
        return ans;
    }

    private int getNumOfGroups(List<Integer>[] adjList, int src, int n){
        var deepestGroup = 0;

        var seen = new int[n];  // in which group did we see i-th node
        Arrays.fill(seen, -1);

        Queue<Integer> queue = new LinkedList<>();
        queue.offer(src);
        seen[src] = 0;

        // BFS to calculate groups count
        while (!queue.isEmpty()) {
            for(var i=queue.size(); i>0; i--){
                var node = queue.poll();
                for(var next : adjList[node]){
                    // if we are seeing "next" first time, put it in new group
                    if(seen[next] == -1){
                        seen[next] = deepestGroup + 1;
                        queue.offer(next);
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
    
    public int find(int node){
        if(parent[node] != node)
            parent[node] = find(parent[node]);
        return parent[node];
    }
    
    public void union(int n1, int n2){
        var n1_p = find(n1);
        var n2_p = find(n2);
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