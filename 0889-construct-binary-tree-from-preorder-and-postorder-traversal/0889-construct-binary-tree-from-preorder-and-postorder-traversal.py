class Solution:
    def constructFromPrePost(self, preorder: List[int], postorder: List[int]) -> Optional[TreeNode]:
        n = len(preorder)
        return self.construct(preorder, postorder, 0, n-1, 0, n-1)

    def construct(self, preorder: List[int], postorder: List[int], preStart: int, preEnd: int, poStart: int, poEnd: int) -> Optional[TreeNode]:
        node = TreeNode(preorder[preStart])

        # has no children
        if preStart == preEnd: return node

        # has two children
        if preorder[preStart+1] != postorder[poEnd-1]:
            preMid = preStart+1
            while preorder[preMid] != postorder[poEnd-1]: preMid += 1

            poMid = poEnd-1
            while postorder[poMid] != preorder[preStart+1]: poMid -= 1

            node.left = self.construct(preorder, postorder, preStart+1, preMid-1, poStart, poMid)
            node.right = self.construct(preorder, postorder, preMid, preEnd, poMid+1, poEnd-1)
        # has one children only, let's make it left
        else:
            node.left = self.construct(preorder, postorder, preStart+1, preEnd, poStart, poEnd-1)

        return node

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right