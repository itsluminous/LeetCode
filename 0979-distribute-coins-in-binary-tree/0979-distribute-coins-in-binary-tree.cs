public class Solution {
    int moves = 0;
    
    public int DistributeCoins(TreeNode root) {
        DFS(root);
        return moves;
    }

    // return -ve if node is accepting and +ve if it is giving back
    public int DFS(TreeNode root) {
        if(root == null) return 0;

        var leftBalance = DFS(root.left);
        var rightBalance = DFS(root.right);

        var curr = leftBalance + rightBalance + root.val - 1;
        moves += (Math.Abs(curr));
        return curr;
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