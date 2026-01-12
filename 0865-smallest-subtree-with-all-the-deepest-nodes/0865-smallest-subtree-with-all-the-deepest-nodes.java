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
class Solution {
    public TreeNode subtreeWithAllDeepest(TreeNode root) {
        return dfs(root).node;
    }

    public Result dfs(TreeNode node) {
        if(node == null) return new Result(null, 0);
        Result left = dfs(node.left),
               right = dfs(node.right);
        if (left.dist > right.dist) return new Result(left.node, left.dist + 1);
        if (left.dist < right.dist) return new Result(right.node, right.dist + 1);
        return new Result(node, left.dist + 1);
    }
}

class Result {
    TreeNode node;
    int dist;
    Result(TreeNode n, int d) {
        node = n;
        dist = d;
    }
}