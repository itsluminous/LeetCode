
class Solution:
    def delNodes(self, root: Optional[TreeNode], to_delete: List[int]) -> List[TreeNode]:
        delete = [False] * 1001
        for num in to_delete:
            delete[num] = True
        
        self.roots = []
        self.dfs(root, None, delete)
        return self.roots
    
    def dfs(self, node: Optional[TreeNode], prev: Optional[TreeNode], to_delete: List[bool]):
        if not node: return

        # check if we found root node
        if not to_delete[node.val]:
            if not prev: self.roots.append(node)
            prev = node
        else: prev = None

        # save the left & right child in variable
        childLeft = node.left
        childRight = node.right

        # set left/right child as None if they are to be deleted
        if childLeft and to_delete[childLeft.val]:
            node.left = None
        if childRight and to_delete[childRight.val]:
            node.right = None

        # check further if more nodes are to be deleted
        self.dfs(childLeft, prev, to_delete)
        self.dfs(childRight, prev, to_delete)

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right