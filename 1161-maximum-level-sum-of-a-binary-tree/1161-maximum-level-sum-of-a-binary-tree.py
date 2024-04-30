class Solution:
    def maxLevelSum(self, root: Optional[TreeNode]) -> int:
        ansLevel, ansSum = 1, float(-inf)
        queue = deque()
        queue.append(root)

        lvl = 1
        while queue:
            currSum = 0
            for _ in range(len(queue), 0, -1):
                node = queue.popleft()
                currSum += node.val

                if node.left != None: queue.append(node.left)
                if node.right != None: queue.append(node.right)
            if currSum > ansSum:
                ansLevel, ansSum = lvl, currSum
            lvl += 1
        return ansLevel

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right