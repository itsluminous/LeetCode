class Solution {
    public TreeNode createBinaryTree(int[][] descriptions) {
        var hm = new HashMap<Integer,TreeNode>();
        var parents = new HashSet<Integer>();       // candidates for root
        var children = new HashSet<Integer>();      // can never be root, as they have a parent

        for(var desc : descriptions){
            int parent = desc[0], child = desc[1];
            var isLeft = desc[2] == 1;

            // create nodes if they do not exist
            if(!hm.containsKey(parent)){
                var node = new TreeNode(parent);
                hm.put(parent, node);
            }
            if(!hm.containsKey(child)){
                var node = new TreeNode(child);
                hm.put(child, node);
            }

            // link parent and child
            if(isLeft)
                hm.get(parent).left = hm.get(child);
            else
                hm.get(parent).right = hm.get(child);

            // update parents and children set
            if(!children.contains(parent)) parents.add(parent);
            parents.remove(child);
            children.add(child);
        }

        // parents should now have only one value
        var p = parents.iterator().next();
        return hm.get(p);
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */