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

class FindElements {
    TreeNode root;
    Set<Integer> nums;

    public FindElements(TreeNode root) {
        this.root = root;
        nums = new HashSet<>();
        dfs(root, 0);
    }
    
    public boolean find(int target) {
        return nums.contains(target);
    }

    public void dfs(TreeNode node, int curr) {
        if(node == null) return;
        nums.add(curr);

        dfs(node.left, 2 * curr + 1);
        dfs(node.right, 2 * curr + 2);
    }
}

 // Accepted - on demand DFS
class FindElementsDemand {
    TreeNode root;

    public FindElementsDemand(TreeNode root) {
        this.root = root;
    }
    
    public boolean find(int target) {
        return find(root, 0, target);
    }

    public boolean find(TreeNode node, int curr, int target) {
        if(node == null || curr > target) return false;
        if(curr == target) return true;

        var found = false;
        found |= find(node.left, 2 * curr + 1, target);
        found |= find(node.right, 2 * curr + 2, target);
        
        return found;
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * boolean param_1 = obj.find(target);
 */