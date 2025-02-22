class Solution:
    def recoverFromPreorder(self, traversal: str) -> Optional[TreeNode]:
        self.idx = 0
        return self.recoverTree(traversal, -1)
    
    def recoverTree(self, traversal: str, parentDepth: int) -> Optional[TreeNode]:
        if self.idx == len(traversal): return None

        depth, num, newIdx = self.getDepthNum(traversal, self.idx)
        if parentDepth >= depth: return None

        self.idx = newIdx
        node = TreeNode(num)
        node.left = self.recoverTree(traversal, depth)
        node.right = self.recoverTree(traversal, depth)
        return node
    
    def getDepthNum(self, traversal: str, idx: int):
        depth = 0
        while idx + depth < len(traversal) and traversal[idx + depth] == '-':
            depth += 1

        numStart = numEnd = idx + depth
        while numEnd < len(traversal) and traversal[numEnd] != '-':
            numEnd += 1

        num = int(traversal[numStart : numEnd])
        return [depth, num, numEnd]

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right