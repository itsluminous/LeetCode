public class Solution {
    TreeNode ancestor;
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        LowestCommonAncestorRecursion(root, p, q);
        return ancestor;
    }
    
    public bool LowestCommonAncestorRecursion(TreeNode current, TreeNode p, TreeNode q) {
        if(current == null) return false;
        var left = LowestCommonAncestorRecursion(current.left, p, q) ? 1 : 0;
        var right = LowestCommonAncestorRecursion(current.right, p, q) ? 1 : 0;
        var mid = (current == p || current == q) ? 1 : 0;
        
        // if any of two variables are 1, then we found LCA
        if(left + right + mid >= 2) ancestor = current;
        
        // return true if any of these conditions is true
        return (left + right + mid > 0);
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */