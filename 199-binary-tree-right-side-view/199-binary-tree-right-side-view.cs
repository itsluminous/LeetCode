public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        if(root == null) return result;
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var lastNode = root;
        
        while(q.Count > 0){
            var count = q.Count;
            for(var i=0; i<count; i++){
                var node = q.Dequeue();
                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
                lastNode = node;
            }
            if(lastNode != null) result.Add(lastNode.val);
        }
        
        return result;
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