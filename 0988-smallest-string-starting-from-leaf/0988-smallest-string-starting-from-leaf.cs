public class Solution {
    public string SmallestFromLeaf(TreeNode root) {
        return SmallestFromLeaf(root, new List<int>());
    }

    public string SmallestFromLeaf(TreeNode root, List<int> lineage) {
        lineage.Insert(0, root.val);

        var ans = string.Empty;
        if(root.left == null && root.right == null)
            ans = ListToString(lineage);
        else if(root.left == null) 
            ans = SmallestFromLeaf(root.right, lineage);
        else if(root.right == null) 
            ans = SmallestFromLeaf(root.left, lineage);
        else{
            var left = SmallestFromLeaf(root.left, lineage);
            var right = SmallestFromLeaf(root.right, lineage);
            ans = SmallerString(left, right);
        }
        
        lineage.RemoveAt(0);
        return ans;
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

    private string ListToString(List<int> nums){
        var sb = new StringBuilder();
        foreach(var num in nums){
            var ch = (char)(97 + num);
            sb.Append(ch);
        }
           
        return sb.ToString();
    }
}