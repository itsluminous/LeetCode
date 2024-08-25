class Solution {
    public int countNodes(TreeNode root) {
        var leftDepth = depth(root, true);
        var rightDepth = depth(root, false);
        if(leftDepth == rightDepth)
            return (1 << leftDepth) - 1;    // same as Math.pow(2, leftDepth) - 1
        
        return 1 + countNodes(root.left) + countNodes(root.right);
    }

    private int depth(TreeNode root, boolean goLeft){
        var dep = 0;
        while(root != null){
            dep++;
            if(goLeft) root = root.left;
            else root = root.right;
        }
        return dep;
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