# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class FindElements:

    def __init__(self, root: Optional[TreeNode]):
        self.root = root
        self.nums = set()
        self.dfs(root, 0)

    def find(self, target: int) -> bool:
        return target in self.nums
    
    def dfs(self, node: Optional[TreeNode], curr: int):
        if not node: return
        self.nums.add(curr)

        self.dfs(node.left, 2 * curr + 1)
        self.dfs(node.right, 2 * curr + 2)


# Your FindElements object will be instantiated and called as such:
# obj = FindElements(root)
# param_1 = obj.find(target)