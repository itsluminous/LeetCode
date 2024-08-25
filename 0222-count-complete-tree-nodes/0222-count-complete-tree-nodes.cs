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
    public int CountNodes(TreeNode root) {
        var leftDepth = Depth(root, true);
        var rightDepth = Depth(root, false);
        if(leftDepth == rightDepth)
            return (1 << leftDepth) - 1;    // same as Math.Pow(2, leftDepth) - 1
        
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }

    private int Depth(TreeNode root, bool goLeft){
        var dep = 0;
        while(root != null){
            dep++;
            if(goLeft) root = root.left;
            else root = root.right;
        }
        return dep;
    }
}