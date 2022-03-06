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
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var root = new TreeNode();
        var dict = new Dictionary<int, TreeNode>();
        var rootCandidates = new HashSet<TreeNode>();
        var removed = new HashSet<TreeNode>();
        
        foreach(var desc in descriptions){
            var (p, c, isLeft) = (desc[0], desc[1], desc[2]);
            
            var par = new TreeNode(p);
            var ch = new TreeNode(c);
            
            // parent node
            if(dict.ContainsKey(p)) par = dict[p];
            else dict[p] = par;
            
            // child node
            if(dict.ContainsKey(c)) ch = dict[c];
            else dict[c] = ch;
            
            // add child node to parent
            if(isLeft == 1) par.left = ch;
            else par.right = ch;
            
            // add current parent as root node candidate
            if(!removed.Contains(par)) rootCandidates.Add(par);
            
            // remove current child from root nodes candidate list
            rootCandidates.Remove(ch);
            removed.Add(ch);
        }
        
        return rootCandidates.Single();
    }
}