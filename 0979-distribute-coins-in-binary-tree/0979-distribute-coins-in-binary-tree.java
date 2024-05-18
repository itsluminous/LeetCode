class Solution {
    int moves = 0;
    
    public int distributeCoins(TreeNode root) {
        dfs(root);
        return moves;
    }

    // return -ve if node is accepting and +ve if it is giving back
    public int dfs(TreeNode root) {
        if(root == null) return 0;

        var leftBalance = dfs(root.left);
        var rightBalance = dfs(root.right);

        var curr = leftBalance + rightBalance + root.val - 1;
        moves += (Math.abs(curr));
        return curr;
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