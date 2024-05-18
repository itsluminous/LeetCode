class Solution:
    def distributeCoins(self, root: Optional[TreeNode]) -> int:
        self.moves = 0
        self.dfs(root)
        return self.moves

    # return -ve if node is accepting and +ve if it is giving back
    def dfs(self, root: Optional[TreeNode]) -> int:
        if not root: return 0

        leftBalance = self.dfs(root.left)
        rightBalance = self.dfs(root.right)

        curr = leftBalance + rightBalance + root.val - 1
        self.moves += (abs(curr))
        return curr

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right