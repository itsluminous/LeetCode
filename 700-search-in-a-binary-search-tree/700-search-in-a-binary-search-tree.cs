// Recursion
public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        if(root == null) return null;
        if(root.val == val) return root;
        
        if(root.val < val) return SearchBST(root.right, val);
        else return SearchBST(root.left, val);
    }
}

// Iteration
public class Solution1 {
    public TreeNode SearchBST(TreeNode root, int val) {
        while(root != null){
            if(root.val == val) return root;
            if(root.val < val) root = root.right;
            else root = root.left;
        }
        return null;
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