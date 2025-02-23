class Solution {
    public TreeNode constructFromPrePost(int[] preorder, int[] postorder) {
        var n = preorder.length;
        return construct(preorder, postorder, 0, n-1, 0, n-1);
    }

    private TreeNode construct(int[] preorder, int[] postorder, int preStart, int preEnd, int poStart, int poEnd) {
        var node = new TreeNode(preorder[preStart]);

        // has no children
        if(preStart == preEnd) return node;

        // has two children
        if(preorder[preStart+1] != postorder[poEnd-1]){
            var preMid = preStart+1;
            while(preorder[preMid] != postorder[poEnd-1]) preMid++;

            var poMid = poEnd-1;
            while(postorder[poMid] != preorder[preStart+1]) poMid--;

            node.left = construct(preorder, postorder, preStart+1, preMid-1, poStart, poMid);
            node.right = construct(preorder, postorder, preMid, preEnd, poMid+1, poEnd-1);
        }
        // has one children only, let's make it left
        else
            node.left = construct(preorder, postorder, preStart+1, preEnd, poStart, poEnd-1);

        return node;
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