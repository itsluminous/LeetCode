// BFS from right to left
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        var ans = new List<int>();
        if(root == null) return ans;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            ans.Add(queue.Peek().val);
            for(var i=queue.Count; i>0; i--){
                var curr = queue.Dequeue();
                if(curr.right != null) queue.Enqueue(curr.right);
                if(curr.left != null) queue.Enqueue(curr.left);
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