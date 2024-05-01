public class Solution {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null || root == p || root == q) return root;
        var left = lowestCommonAncestor(root.left, p, q);
        var right = lowestCommonAncestor(root.right, p, q);
        
        if(left != null && right != null) return root;  // p & q are on different subtree from current node
        return left != null ? left : right;             // both are on same subtree
    }
}