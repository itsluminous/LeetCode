public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var left = PathOfNode(root, p, "O");
        var right = PathOfNode(root, q, "O");
        
        // find common part of path
        var sb = new StringBuilder();
        for(int l=0, r=0; l<left.Length && r<right.Length; l++, r++){
            if(left[l] != right[r]) break;
            sb.Append(left[l]);
        }
        
        // find node at the end of common path
        foreach(var ch in sb.ToString()){
            if(ch == 'L') root = root.left;
            else if(ch == 'R') root = root.right;
        }
        
        return root;
            
    }
    
    // Get path from root to destination node
    public string PathOfNode(TreeNode node, TreeNode p, string path) {
        if(node == null) return string.Empty;
        if(node.val == p.val) return path;
        var leftpath = PathOfNode(node.left, p, path + "L");
        if(leftpath != string.Empty) return leftpath;
        return PathOfNode(node.right, p, path + "R");
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */