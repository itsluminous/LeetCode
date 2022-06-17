public class Solution {
    int cameras = 0;
    public enum Status { HAS_CAMERA, COVERED, NEEDS_COVER};
    
    public int MinCameraCover(TreeNode root) {
        var status = Cover(root);
        if(status == Status.NEEDS_COVER) return cameras+1;
        return cameras;
    }
    
    private Status Cover(TreeNode root){
        // if there is no node, then it's covered
        if(root == null)
            return Status.COVERED;
        
        var left = Cover(root.left);
        var right = Cover(root.right);
        
        // if left or right child needs cover, then place camera at current node
        if(left == Status.NEEDS_COVER || right == Status.NEEDS_COVER){
            cameras++;
            return Status.HAS_CAMERA;
        }
        
        // if left or right has camera, then current node is already covered
        if(left == Status.HAS_CAMERA || right == Status.HAS_CAMERA){
            return Status.COVERED;
        }
        
        // else current node needs to be covered by parent
        return Status.NEEDS_COVER;
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