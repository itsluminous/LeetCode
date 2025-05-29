class Solution {
    public int[] maxTargetNodes(int[][] edges1, int[][] edges2) {
        // nodes at even level will be colored 0, and odd level colored 1
        int n = edges1.length + 1, m = edges2.length + 1;
        int[] color1 = new int[n], color2 = new int[m];

        // find max reachable nodes in tree1 & tree2 for each color
        var depth1 = getDepth(edges1, color1);
        var depth2 = getDepth(edges2, color2);
        var maxDepth2 = Math.max(depth2[0], depth2[1]); // max of odd or even level

        // find out max depth reachable in tree1 after joining with tree2
        var ans = new int[n];
        for(var i=0; i<n; i++){
            var c = color1[i];
            ans[i] = depth1[c] + maxDepth2;
        }
        
        return ans;
    }

    private int[] getDepth(int[][] edges, int[] color){
        var n = edges.length + 1;

        // build tree
        List<Integer>[] tree = new ArrayList[n];
        for(var i=0; i<n; i++) tree[i] = new ArrayList<Integer>();
        for(var edge : edges){
            tree[edge[0]].add(edge[1]);
            tree[edge[1]].add(edge[0]);
        }

        // find max even & odd depth
        var depth = dfs(tree, color, -1, 0, 0);
        return new int[]{depth, n - depth};
    }

    // find depth from each node
    private int dfs(List<Integer>[] tree, int[] color, int parent, int node, int depth){
        var count = 1 - (depth % 2);
        color[node] = depth % 2;    // color 0 = even, 1 = odd
        for(var next : tree[node]){
            if(next == parent) continue;
            count += dfs(tree, color, node, next, depth+1);
        }

        return count;
    }
}