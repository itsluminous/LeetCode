class Solution {
    public int goodNodes(TreeNode root) {
        return goodNodes(root, root.val);
    }

    public int goodNodes(TreeNode root, int biggest) {
        if(root == null) return 0;
        
        var count = 0;
        if(root.val >= biggest) count++;
        count += goodNodes(root.left, Math.max(biggest, root.val));
        count += goodNodes(root.right, Math.max(biggest, root.val));

        return count;
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