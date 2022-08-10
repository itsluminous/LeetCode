public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums.Length == 0) return null;
        return SortedArrayToBST(nums, 0, nums.Length - 1);
    }
    
    private TreeNode SortedArrayToBST(int[] nums, int low, int high) {
        if(low > high) return null;
        var mid = (low + high)/2;
        var node = new TreeNode(nums[mid]);
        node.left = SortedArrayToBST(nums, low, mid-1);
        node.right = SortedArrayToBST(nums, mid+1, high);
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