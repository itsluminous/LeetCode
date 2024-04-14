// using recursion
public class Solution {
    public int SumOfLeftLeaves(TreeNode root) {
        if(root == null) return 0;
        var sum = 0;
        if(root.left != null && root.left.left == null && root.left.right == null)
            sum += root.left.val;
        return sum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
    }
}

// using iteration
public class SolutionIter {
    public int SumOfLeftLeaves(TreeNode root) {
        var ans = 0;

        var queue = new Queue<TreeNode>();
        var lqueue = new Queue<bool>();
        queue.Enqueue(root);
        lqueue.Enqueue(false);

        while(queue.Count > 0){
            var n = queue.Count;
            for(var i=0; i<n; i++){
                var node = queue.Dequeue();
                var isleft = lqueue.Dequeue();

                if(node.left == null && node.right == null){
                    if(isleft) ans += node.val;
                    continue;
                }

                if(node.left != null){
                    queue.Enqueue(node.left);
                    lqueue.Enqueue(true);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                    lqueue.Enqueue(false);
                }
            }
        }

        return ans;
    }
}