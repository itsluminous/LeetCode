public class Solution {
    public boolean isValidBST(TreeNode root) {
        return isValidBST(root.left, Long.MIN_VALUE, root.val)
            && isValidBST(root.right, root.val, Long.MAX_VALUE);
    }

    public boolean isValidBST(TreeNode root, long min, long max) {
        if(root == null) return true;
        if(root.val <= min || root.val >= max) return false;
        return isValidBST(root.left, min, root.val) 
            && isValidBST(root.right, root.val, max);
    }
}