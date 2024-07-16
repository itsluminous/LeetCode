class Solution {
    StringBuilder startPath = new StringBuilder(), destPath = new StringBuilder();
    int found = 0; // how many nodes are discovered in the tree

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

    private int findCommonPathLength(StringBuilder startPath, StringBuilder destPath){
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
        if(node == null) return;
        if(node.val == startValue){
            startPath.append(path);
            found++;
        }
        if(node.val == destValue){
            destPath.append(path);
            found++;
        }

        if(node.left != null && found != 2){
            path.append("L");
            dfs(node.left, startValue, destValue, path);
            path.deleteCharAt(path.length() - 1);
        }

        if(node.right != null && found != 2){
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