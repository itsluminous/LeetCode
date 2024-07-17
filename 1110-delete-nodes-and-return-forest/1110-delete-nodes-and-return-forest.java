class Solution {
    List<TreeNode> roots = new ArrayList<TreeNode>();

    public List<TreeNode> delNodes(TreeNode root, int[] to_delete) {
        var delete = new boolean[1001];
        for(var num : to_delete)
            delete[num] = true;
        
        dfs(root, null, delete);
        return roots;
    }

    private void dfs(TreeNode node, TreeNode prev, boolean[] to_delete) {
        if(node == null) return;

        // check if we found root node
        if(!to_delete[node.val]){
            if(prev == null) roots.add(node);
            prev = node;
        }
        else prev = null;

        // save the left & right child in variable
        var childLeft = node.left;
        var childRight = node.right;

        // set left/right child as null if they are to be deleted
        if(childLeft != null && to_delete[childLeft.val])
            node.left = null;
        if(childRight != null && to_delete[childRight.val])
            node.right = null;

        // check further if more nodes are to be deleted
        dfs(childLeft, prev, to_delete);
        dfs(childRight, prev, to_delete);
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