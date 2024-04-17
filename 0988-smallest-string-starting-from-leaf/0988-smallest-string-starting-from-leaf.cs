public class Solution {
    public string SmallestFromLeaf(TreeNode root, string path = "") {
        path = (char)('a' + root.val) + path;
        if(root.left == null && root.right == null) return path;
        if(root.left == null) return SmallestFromLeaf(root.right, path);
        if(root.right == null) return SmallestFromLeaf(root.left, path);

        var left = SmallestFromLeaf(root.left, path);
        var right = SmallestFromLeaf(root.right, path);
        return SmallerString(left, right);
    }

    private string SmallerString(string str1, string str2){
        if(str1 == null) return str2;
        if(str2 == null) return str1;

        // return new[]{str1, str2}.OrderBy(s => s).ThenBy(s => s.Length).First();
        var i = 0;
        for(; i<str1.Length && i<str2.Length; i++){
            if(str1[i] < str2[i]) return str1;
            if(str1[i] > str2[i]) return str2;
        }

        if(i == str1.Length) return str1;
        return str2;
    }
}