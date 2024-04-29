// BFS from right to left
public class Solution {
    public List<Integer> rightSideView(TreeNode root) {
        var ans = new ArrayList<Integer>();
        if(root == null) return ans;

        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        while(queue.size() > 0){
            ans.add(queue.peek().val);
            for(var i=queue.size(); i>0; i--){
                var curr = queue.poll();
                if(curr.right != null) queue.add(curr.right);
                if(curr.left != null) queue.add(curr.left);
            }
        }
        return ans;
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