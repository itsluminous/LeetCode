public class Solution {
    public int MaxLevelSum(TreeNode root) {
        int ansLevel = 1, ansSum = int.MinValue;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for(var lvl=1; queue.Count>0; lvl++){
            var currSum = 0;
            for(var i=queue.Count; i>0; i--){
                var node = queue.Dequeue();
                currSum += node.val;

                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            if(currSum > ansSum)
                (ansLevel, ansSum) = (lvl, currSum);
        }

        return ansLevel;
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