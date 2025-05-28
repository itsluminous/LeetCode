class Solution {
    public int[] maxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        // find max reachable nodes in tree1 & tree2 for each starting node
        var depth1 = getDepth(edges1, k);
        var depth2 = getDepth(edges2, k-1);

        var maxDepth2 = Arrays.stream(depth2).max().getAsInt();
        for(var i=0; i<depth1.length; i++)
            depth1[i] += maxDepth2;
        
        return depth1;
    }

    private int[] getDepth(int[][] edges, int k){
        var n = edges.length + 1;

        // build tree
        List<Integer>[] tree = new ArrayList[n];
        for(var i=0; i<n; i++) tree[i] = new ArrayList<Integer>();
        for(var edge : edges){
            tree[edge[0]].add(edge[1]);
            tree[edge[1]].add(edge[0]);
        }

        // find depth from each node
        var depth = new int[n];
        for(var i=0; i<n; i++)
            depth[i] = dfs(tree, k, i, -1);

        return depth;
    }

    // find depth from each node
    private int dfs(List<Integer>[] tree, int k, int node, int parent){
        if(k < 0) return 0;
        var count = 1;  // self
        for(var next : tree[node]){
            if(next == parent) continue;
            count += dfs(tree, k-1, next, node);
        }

        return count;
    }
}