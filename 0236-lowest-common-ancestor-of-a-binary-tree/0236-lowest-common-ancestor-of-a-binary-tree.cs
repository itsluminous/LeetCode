// simple straightforward
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null || root == p || root == q) return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        
        if(left != null && right != null) return root;  // p & q are on different subtree from current node
        return left != null ? left : right;             // both are on same subtree
    }
}

// Accepted - no space usage, we will keep traversing the tree even if we found both nodes
public class SolutionNoSpace {
    TreeNode ancestor;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        LCA(root, p, q);
        return ancestor;
    }

    public bool LCA(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null) return false;
        var match = (root == p || root == q) ? 1 : 0;
        var left = LCA(root.left, p, q) ? 1 : 0;
        var right = LCA(root.right, p, q) ? 1 : 0;
        
        // if any two of these 3 variables are set, then we found ancestor
        if(match + left + right >= 2) ancestor = root;

        // return true if any of these 3 variables was set
        return (match|left|right) == 1;
    }
}

// Accepted - store the path to each node in a string builder and use it to find common
public class SolutionStringBuilder {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // find path from root to the node p & q
        StringBuilder psb = new StringBuilder(), qsb = new StringBuilder();
        FindPath(root, p, psb);
        FindPath(root, q, qsb);
        string ppath = psb.ToString(), qpath = qsb.ToString();

        // find common path
        var common = new StringBuilder();
        var len = Math.Min(ppath.Length, qpath.Length);
        for(var i=0; i<len && ppath[i] == qpath[i]; i++)
            common.Append(ppath[i]);
        var commonstr = common.ToString();
        
        // traverse the common path
        foreach(var dir in commonstr)
            if(dir == 'l') root = root.left;
            else root = root.right;
        
        return root;
    }

    private bool FindPath(TreeNode root, TreeNode target, StringBuilder path){
        if(root == null) return false;
        if(root.val == target.val) return true;

        // look up in left subtree
        path.Append('l');
        var found = FindPath(root.left, target, path);
        if(found) return found;
        path.Length--;
        
        // look up in right subtree
        path.Append('r');
        found = FindPath(root.right, target, path);
        if(found) return found;
        path.Length--;
        
        return false;
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