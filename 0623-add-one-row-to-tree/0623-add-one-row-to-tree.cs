public class Solution {
    public TreeNode AddOneRow(TreeNode root, int val, int depth) {
        var newRoot = new TreeNode(0, root);
        var currDepth = 0;
        var queue = new Queue<TreeNode>();

        queue.Enqueue(newRoot);
        while(queue.Count > 0){
            currDepth++;
            var count = queue.Count;
            
            for(var i=0; i<count; i++){
                var node = queue.Dequeue();
                if(depth == currDepth){
                    node.left = new TreeNode(val, node.left, null);
                    node.right = new TreeNode(val, null, node.right);
                }
                else{
                    if(node.left != null) queue.Enqueue(node.left);
                    if(node.right != null) queue.Enqueue(node.right);
                }
            }
        }

        return newRoot.left;
    }
}