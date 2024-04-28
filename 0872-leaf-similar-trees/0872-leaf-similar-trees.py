class Solution:
    def leafSimilar(self, root1: Optional[TreeNode], root2: Optional[TreeNode]) -> bool:
        nodes1 = self.getLeafNodes(root1)
        nodes2 = self.getLeafNodes(root2)
        return nodes1 == nodes2
        
    def getLeafNodes(self, root: TreeNode):
        if root == None: return []
        if root.left == None and root.right == None: return [root.val]
        return self.getLeafNodes(root.left) + self.getLeafNodes(root.right)