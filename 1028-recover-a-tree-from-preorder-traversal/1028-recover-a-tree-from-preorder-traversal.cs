public class Solution {
    int idx = 0;

    public TreeNode RecoverFromPreorder(string traversal, int parentDepth = -1) {
        if(idx == traversal.Length) return null;

        var dn = GetDepthNum(traversal, idx);
        int depth = dn[0], num = dn[1];
        if(parentDepth >= depth) return null;

        idx = dn[2];
        var node = new TreeNode(num);
        node.left = RecoverFromPreorder(traversal, depth);
        node.right = RecoverFromPreorder(traversal, depth);
        return node;
    }

    private int[] GetDepthNum(string traversal, int idx){
        var depth = 0;
        while(idx + depth < traversal.Length && traversal[idx + depth] == '-')
            depth++;

        int numStart = idx + depth, numEnd = numStart;
        while(numEnd < traversal.Length && traversal[numEnd] != '-')
            numEnd++;

        var num = int.Parse(traversal.Substring(numStart, numEnd - numStart));
        return new int[] { depth, num, numEnd };
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