public class Solution {
    public int maxLevelSum(TreeNode root) {
        int ansLevel = 1, ansSum = Integer.MIN_VALUE;
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);

        for(var lvl=1; queue.size()>0; lvl++){
            var currSum = 0;
            for(var i=queue.size(); i>0; i--){
                var node = queue.poll();
                currSum += node.val;

                if(node.left != null) queue.add(node.left);
                if(node.right != null) queue.add(node.right);
            }
            if(currSum > ansSum){
                ansLevel = lvl;
                ansSum = currSum;
            }
        }

        return ansLevel;
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