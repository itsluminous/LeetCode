public class Solution {
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;

        Queue<TreeNode> q = new();
        q.Enqueue(root);
        var depth = 0;

        while(q.Count > 0){
            depth++;
            for(var i=q.Count; i>0; i--){
                var node = q.Dequeue();
                if(node.left == null && node.right == null) return depth;   // leaf node
                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
            }
        }

        return depth;
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