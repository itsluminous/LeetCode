
public class Solution {
    // StringBuilder sb = new StringBuilder();
    
    public string Tree2str(TreeNode root) {
        if(root == null) return string.Empty;
        if(root.left == null && root.right == null) return root.val.ToString();
        if(root.right == null) return root.val + "(" + Tree2str(root.left) + ")";
        return root.val + "(" + Tree2str(root.left) + ")(" + Tree2str(root.right) + ")";
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