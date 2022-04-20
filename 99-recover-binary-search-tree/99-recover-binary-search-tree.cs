public class Solution {
    public void RecoverTree(TreeNode root) {
        TreeNode First = null;  // first node in wrong place
        TreeNode Second = null; // second node in wrong place
        TreeNode Prev = null;
        InOrder(root,ref First,ref Second,ref Prev);

        // swap the two bad nodes
        var temp = First.val;
        First.val = Second.val;
        Second.val = temp;
    }
    public static void InOrder(TreeNode root, ref TreeNode First, ref TreeNode Second, ref TreeNode Prev)
    {
        if (root == null) return;
        InOrder(root.left,ref First, ref Second, ref Prev);
        if (Prev != null && root.val < Prev.val )
        {
            if (First == null) First = Prev;
            Second = root;
        }

        Prev = root;
        InOrder(root.right, ref First, ref Second, ref Prev);
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