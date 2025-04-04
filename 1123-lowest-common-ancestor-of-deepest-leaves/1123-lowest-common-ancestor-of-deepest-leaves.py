class Solution:
    def lcaDeepestLeaves(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        self.maxDepth = 0
        self.getDepth(root, 0)
        return self.ancestor

    def getDepth(self, node: Optional[TreeNode], currDepth: int) -> int:
        self.maxDepth = max(self.maxDepth, currDepth)
        if not node: return currDepth

        leftDepth = self.getDepth(node.left, currDepth + 1)
        rightDepth = self.getDepth(node.right, currDepth + 1)

        if leftDepth == rightDepth == self.maxDepth:
            self.ancestor = node
        return max(leftDepth, rightDepth)

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right