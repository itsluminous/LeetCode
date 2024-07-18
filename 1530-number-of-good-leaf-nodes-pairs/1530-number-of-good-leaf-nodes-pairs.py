class Solution:
    def countPairs(self, root: TreeNode, distance: int) -> int:
        self.pairCount = 0
        self.maxDist = 11
        self.countLeavesAtDistance(root, distance)
        return self.pairCount
    
    def countLeavesAtDistance(self, node: Optional[TreeNode], distance: int) -> List[int]:
        currCount = [0] * self.maxDist
        
        if not node: return currCount
        if not node.left and not node.right:
            currCount[1] += 1
            return currCount

        # get count of nodes at each distance in left & right sub-tree
        leftCount = self.countLeavesAtDistance(node.left, distance)
        rightCount = self.countLeavesAtDistance(node.right, distance)

        # figure out how many pairs can be formed in the sub-tree
        for i in range(distance+1):
            for j in range(1, (distance+1-i)):
                self.pairCount += leftCount[i] * rightCount[j]

        # update the count of nodes at i distance
        for i in range (2, self.maxDist):
            currCount[i] = leftCount[i-1] + rightCount[i-1]
        
        return currCount

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right