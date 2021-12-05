// It can be done using DP, but its not needed.
// Refer : https://leetcode.com/problems/house-robber-iii/discuss/79330/Step-by-step-tackling-of-the-problem

// Here is a greedy approach
// for given res[], res[0] indicates max loot when we roobed root, and res[1] is when we did not rob
public class Solution {
    public int Rob(TreeNode root) {
        var res =  RobSub(root);
        return Math.Max(res[0], res[1]);
    }
    
    private int[] RobSub(TreeNode node){
        if(node == null) return new []{0,0};
        
        var leftRes = RobSub(node.left);
        var rightRes = RobSub(node.right);
        
        var currRobbed = node.val + leftRes[1] + rightRes[1];
        var currNotRobbed = Math.Max(leftRes[0], leftRes[1]) + Math.Max(rightRes[0], rightRes[1]);
        return new []{currRobbed,currNotRobbed};
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