class Solution:
    def countNodes(self, root: Optional[TreeNode]) -> int:
        leftDepth = self.depth(root, True)
        rightDepth = self.depth(root, False)
        if leftDepth == rightDepth:
            return (1 << leftDepth) - 1
        
        return 1 + self.countNodes(root.left) + self.countNodes(root.right)
    
    def depth(self, root: Optional[TreeNode], goLeft: bool) -> int:
        dep = 0
        while root:
            dep += 1
            if goLeft: root = root.left
            else: root = root.right
        return dep

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right