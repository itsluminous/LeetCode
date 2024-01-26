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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        var leafValue1 = GetLeafValue(root1);
        var leafValue2 = GetLeafValue(root2);

        if(leafValue1.Count != leafValue2.Count) return false;
        for(var i=0; i<leafValue1.Count; i++)
            if(leafValue1[i] != leafValue2[i]) return false;
        return true;
    }

    private List<int> GetLeafValue(TreeNode node){
        if(node == null) return new List<int>();
        if(node.left == null && node.right == null) return new List<int>{node.val};
        
        var lst = new List<int>();
        if(node.left != null) lst.AddRange(GetLeafValue(node.left));
        if(node.right != null) lst.AddRange(GetLeafValue(node.right));
        return lst;
    }
}