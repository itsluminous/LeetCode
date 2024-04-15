public class Solution {
    public int SumNumbers(TreeNode root, int num = 0) {
        if(root == null) return 0;

        num = num*10 + root.val;
        if(root.left == null && root.right == null) return num;

        return SumNumbers(root.left, num) + SumNumbers(root.right, num);
    }
}