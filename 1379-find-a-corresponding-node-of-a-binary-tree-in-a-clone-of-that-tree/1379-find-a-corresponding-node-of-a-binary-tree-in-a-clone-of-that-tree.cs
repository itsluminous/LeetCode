// BFS
public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        var q = new Queue<TreeNode>();
        q.Enqueue(cloned);
        while(q.Count > 0){
            var node = q.Dequeue();
            if(node.val == target.val) return node;
            if(node.left != null) q.Enqueue(node.left);
            if(node.right != null) q.Enqueue(node.right);
        }
        return new TreeNode();
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */