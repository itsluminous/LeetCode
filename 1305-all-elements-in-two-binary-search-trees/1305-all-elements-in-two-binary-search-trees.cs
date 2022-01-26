public class Solution {
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        List<int> inOrder1 = new List<int>(), inOrder2 = new List<int>();
        Traverse(root1, inOrder1);
        Traverse(root2, inOrder2);
        
        var result = new List<int>();
        int i=0, j=0;
        while(i<inOrder1.Count && j<inOrder2.Count){
            if(inOrder1[i] < inOrder2[j])
                result.Add(inOrder1[i++]);
            else
                result.Add(inOrder2[j++]);
        }
        
        while(i<inOrder1.Count)
            result.Add(inOrder1[i++]);
        
        while(j<inOrder2.Count)
            result.Add(inOrder2[j++]);
        
        return result;
    }
    
    private void Traverse(TreeNode node, List<int> lst){
        if(node == null) return;
        Traverse(node.left, lst);
        lst.Add(node.val);
        Traverse(node.right, lst);
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