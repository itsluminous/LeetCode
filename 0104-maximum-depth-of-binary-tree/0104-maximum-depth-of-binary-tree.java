public class Solution {
    public int maxDepth(TreeNode root) {
        if(root == null) return 0;
        var ans = 0;

        var queue = new LinkedList<TreeNode>();
        queue.add(root);
        for(; !queue.isEmpty(); ans++){
            for(var i=queue.size(); i>0; i--){
                var node = queue.poll();
                if(node.left != null) queue.add(node.left);
                if(node.right != null) queue.add(node.right);
            }
        }

        return ans;
    }
}