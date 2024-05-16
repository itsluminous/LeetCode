class Solution {
    public boolean evaluateTree(TreeNode root) {
        // since it is a full binary tree, then if any child is null, then it is a leaf node
        if(root.left == null) return root.val == 1;
        
        var leftVal = evaluateTree(root.left);
        var rightVal = evaluateTree(root.right);

        if(root.val == 2) return (leftVal | rightVal);
        return (leftVal & rightVal);
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