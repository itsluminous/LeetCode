public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var dict = new Dictionary<int,TreeNode>();
        var parents = new HashSet<int>();       // candidates for root
        var children = new HashSet<int>();      // can never be root, as they have a parent

        foreach(var desc in descriptions){
            int parent = desc[0], child = desc[1];
            var isLeft = desc[2] == 1;

            // create nodes if they do not exist
            if(!dict.ContainsKey(parent)){
                var node = new TreeNode(parent);
                dict[parent] = node;
            }
            if(!dict.ContainsKey(child)){
                var node = new TreeNode(child);
                dict[child] = node;
            }

            // link parent and child
            if(isLeft)
                dict[parent].left = dict[child];
            else
                dict[parent].right = dict[child];

            // update parents and children set
            if(!children.Contains(parent)) parents.Add(parent);
            parents.Remove(child);
            children.Add(child);
        }

        // parents should now have only one value
        var p = parents.Single();
        return dict[p];
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */