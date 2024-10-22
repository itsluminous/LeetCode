class Solution:
    def kthLargestLevelSum(self, root: Optional[TreeNode], k: int) -> int:
        maxHeap = []
        queue = [root]

        while queue:
            curr = 0
            next_queue = []
            for node in queue:
                curr += node.val
                if node.left: next_queue.append(node.left)
                if node.right: next_queue.append(node.right)
            heapq.heappush(maxHeap, -curr)
            queue = next_queue

        while k > 1 and maxHeap:
            heapq.heappop(maxHeap)
            k -= 1
        if maxHeap: return -heapq.heappop(maxHeap)
        return -1

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right