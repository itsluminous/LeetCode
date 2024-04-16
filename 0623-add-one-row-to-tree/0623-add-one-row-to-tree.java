public class Solution {
    public TreeNode addOneRow(TreeNode root, int val, int depth) {
        var newRoot = new TreeNode(0, root, null);
        var currDepth = 0;
        Queue<TreeNode> queue = new LinkedList<>();

        queue.add(newRoot);
        while(queue.size() > 0){
            currDepth++;
            var count = queue.size();
            
            for(var i=0; i<count; i++){
                var node = queue.poll();
                if(depth == currDepth){
                    node.left = new TreeNode(val, node.left, null);
                    node.right = new TreeNode(val, null, node.right);
                }
                else{
                    if(node.left != null) queue.add(node.left);
                    if(node.right != null) queue.add(node.right);
                }
            }
        }

        return newRoot.left;
    }
}