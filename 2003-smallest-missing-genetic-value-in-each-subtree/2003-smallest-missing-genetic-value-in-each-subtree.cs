// any node which is below the node "1" or in any adjacent path of node "1" will have missing as "1"
// for other nodes, calculate missing for node "1", then go upwards till root node
public class Solution {
    List<int>[] tree;
    HashSet<int> visited;

    public int[] SmallestMissingValueSubtree(int[] parents, int[] nums) {
        var n = parents.Length;
        tree = new List<int>[n];
        visited = new HashSet<int>();

        // build the tree (adj list)
        for(var i=1; i<n; i++){
            var p = parents[i];
            if(tree[p] == null) tree[p] = new List<int>();
            tree[p].Add(i);
        }

        // by default, assume "1" to be missing number for all
        var ans = Enumerable.Repeat(1, n).ToArray();

        // find out the node with value 1.
        // We have to evaluate missing for any node upwards from this node
        // for other nodes, missing value has to be 1
        var oneIdx = -1;
        for(var i=0; i<n; i++){
            if(nums[i] == 1){
                oneIdx = i;
                break;
            }
        }

        // if there is no node with value 1, then all will have 1 as missing value
        if(oneIdx == -1) return ans;

        var missing = 1;
        int curr = oneIdx, prev = -1;   // track prev so that we don't process a subtree if already processed
        while(curr != -1){
            // visit this subtree
            var children = tree[curr];
            if(children != null){
                foreach(var child in children){
                    if(child == prev) continue;
                    DFS(child, nums);
                }
            }

            visited.Add(nums[curr]);
            
            // find missing value
            while(visited.Contains(missing)) missing++;
            ans[curr] = missing;

            // travel upwards in tree
            (prev, curr) = (curr, parents[curr]);
        }

        return ans;
    }

    // visit entire subtree starting from 'node' and mark corresponding genetic value as visited
    private void DFS(int node, int[] nums){
        visited.Add(nums[node]);
        if(tree[node] == null) return; // no children
        foreach(var child in tree[node])
            DFS(child, nums);
    }
}