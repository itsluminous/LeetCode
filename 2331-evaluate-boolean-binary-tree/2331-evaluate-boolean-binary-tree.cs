public class Solution {
    public bool EvaluateTree(TreeNode root) {
        // since it is a full binary tree, then if any child is null, then it is a leaf node
        if(root.left == null) return root.val == 1;
        
        var leftVal = EvaluateTree(root.left);
        var rightVal = EvaluateTree(root.right);

        if(root.val == 2) return (leftVal | rightVal);
        return (leftVal & rightVal);
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