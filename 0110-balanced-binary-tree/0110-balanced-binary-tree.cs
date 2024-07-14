public class Solution {
    public bool IsBalanced(TreeNode root) {
        if(GetHeight(root) == -1) return false;
        return true;
    }

    private int GetHeight(TreeNode root) {
        if(root == null) return 0;
        var left = GetHeight(root.left);
        var right = GetHeight(root.right);

        if(left == -1 || right == -1) return -1;    // subtree is already unbalanced

        if(Math.Abs(left - right) > 1) return -1;   // unbalanced
        return 1 + Math.Max(left, right);
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