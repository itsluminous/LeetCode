public class Solution {
    Dictionary<int,int> dict;
    int preIdx = 0;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        dict = new Dictionary<int,int>();       // index of element in inorder array
        for(var i=0; i<inorder.Length; i++)
            dict[inorder[i]] = i;
        
        return BuildTree(preorder, 0, preorder.Length - 1);
    }
    
    private TreeNode BuildTree(int[] preorder, int left, int right){
        if(left > right) return null;   // no element left to add in tree
        
        var rootVal = preorder[preIdx++];
        var root = new TreeNode(rootVal);
        var idxOfRoot = dict[rootVal];
        root.left = BuildTree(preorder, left, idxOfRoot - 1);
        root.right = BuildTree(preorder, idxOfRoot + 1, right);
        return root;
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