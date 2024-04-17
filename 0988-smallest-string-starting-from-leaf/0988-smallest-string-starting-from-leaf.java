class Solution {
    public String smallestFromLeaf(TreeNode root) {
        return smallestFromLeaf(root, "");
    }

    public String smallestFromLeaf(TreeNode root, String path) {
        path = (char)('a' + root.val) + path;
        if(root.left == null && root.right == null) return path;
        if(root.left == null) return smallestFromLeaf(root.right, path);
        if(root.right == null) return smallestFromLeaf(root.left, path);

        var left = smallestFromLeaf(root.left, path);
        var right = smallestFromLeaf(root.right, path);
        return left.compareTo(right) < 0 ? left : right;
    }
}