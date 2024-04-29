# BFS from right to left
class Solution:
    def rightSideView(self, root: Optional[TreeNode]) -> List[int]:
        ans = []
        if root == None: return ans

        queue = deque()
        queue.append(root)
        while queue:
            ans.append(queue[0].val);
            for i in range(len(queue), 0, -1):
                curr = queue.popleft()
                if curr.right != None: queue.append(curr.right)
                if curr.left != None: queue.append(curr.left)
        return ans

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right