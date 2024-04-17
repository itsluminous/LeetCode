class Solution:
    def smallestFromLeaf(self, root: Optional[TreeNode], path: str = '') -> str:
        path = chr(ord('a') + root.val) + path
        if root.left == None and root.right == None: return path
        if root.left == None: return self.smallestFromLeaf(root.right, path)
        if root.right == None: return self.smallestFromLeaf(root.left, path)

        left = self.smallestFromLeaf(root.left, path)
        right = self.smallestFromLeaf(root.right, path)
        return left if left < right else right