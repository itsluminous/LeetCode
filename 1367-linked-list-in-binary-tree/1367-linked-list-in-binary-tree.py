class Solution:
    def isSubPath(self, head: Optional[ListNode], root: Optional[TreeNode]) -> bool:
        if not head: return True       # reached end of linked list
        if not root: return False      # reached end of tree
        return self.dfs(head, root) or self.isSubPath(head, root.left) or self.isSubPath(head, root.right)

    def dfs(self, head: Optional[ListNode], root: Optional[TreeNode]) -> bool:
        if not head: return True       # reached end of linked list
        if not root: return False      # reached end of tree
        
        if head.val != root.val: return False
        return self.dfs(head.next, root.left) or self.dfs(head.next, root.right)

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right