public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var levels = new List<IList<int>>();
        if(root == null) return levels;
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count > 0){
            var count = q.Count;
            levels.Add(q.Select(node => node.val).ToList());
            for(var i=0; i<count; i++){
                var node = q.Dequeue();
                if(node.left != null)  q.Enqueue(node.left);
                if(node.right != null)  q.Enqueue(node.right);
            }
        }
        
        return levels;
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