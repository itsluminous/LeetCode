class Solution {
    String startPath, destPath;

    public String getDirections(TreeNode root, int startValue, int destValue) {
        dfs(root, startValue, destValue, new StringBuilder());
        var commonLen = findCommonPathLength(startPath, destPath);

        var ans = new StringBuilder();
        for(var i=commonLen; i<startPath.length(); i++) 
            ans.append("U");
        for(var i=commonLen; i<destPath.length(); i++)
            ans.append(destPath.charAt(i));
        
        return ans.toString();
    }

    private int findCommonPathLength(String startPath, String destPath){
        int startLen = startPath.length(), destLen = destPath.length();
        var minLen = Math.min(startLen, destLen);
        
        var idx = 0;
        for(; idx < minLen; idx++){
            char startChar = startPath.charAt(idx), destChar = destPath.charAt(idx);
            if(startChar != destChar) return idx;
        }
        
        return idx;
    }

    private void dfs(TreeNode node, int startValue, int destValue, StringBuilder path){
        if(node.val == startValue) startPath = path.toString();
        else if(node.val == destValue) destPath = path.toString();

        if(node.left != null && (startPath == null || destPath == null)){
            path.append("L");
            dfs(node.left, startValue, destValue, path);
            path.deleteCharAt(path.length() - 1);
        }

        if(node.right != null && (startPath == null || destPath == null)){
            path.append("R");
            dfs(node.right, startValue, destValue, path);
            path.deleteCharAt(path.length() - 1);
        }
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