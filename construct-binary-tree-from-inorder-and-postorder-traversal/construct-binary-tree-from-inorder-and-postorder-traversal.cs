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
// Easy to understand - https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/discuss/758462/C++-Detail-Explain-or-Diagram
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return BuildTree(inorder, 0, inorder.Length-1, postorder, 0, postorder.Length-1);
    }
    
    private TreeNode BuildTree(int[] inorder, int inL, int inR, int[] postorder, int poL, int poR) {
        if(inL > inR || poL > poR) return null;         // if index goes out of bound
        var node = new TreeNode(postorder[poR]);        // create a root node for current index
        
        // now find this node in inorder array
        var inIdx = inL;
        while(inorder[inIdx] != node.val) inIdx++;
        
        // also find where to split the postorder array
        var poIdx = poL+inIdx-inL;
        
        // now recurse over the next set of inorder & postorder subarrays
        node.left = BuildTree(inorder, inL, inIdx-1, postorder, poL, poIdx-1);
        node.right = BuildTree(inorder, inIdx+1, inR, postorder, poIdx, poR-1);
        
        return node;
    }
}

// Accepted
public class Solution1 {
    int inIdx, poIdx;
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        inIdx = inorder.Length-1;
        poIdx = postorder.Length-1;
        return BuildTree(inorder, postorder, null);
    }
    
    private TreeNode BuildTree(int[] inorder, int[] postorder, TreeNode end) {
        if(poIdx < 0) return null;                      // no more nodes to process
        var node = new TreeNode(postorder[poIdx--]);    // create a node for current index
        // if right subtree exists, build it
        if(inorder[inIdx] != node.val)
            node.right = BuildTree(inorder, postorder, node);
        inIdx--;
        
        // if left subtree exists, build it
        if(end == null || inorder[inIdx] != end.val)
            node.left = BuildTree(inorder, postorder, end);
        
        return node;
    }
}