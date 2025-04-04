class Solution {
    TreeNode ancestor;
    int maxDepth;

    public TreeNode lcaDeepestLeaves(TreeNode root) {
        getDepth(root, 0);
        return ancestor;
    }

    private int getDepth(TreeNode node, int currDepth){
        maxDepth = Math.max(maxDepth, currDepth);
        if(node == null) return currDepth;

        var leftDepth = getDepth(node.left, currDepth + 1);
        var rightDepth = getDepth(node.right, currDepth + 1);

        if(leftDepth == maxDepth && rightDepth == maxDepth)
            ancestor = node;
        return Math.max(leftDepth, rightDepth);
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