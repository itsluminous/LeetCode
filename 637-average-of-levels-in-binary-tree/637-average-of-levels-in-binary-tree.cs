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
public class Solution {
    public IList<double> AverageOfLevels(TreeNode root) {
        var result = new List<double>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count > 0){
            double len = q.Count;
            double sum = 0;
            for(var i=0; i<len; i++){
                var node = q.Dequeue();
                sum += node.val;
                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
            }
            result.Add(Math.Round(sum/len, 5));
        }
        return result;
    }
}