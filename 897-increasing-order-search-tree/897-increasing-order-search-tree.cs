public class Solution {
    public TreeNode IncreasingBST(TreeNode root) {
        var vals = new List<int>();
        Inorder(root, vals);
        
        TreeNode result = new TreeNode(), curr = result;
        foreach(var v in vals){
            curr.right = new TreeNode(v);
            curr = curr.right;
        }
        
        return result.right;
    }
    
    private void Inorder(TreeNode node, List<int> vals){
        if(node == null) return;
        
        Inorder(node.left, vals);
        vals.Add(node.val);
        Inorder(node.right, vals);
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