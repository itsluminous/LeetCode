class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        if self.getHeight(root) == -1: return False
        return True

    def getHeight(self, root: Optional[TreeNode]) -> int:
        if not root: return 0
        left = self.getHeight(root.left)
        right = self.getHeight(root.right)

        if left == -1 or right == -1: return -1    # subtree is already unbalanced

        if abs(left - right) > 1: return -1   # unbalanced
        return 1 + max(left, right)

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right