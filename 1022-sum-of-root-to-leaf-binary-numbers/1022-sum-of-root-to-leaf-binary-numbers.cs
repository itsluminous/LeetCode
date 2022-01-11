// without using string builder
public class Solution {
    public int SumRootToLeaf(TreeNode root) {
        return SumRootToLeaf(root, 0);
    }
    
    private int SumRootToLeaf(TreeNode root, int sum) {
        // base case
        if(root == null) return 0;
        // include current node value in sum
        sum = 2*sum + root.val;
        // if we reached root node, return sum till now
        if(root.left == null && root.right == null) return sum;
        // get sum of left and right subtrees
        return SumRootToLeaf(root.left, sum) + SumRootToLeaf(root.right, sum);
    }
}

// Accepted - using string builder
public class Solution1 {
    int total;
    public int SumRootToLeaf(TreeNode root) {
        SumRootToLeaf(root, new StringBuilder());
        return total;
    }
    
    private void SumRootToLeaf(TreeNode root, StringBuilder sb) {
        sb.Append(root.val);
        // found leaf node
        if(root.left == null && root.right == null){
            total += Convert.ToInt32(sb.ToString(), 2);
            sb.Length--;
            return;
        }
        if(root.left != null) SumRootToLeaf(root.left, sb);
        if(root.right != null) SumRootToLeaf(root.right, sb);
        sb.Length--;
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