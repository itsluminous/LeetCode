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
    public TreeNode DeleteNode(TreeNode root, int key) {
        TreeNode parent = null, curr = root;
        
        // find the node
        while(curr != null){
            if(curr.val == key) break;
            
            parent = curr;
            if(curr.val < key) curr = curr.right;
            else curr = curr.left;
        }
        
        // if node not found
        if(curr == null) return root;    
        
        if(curr.right != null){
            var left = curr.left;
            curr = curr.right;
            var leftmost = GetLeftMost(curr);
            leftmost.left = left;
            
            // set parent link
            if(parent != null){
                if(parent.left != null && parent.left.val == key) parent.left = curr;
                else parent.right = curr;
            }
        }
        else{
            curr = curr.left;
            
            // set parent link
            if(parent != null){
                if(parent.left != null && parent.left.val == key) parent.left = curr;
                else parent.right = curr;
            }
        }
        
        // if we removed the root node
        if(parent == null) return curr;
        
        return root;
    }
    
    private TreeNode GetLeftMost(TreeNode root){
        var curr = root;
        while(curr.left != null) curr = curr.left;
        return curr;
    }
}