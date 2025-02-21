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

 public class FindElements {
    TreeNode root;
    HashSet<int> nums;

    public FindElements(TreeNode root) {
        this.root = root;
        nums = new();
        DFS(root, 0);
    }
    
    public bool Find(int target) {
        return nums.Contains(target);
    }

    public void DFS(TreeNode node, int curr) {
        if(node == null) return;
        nums.Add(curr);

        DFS(node.left, 2 * curr + 1);
        DFS(node.right, 2 * curr + 2);
    }
}

 // Accepted - on demand DFS
 public class FindElementsDemand {
    TreeNode root;

    public FindElementsDemand(TreeNode root) {
        this.root = root;
    }
    
    public bool Find(int target) {
        return Find(root, 0, target);
    }

    public bool Find(TreeNode node, int curr, int target) {
        if(node == null || curr > target) return false;
        if(curr == target) return true;

        var found = false;
        found |= Find(node.left, 2 * curr + 1, target);
        found |= Find(node.right, 2 * curr + 2, target);
        
        return found;
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */