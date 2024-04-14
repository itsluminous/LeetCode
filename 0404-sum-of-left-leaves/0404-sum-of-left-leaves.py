class Solution:
    def sumOfLeftLeaves(self, root: Optional[TreeNode]) -> int:
        if root is None: return 0

        sum = 0
        if root.left is not None and root.left.left is None and root.left.right is None:
            sum = root.left.val
        return sum + self.sumOfLeftLeaves(root.left) + self.sumOfLeftLeaves(root.right)