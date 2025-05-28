public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        // find max reachable nodes in tree1 & tree2 for each starting node
        var depth1 = GetDepth(edges1, k);
        var depth2 = GetDepth(edges2, k - 1);

        var maxDepth2 = depth2.Max();
        for (int i = 0; i < depth1.Length; i++)
            depth1[i] += maxDepth2;

        return depth1;
    }

    private int[] GetDepth(int[][] edges, int k) {
        var n = edges.Length + 1;

        // build tree
        var tree = new List<int>[n];
        for(int i = 0; i < n; i++) tree[i] = new List<int>();
        foreach(var edge in edges) {
            tree[edge[0]].Add(edge[1]);
            tree[edge[1]].Add(edge[0]);
        }

        // find depth from each node
        var depth = new int[n];
        for (int i = 0; i < n; i++)
            depth[i] = DFS(tree, k, i, -1);

        return depth;
    }

    // find depth from each node
    private int DFS(List<int>[] tree, int k, int node, int parent) {
        if(k < 0) return 0;
        var count = 1;  // self
        foreach(var next in tree[node]) {
            if(next == parent) continue;
            count += DFS(tree, k - 1, next, node);
        }
        return count;
    }
}
