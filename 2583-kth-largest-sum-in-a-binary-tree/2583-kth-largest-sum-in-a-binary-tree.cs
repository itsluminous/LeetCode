public class Solution {
    public long KthLargestLevelSum(TreeNode root, int k) {
        var maxHeap = new PriorityQueue<long, long>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            long curr = 0;
            for(var count=queue.Count; count>0; count--){
                var node = queue.Dequeue();
                curr += node.val;
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            maxHeap.Enqueue(curr, -curr);
        }

        while(k-- > 1 && maxHeap.Count > 0) maxHeap.Dequeue();
        if(maxHeap.Count == 0) return -1;
        return maxHeap.Dequeue();
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