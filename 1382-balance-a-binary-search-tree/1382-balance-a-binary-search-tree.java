// storing node during inorder, to save time taken by node creation
class Solution {
    List<TreeNode> sortedList = new ArrayList<>();

    public TreeNode balanceBST(TreeNode root) {
        inorder(root);
        return buildBST(0, sortedList.size()-1);
    }

    private TreeNode buildBST(int start, int end){
        if(start > end) return null;
        var mid = start + (end - start)/2;
        var node = sortedList.get(mid);
        node.left = buildBST(start, mid-1);
        node.right = buildBST(mid+1, end);
        return node;
    }

    private void inorder(TreeNode root){
        if(root == null) return;
        inorder(root.left);
        sortedList.add(root);
        inorder(root.right);
    }
}

// Accepted - storing values during inorder
class SolutionVal {
    public TreeNode balanceBST(TreeNode root) {
        var sortedList = new ArrayList<Integer>();
        inorder(root, sortedList);
        return buildBST(sortedList, 0, sortedList.size()-1);
    }

    private TreeNode buildBST(List<Integer> list, int start, int end){
        var mid = start + (end - start)/2;
        var node = new TreeNode(list.get(mid));
        if(start < mid)
            node.left = buildBST(list, start, mid-1);
        if(end > mid)
            node.right = buildBST(list, mid+1, end);
        return node;
    }

    private void inorder(TreeNode root, List<Integer> list){
        if(root == null) return;
        inorder(root.left, list);
        list.add(root.val);
        inorder(root.right, list);
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