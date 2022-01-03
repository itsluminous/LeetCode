public class Solution {
    public int MaxAncestorDiff(TreeNode root) {
        if(root == null) return 0;
        return MaxAncestorDiff(root, root.val, root.val);
    }
    
    private int MaxAncestorDiff(TreeNode node, int currMax, int currMin) {
        // return max-min when we encounter leaves
        if(node == null)
            return currMax - currMin;
        
        // update max and min based on current node
        currMax = Math.Max(currMax, node.val);
        currMin = Math.Min(currMin, node.val);
        
        // calculate max diff for left and right subtree
        var leftSide = MaxAncestorDiff(node.left, currMax, currMin);
        var rightSide = MaxAncestorDiff(node.right, currMax, currMin);
        
        // return maximum of left and right subtree
        return Math.Max(leftSide, rightSide);
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