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


// SOLUTIONS FROM OTHER PEOPLE BELOW :

public class Solution1 {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        while ((root.val - p.val) * (root.val - q.val) > 0)
            root = p.val < root.val ? root.left : root.right;
        return root;
    }
}


public class Solution2 {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(p.val > q.val) return Helper(root, q, p);
        return Helper(root, p, q);
    }
    
    private TreeNode Helper(TreeNode root, TreeNode p, TreeNode q){
        if(root == null) return null;
        if(root.val >= p.val && root.val <= q.val) return root;
        
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if(left == null) return right;
        if(right == null) return left;
        if(left.val < right.val) return left;
        return right;
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