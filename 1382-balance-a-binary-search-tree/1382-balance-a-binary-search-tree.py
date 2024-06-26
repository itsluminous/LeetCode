
class Solution:
    def balanceBST(self, root: TreeNode) -> TreeNode:
        self.sortedList = []
        self.inorder(root)
        return self.buildBST(0, len(self.sortedList)-1)

    def buildBST(self, start: int, end: int) -> TreeNode:
        if start > end: return None
        mid = start + (end - start)//2
        node = self.sortedList[mid]
        node.left = self.buildBST(start, mid-1)
        node.right = self.buildBST(mid+1, end)
        return node

    def inorder(self, root: TreeNode) -> None:
        if not root: return
        self.inorder(root.left)
        self.sortedList.append(root)
        self.inorder(root.right)

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right