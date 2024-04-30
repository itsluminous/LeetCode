class Solution:
    def goodNodes(self, root: TreeNode, biggest: int = float(-inf)) -> int:
        if root == None: return 0
        
        count = 0
        if root.val >= biggest: count += 1
        count += self.goodNodes(root.left, max(biggest, root.val))
        count += self.goodNodes(root.right, max(biggest, root.val))

        return count

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right