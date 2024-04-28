class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        if not root: return 0
        ans = 0

        queue = deque()
        queue.append(root)
        while queue:
            ans += 1
            for i in range(len(queue), 0, -1):
                node = queue.popleft()
                if node.left != None: queue.append(node.left)
                if node.right != None: queue.append(node.right)
        return ans

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right