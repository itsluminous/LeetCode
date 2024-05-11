class Solution {
    List<Integer>[] tree;
    HashSet<Integer> visited;

    public int[] smallestMissingValueSubtree(int[] parents, int[] nums) {
        var n = parents.length;
        tree = new ArrayList[n];
        visited = new HashSet<>();

        // build the tree (adjacency list)
        for (var i = 1; i < n; i++) {
            var p = parents[i];
            if (tree[p] == null) tree[p] = new ArrayList<>();
            tree[p].add(i);
        }

        // by default, assume "1" to be missing number for all
        var ans = new int[n];
        Arrays.fill(ans, 1);

        // find out the node with value 1.
        // We have to evaluate missing for any node upwards from this node
        // for other nodes, missing value has to be 1
        var oneIdx = -1;
        for (var i = 0; i < n; i++) {
            if (nums[i] == 1) {
                oneIdx = i;
                break;
            }
        }

        // if there is no node with value 1, then all will have 1 as missing value
        if (oneIdx == -1) return ans;

        var missing = 1;
        int curr = oneIdx, prev = -1;   // track prev so that we don't process a subtree if already processed
        while (curr != -1) {
            // visit this subtree
            var children = tree[curr];
            if (children != null) {
                for (var child : children) {
                    if (child == prev) continue;
                    dfs(child, nums);
                }
            }

            visited.add(nums[curr]);

            // find missing value
            while (visited.contains(missing)) missing++;
            ans[curr] = missing;

            // travel upwards in tree
            prev = curr;
            curr = parents[curr];
        }

        return ans;
    }

    // visit entire subtree starting from 'node' and mark corresponding genetic value as visited
    private void dfs(int node, int[] nums) {
        visited.add(nums[node]);
        if (tree[node] == null) return; // no children
        for (var child : tree[node])
            dfs(child, nums);
    }
}
