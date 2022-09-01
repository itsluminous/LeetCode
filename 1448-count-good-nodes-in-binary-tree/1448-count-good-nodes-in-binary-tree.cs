// DFS
public class Solution {
    public int GoodNodes(TreeNode root, int max = -10001) {
        if(root == null) return 0;
        var curr =  root.val < max ? 0 : 1;
        max = Math.Max(max, root.val);
        return curr + GoodNodes(root.left, max) + GoodNodes(root.right, max);
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