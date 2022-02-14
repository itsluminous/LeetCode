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

public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}

// Accepted - noob solution
public class Solution1 {
    int max = 0;
    
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        
        MaxDepth(root, 1);
        return max;
    }
    
    private void MaxDepth(TreeNode root, int height) {
        max = Math.Max(max, height);
        if(root.left != null) MaxDepth(root.left, height+1);
        if(root.right != null) MaxDepth(root.right, height+1);
    }
}