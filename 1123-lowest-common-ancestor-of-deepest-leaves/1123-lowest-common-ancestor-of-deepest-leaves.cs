public class Solution {
    TreeNode ancestor;
    int maxDepth;

    public TreeNode LcaDeepestLeaves(TreeNode root) {
        GetDepth(root, 0);
        return ancestor;
    }

    private int GetDepth(TreeNode node, int currDepth){
        maxDepth = Math.Max(maxDepth, currDepth);
        if(node == null) return currDepth;

        var leftDepth = GetDepth(node.left, currDepth + 1);
        var rightDepth = GetDepth(node.right, currDepth + 1);

        if(leftDepth == maxDepth && rightDepth == maxDepth)
            ancestor = node;
        return Math.Max(leftDepth, rightDepth);
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