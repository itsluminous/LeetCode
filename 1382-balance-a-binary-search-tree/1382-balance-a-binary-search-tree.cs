public class Solution {
    List<TreeNode> sortedList = new();

    public TreeNode BalanceBST(TreeNode root) {
        Inorder(root);
        return BuildBST(0, sortedList.Count-1);
    }

    private TreeNode BuildBST(int start, int end){
        if(start > end) return null;
        var mid = start + (end - start)/2;
        var node = sortedList[mid];
        node.left = BuildBST(start, mid-1);
        node.right = BuildBST(mid+1, end);
        return node;
    }

    private void Inorder(TreeNode root){
        if(root == null) return;
        Inorder(root.left);
        sortedList.Add(root);
        Inorder(root.right);
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