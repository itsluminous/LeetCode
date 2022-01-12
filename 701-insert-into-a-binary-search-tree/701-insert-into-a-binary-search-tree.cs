public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        // create new node
        var newNode = new TreeNode(val);
        // if tree is empty then this is the root node
        if(root == null) return newNode;
        
        // traverse the tree to find right place for new node
        TreeNode prev = null;
        var curr = root;
        while(curr != null){
            prev = curr;
            if(curr.val < val)
                curr = curr.right;
            else 
                curr = curr.left;
        }
        
        // add new node to the appropriate place
        if(prev.val > val)
            prev.left = newNode;
        else
            prev.right = newNode;
        
        return root;
    }
}

// Accepted - without using prev pointer
public class Solution1 {
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        // create new node
        var newNode = new TreeNode(val);
        // if tree is empty then this is the root node
        if(root == null) return newNode;
        
        var node = root;
        while(node != null){
            // if new node has to go to left subtree
            if(node.val > val){
                if(node.left == null){
                    node.left = newNode;
                    break;
                }
                else
                    node = node.left;
            }
            // if new node has to go to right subtree
            else{
                if(node.right == null){
                    node.right = newNode;
                    break;
                }
                else
                    node = node.right;
            }
        }
        
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