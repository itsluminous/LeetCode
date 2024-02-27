public class Solution {
    int max = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        GetDepth(root);
        return max;
    }

    public int GetDepth(TreeNode root) {
        if(root == null) return 0;

        var leftDepth = GetDepth(root.left);
        var rightDepth = GetDepth(root.right);
        
        max = Math.Max(max, leftDepth + rightDepth);
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}