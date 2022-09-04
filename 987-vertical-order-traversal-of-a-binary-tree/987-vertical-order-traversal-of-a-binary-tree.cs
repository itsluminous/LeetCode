public class Solution {
    Dictionary<int, List<Node>> dict = new Dictionary<int, List<Node>>(); // mapping of col with nodes in that col
    SortedSet<int> cols = new SortedSet<int>();                           // collection of all cols in graph
    
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        dfs(root, 0, 0);
        
        var result = new List<IList<int>>();
        foreach(var c in cols){
            var list = dict[c].OrderBy(n => n.row).ThenBy(n => n.val).Select(n => n.val).ToList();
            result.Add(list);
        }
        return result;
    }
    
    private void dfs(TreeNode node, int r, int c){
        if(node == null) return;
        
        cols.Add(c);
        if(!dict.ContainsKey(c)) dict[c] = new List<Node>();
        dict[c].Add(new Node(node.val, r));
        
        dfs(node.left, r+1, c-1);
        dfs(node.right, r+1, c+1);
    }
}

public class Node{
    public int val;
    public int row;
    
    public Node(int v, int r){
        val = v;
        row = r;
    }
}


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