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

 // Ignore branches which will never have right value
public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null) return 0;
        if(root.val < low) return RangeSumBST(root.right, low, high);
        if(root.val > high) return RangeSumBST(root.left, low, high);
        return root.val + RangeSumBST(root.right, low, high) + RangeSumBST(root.left, low, high);
    }
}

// This also passes
public class Solution1 {
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null) return 0;
        var sum = (root.val >= low && root.val <= high) ? root.val : 0;
        sum += RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
        return sum;
    }
}