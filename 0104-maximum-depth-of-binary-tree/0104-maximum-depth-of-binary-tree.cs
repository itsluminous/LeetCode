public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        var ans = 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        for(; queue.Count > 0; ans++){
            for(var i=queue.Count; i>0; i--){
                var node = queue.Dequeue();
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
        }

        return ans;
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