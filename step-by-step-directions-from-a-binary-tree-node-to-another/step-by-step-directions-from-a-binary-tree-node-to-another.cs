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
    string startPath = null;
    string destPath = null;
    public string GetDirections(TreeNode root, int startValue, int destValue) {        
        // find path of start and dest in tree
        FindPath(root, startValue, destValue, new StringBuilder());
        
        // find common parent
        var common = 0;
        for(;common<startPath.Length && common<destPath.Length; common++){
            if(startPath[common] != destPath[common]) break;
        }
        
        // form result
        var sb = new StringBuilder();
        for(var i=common; i<startPath.Length; i++) sb.Append("U");
        for(var i=common; i<destPath.Length; i++) sb.Append(destPath[i]);
        
        return sb.ToString();
    }
    
    private bool FindPath(TreeNode root, int start, int dest, StringBuilder path){
        if(root == null) return false;
        
        if(root.val == start) startPath = path.ToString();
        if(root.val == dest) destPath = path.ToString();
        
        // if we found both start and destination nodes. stop searching
        if(startPath != null && destPath != null) return true;
        
        // search in left subtree
        path.Append("L");
        if(FindPath(root.left, start, dest, path)) return true;
        path.Length--;
        
        // search in right subtree
        path.Append("R");
        if(FindPath(root.right, start, dest, path)) return true;
        path.Length--;
        
        return false;
    }
}