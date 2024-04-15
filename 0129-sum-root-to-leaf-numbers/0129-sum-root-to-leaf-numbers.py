class Solution:
    def sumNumbers(self, root: Optional[TreeNode], num: int = 0) -> int:
        if root is None: return 0

        num = num*10 + root.val;
        if root.left is None and root.right is None: return num

        return self.sumNumbers(root.left, num) + self.sumNumbers(root.right, num)