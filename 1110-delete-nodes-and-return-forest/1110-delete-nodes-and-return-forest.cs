public class Solution {
    List<TreeNode> roots = new();

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var delete = new bool[1001];
        foreach(var num in to_delete)
            delete[num] = true;
        
        DFS(root, null, delete);
        return roots;
    }

    private void DFS(TreeNode node, TreeNode prev, bool[] to_delete) {
        if(node == null) return;

        // check if we found root node
        if(!to_delete[node.val]){
            if(prev == null) roots.Add(node);
            prev = node;
        }
        else prev = null;

        // save the left & right child in variable
        var childLeft = node.left;
        var childRight = node.right;

        // set left/right child as null if they are to be deleted
        if(childLeft != null && to_delete[childLeft.val])
            node.left = null;
        if(childRight != null && to_delete[childRight.val])
            node.right = null;

        // check further if more nodes are to be deleted
        DFS(childLeft, prev, to_delete);
        DFS(childRight, prev, to_delete);
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