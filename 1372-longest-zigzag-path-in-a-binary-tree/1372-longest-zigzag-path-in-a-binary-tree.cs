public class Solution {
    int longest = 0;
    HashSet<(TreeNode, bool)> seen = new HashSet<(TreeNode, bool)>();

    public int LongestZigZag(TreeNode root) {
        if(root.left != null) LongestZigZag(root.left, 1, false);
        if(root.right != null) LongestZigZag(root.right, 1, true);
        
        // don't consider root node in equation, start from next node
        if(root.left != null) LongestZigZag(root.left);
        if(root.right != null) LongestZigZag(root.right);

        return longest;
    }

    public void LongestZigZag(TreeNode root, int curr, bool goLeft) {
        // if we have reached curr node with same left/right condition, no point in trying again
        if(seen.Contains((root, goLeft))) return;
        seen.Add((root, goLeft));

        // reached end of current path
        if((goLeft && root.left == null) || (!goLeft && root.right == null)){
            longest = Math.Max(longest, curr);
            return;
        }
        
        // explore further down
        if(goLeft) LongestZigZag(root.left, curr+1, !goLeft);
        else LongestZigZag(root.right, curr+1, !goLeft);
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