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

// DFS
public class Solution {
    int maxLen = 0;
    
    public int WidthOfBinaryTree(TreeNode root) {
        if(root == null) return 0;
        var levelStart = new List<int>();
        WidthOfBinaryTree(root, 0, 1, levelStart);
        return maxLen;
    }
    
    private void WidthOfBinaryTree(TreeNode root, int level, int index, List<int> levelList){
        if(root == null) return;
        if(level == levelList.Count)
            levelList.Add(index);
        maxLen = Math.Max(maxLen, index + 1 - levelList[level]);
        WidthOfBinaryTree(root.left, level+1, index * 2, levelList);
        WidthOfBinaryTree(root.right, level+1, index * 2 + 1, levelList);
    }
}

// Failed - BFS
public class Solution1 {
    public int WidthOfBinaryTree(TreeNode root) {
        var maxLen = 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count > 0){
            var len = q.Count;
            maxLen = Math.Max(maxLen, q.Count);
            for(var i=0; i<len; i++){
                var node = q.Dequeue();
                if(node == null || (node.left == null && node.right == null)) continue;
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
        }
        
        return maxLen;
    }
}