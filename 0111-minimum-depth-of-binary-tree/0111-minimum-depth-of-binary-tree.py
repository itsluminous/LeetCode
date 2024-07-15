class Solution:
    def minDepth(self, root: Optional[TreeNode]) -> int:
        if not root: return 0

        q = [root]
        depth = 0

        while q:
            depth += 1
            for _ in range(len(q)):
                node = q.pop(0)
                if not node.left and not node.right: return depth   # leaf node
                if node.left: q.append(node.left)
                if node.right: q.append(node.right)

        return depth

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right