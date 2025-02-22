class Solution {
    int idx = 0;

    public TreeNode recoverFromPreorder(String traversal) {
        return recoverFromPreorder(traversal, -1);
    }

    private TreeNode recoverFromPreorder(String traversal, int parentDepth) {
        if(idx == traversal.length()) return null;

        var dn = getDepthNum(traversal, idx);
        int depth = dn[0], num = dn[1];
        if(parentDepth >= depth) return null;

        idx = dn[2];
        var node = new TreeNode(num);
        node.left = recoverFromPreorder(traversal, depth);
        node.right = recoverFromPreorder(traversal, depth);
        return node;
    }

    private int[] getDepthNum(String traversal, int idx){
        var depth = 0;
        while(idx + depth < traversal.length() && traversal.charAt(idx + depth) == '-')
            depth++;

        int numStart = idx + depth, numEnd = numStart;
        while(numEnd < traversal.length() && traversal.charAt(numEnd) != '-')
            numEnd++;

        var num = Integer.parseInt(traversal.substring(numStart, numEnd));
        return new int[] { depth, num, numEnd };
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */