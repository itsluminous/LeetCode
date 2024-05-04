class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        if not root: return root

        # first try to reach the correct node, which has to be removed
        if key < root.val: root.left = self.deleteNode(root.left, key)
        if key > root.val: root.right = self.deleteNode(root.right, key)

        # once we found the right node, then delete it
        if key == root.val:
            if not root.left and not root.right: return None    # leaf node, so just delete it
            if not root.left or not root.right:                 # if there is just one child, then it will replace the node to be deleted
                return root.left if root.left else root.right
            
            # if node has both children, then find biggest node on left side, and use that as replacement
            temp = root.left
            while temp.right: temp = temp.right
            root.val = temp.val
            root.left = self.deleteNode(root.left, temp.val)
        return root

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right