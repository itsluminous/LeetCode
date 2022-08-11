public class Solution {
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root.left, Int64.MinValue, root.val) && IsValidBST(root.right, root.val, Int64.MaxValue);
    }
    
    public bool IsValidBST(TreeNode node, long min, long max) {
        if(node == null) return true;
        if(node.val <= min || node.val >= max) return false;
        return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
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