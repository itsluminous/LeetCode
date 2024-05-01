public class Solution {
    public int PathSum(TreeNode root, int targetSum) {
        if(root == null) return 0;
        return DFS(root, targetSum) + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
    }

    public int DFS(TreeNode root, long targetSum) {
        if(root == null) return 0;

        var count = 0;
        if(root.val == targetSum) count++;
        count += DFS(root.left, targetSum-root.val);
        count += DFS(root.right, targetSum-root.val);
        return count;
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