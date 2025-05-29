public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2) {
        // nodes at even level will be colored 0, and odd level colored 1
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] color1 = new int[n], color2 = new int[m];

        // find max reachable nodes in tree1 & tree2 for each color
        var depth1 = GetDepth(edges1, color1);
        var depth2 = GetDepth(edges2, color2);
        var maxDepth2 = Math.Max(depth2[0], depth2[1]); // max of odd or even level

        // find out max depth reachable in tree1 after joining with tree2
        var ans = new int[n];
        for (var i = 0; i < n; i++) {
            var c = color1[i];
            ans[i] = depth1[c] + maxDepth2;
        }

        return ans;
    }

    private int[] GetDepth(int[][] edges, int[] color) {
        var n = edges.Length + 1;

        // build tree
        List<int>[] tree = new List<int>[n];
        for (int i = 0; i < n; i++) tree[i] = new List<int>();
        foreach (var edge in edges) {
            tree[edge[0]].Add(edge[1]);
            tree[edge[1]].Add(edge[0]);
        }

        // find max even & odd depth
        var depth = DFS(tree, color, -1, 0, 0);
        return [depth, n - depth];
    }

    // find depth from each node
    private int DFS(List<int>[] tree, int[] color, int parent, int node, int depth) {
        var count = 1 - (depth % 2);
        color[node] = depth % 2; // color 0 = even, 1 = odd
        foreach (var next in tree[node]) {
            if (next == parent) continue;
            count += DFS(tree, color, node, next, depth + 1);
        }

        return count;
    }
}