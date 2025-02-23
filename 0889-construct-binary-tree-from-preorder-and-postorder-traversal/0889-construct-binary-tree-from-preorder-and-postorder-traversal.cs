public class Solution {
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        var n = preorder.Length;
        return Construct(preorder, postorder, 0, n-1, 0, n-1);
    }

    private TreeNode Construct(int[] preorder, int[] postorder, int preStart, int preEnd, int poStart, int poEnd) {
        var node = new TreeNode(preorder[preStart]);

        // has no children
        if(preStart == preEnd) return node;

        // has two children
        if(preorder[preStart+1] != postorder[poEnd-1]){
            var preMid = preStart+1;
            while(preorder[preMid] != postorder[poEnd-1]) preMid++;

            var poMid = poEnd-1;
            while(postorder[poMid] != preorder[preStart+1]) poMid--;

            node.left = Construct(preorder, postorder, preStart+1, preMid-1, poStart, poMid);
            node.right = Construct(preorder, postorder, preMid, preEnd, poMid+1, poEnd-1);
        }
        // has one children only, let's make it left
        else
            node.left = Construct(preorder, postorder, preStart+1, preEnd, poStart, poEnd-1);

        return node;
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