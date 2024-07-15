class Solution {
    public int minDepth(TreeNode root) {
        if(root == null) return 0;

        Queue<TreeNode> q = new LinkedList<>();
        q.offer(root);
        var depth = 0;

        while(!q.isEmpty()){
            depth++;
            for(var i=q.size(); i>0; i--){
                var node = q.poll();
                if(node.left == null && node.right == null) return depth;   // leaf node
                if(node.left != null) q.offer(node.left);
                if(node.right != null) q.offer(node.right);
            }
        }

        return depth;
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