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
public class Solution {
    private int tilt = 0;
    
    public int FindTilt(TreeNode root) {
        Traverse(root);
        return tilt;
    }
    
    private int Traverse(TreeNode root){
        if(root == null) return 0;
        var leftSum = Traverse(root.left);
        var rightSum = Traverse(root.right);
        tilt += Math.Abs(leftSum - rightSum);
        return root.val + leftSum + rightSum;
    }
}