class Solution {
    public boolean isBalanced(TreeNode root) {
        if(getHeight(root) == -1) return false;
        return true;
    }

    private int getHeight(TreeNode root) {
        if(root == null) return 0;
        var left = getHeight(root.left);
        var right = getHeight(root.right);

        if(left == -1 || right == -1) return -1;    // subtree is already unbalanced

        if(Math.abs(left - right) > 1) return -1;   // unbalanced
        return 1 + Math.max(left, right);
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