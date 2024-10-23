class Solution:
    def replaceValueInTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        root.val = 0
        level = []
        level.append(root)

        while level:
            # total sum of this level
            levelSum = 0
            for node in level:
                if node.left: levelSum+= node.left.val
                if node.right: levelSum+= node.right.val

            # assign cousin values and store new level
            nextLevel = []
            for node in level:
                # sum of values of both children of node
                siblingSum = 0
                if node.left: siblingSum+= node.left.val
                if node.right: siblingSum+= node.right.val

                # set new value for both children of node
                if node.left:
                    node.left.val = levelSum - siblingSum
                    nextLevel.append(node.left)
                if node.right:
                    node.right.val = levelSum - siblingSum
                    nextLevel.append(node.right)
            level = nextLevel

        return root

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right