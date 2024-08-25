public class Solution {
    IList<string> paths = new List<string>();

    public IList<string> BinaryTreePaths(TreeNode root) {
        DFS(root, new StringBuilder());
        return paths;
    }

    private void DFS(TreeNode root, StringBuilder path){
        if(root == null) return;
        path.Append(root.val);

        if(root.left == null && root.right == null)
            paths.Add(path.ToString());
        else {
            path.Append("->");
            DFS(root.left, path);
            DFS(root.right, path);
            path.Length -= 2;
        }
        path.Length -= root.val.ToString().Length;
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