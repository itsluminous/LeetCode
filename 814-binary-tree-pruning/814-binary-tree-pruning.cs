public class Solution {
    public TreeNode PruneTree(TreeNode root) {
        if(RemoveZeroes(root)) return null;
        return root;
        
    }
    
    private bool RemoveZeroes(TreeNode root){
        if(root == null) return false;
        
        bool left0 = false, right0 = false;
        if(root.left != null) 
            left0 = RemoveZeroes(root.left);
        if(root.right != null) 
            right0 = RemoveZeroes(root.right);
        
        if(left0) root.left = null;
        if(right0) root.right = null;
        
        if(root.left == null && root.right == null && root.val == 0) return true;
        return false;
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