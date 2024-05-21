class Solution {
    int diameter = 0;

    public int diameterOfBinaryTree(TreeNode root) {
        diameterOfSubTree(root);
        return diameter;
    }

    public int diameterOfSubTree(TreeNode root) {
        if(root == null) return 0;

        var left = diameterOfSubTree(root.left);
        var right = diameterOfSubTree(root.right);
        diameter = Math.max(diameter, (left + right));
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