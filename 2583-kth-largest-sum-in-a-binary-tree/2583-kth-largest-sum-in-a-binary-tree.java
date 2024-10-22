class Solution {
    public long kthLargestLevelSum(TreeNode root, int k) {
        var maxHeap = new PriorityQueue<Long>((n1, n2) -> n2.compareTo(n1));
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);

        while(!queue.isEmpty()){
            long curr = 0;
            for(var count=queue.size(); count>0; count--){
                var node = queue.poll();
                curr += node.val;
                if(node.left != null) queue.offer(node.left);
                if(node.right != null) queue.offer(node.right);
            }
            maxHeap.offer(curr);
        }

        while(k-- > 1 && !maxHeap.isEmpty()) maxHeap.poll();
        if(maxHeap.isEmpty()) return -1;
        return maxHeap.poll();
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