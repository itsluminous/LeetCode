public class Solution {
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        var nodes1 = GetLeafNodes(root1);
        var nodes2 = GetLeafNodes(root2);
        return nodes1.SequenceEqual(nodes2);
    }

    public List<int> GetLeafNodes(TreeNode root) {
        if(root == null) return new List<int>();
        if(root.left == null && root.right == null) return new List<int>{root.val};

        var lst = new List<int>();
        lst.AddRange(GetLeafNodes(root.left));
        lst.AddRange(GetLeafNodes(root.right));

        return lst;
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