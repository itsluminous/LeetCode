public class Solution {
    public bool IsEvenOddTree(TreeNode root) {
        const int MAX = 1_000_002;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var remainder = 1;
        while(q.Count > 0){
            var count = q.Count;
            var prev = remainder == 1 ? 0 : MAX;
            for(var i=0; i<count; i++){
                var curr = q.Dequeue();
                if( curr.val%2 != remainder ) return false;
                if( remainder == 1 && curr.val <= prev ) return false;
                if( remainder == 0 && curr.val >= prev ) return false;

                if(curr.left != null) q.Enqueue(curr.left);
                if(curr.right != null) q.Enqueue(curr.right);
                prev = curr.val;
            }
            remainder = (remainder+1)%2;
        }
        return true;
    }
}