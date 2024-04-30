public class Solution {
    public int GoodNodes(TreeNode root, int biggest = int.MinValue) {
        if(root == null) return 0;
        
        var count = 0;
        if(root.val >= biggest) count++;
        count += GoodNodes(root.left, Math.Max(biggest, root.val));
        count += GoodNodes(root.right, Math.Max(biggest, root.val));

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