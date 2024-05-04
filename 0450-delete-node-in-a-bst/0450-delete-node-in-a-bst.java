public class Solution {
    public TreeNode deleteNode(TreeNode root, int key) {
        if(root == null) return root;

        // first try to reach the correct node, which has to be removed
        if(key < root.val) root.left = deleteNode(root.left, key);
        if(key > root.val) root.right = deleteNode(root.right, key);

        // once we found the right node, then delete it
        if(key == root.val){
            if(root.left == null && root.right == null) return null;    // leaf node, so just delete it
            if(root.left == null || root.right == null)                 // if there is just one child, then it will replace the node to be deleted
                return root.left == null ? root.right: root.left;
            
            // if node has both children, then find biggest node on left side, and use that as replacement
            var temp = root.left;
            while(temp.right != null) temp = temp.right;
            root.val = temp.val;
            root.left = deleteNode(root.left, temp.val);
        }

        return root;
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */