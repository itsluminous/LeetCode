public class Solution {
    public int FindBottomLeftValue(TreeNode root) {
        var leftMost = root;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count > 0){
            leftMost = q.Peek();
            var count = q.Count;
            for(var i=0; i<count; i++){
                var node = q.Dequeue();
                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
            }
        }

        return leftMost.val;
    }
}