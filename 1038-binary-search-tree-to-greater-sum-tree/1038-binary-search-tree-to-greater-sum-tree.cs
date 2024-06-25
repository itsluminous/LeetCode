public class Solution {
    int prev = 0;

    public TreeNode BstToGst(TreeNode root) {
        if(root.right != null) BstToGst(root.right);
        root.val += prev;
        prev = root.val;
        if(root.left != null) BstToGst(root.left);
        return root;
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