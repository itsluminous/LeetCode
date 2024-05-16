class Solution:
    def evaluateTree(self, root: Optional[TreeNode]) -> bool:
        # since it is a full binary tree, then if any child is null, then it is a leaf node
        if root.left == None: return root.val == 1
        
        leftVal = self.evaluateTree(root.left)
        rightVal = self.evaluateTree(root.right)

        if root.val == 2: return (leftVal | rightVal)
        return (leftVal & rightVal)

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right