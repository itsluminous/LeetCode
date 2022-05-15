// BFS
public class Solution {
    public int DeepestLeavesSum(TreeNode root) {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        var sum = 0;
        while(q.Count > 0){
            var currSum = 0;
            var len = q.Count;
            for(var i=0; i<len; i++){
                var node = q.Dequeue();
                currSum += node.val;
                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
            }
            sum = currSum;
        }
        
        return sum;
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