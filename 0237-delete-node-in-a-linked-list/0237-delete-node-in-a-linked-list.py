class Solution:
    def deleteNode(self, node):
        node.val = node.next.val
        if node.next.next: self.deleteNode(node.next)
        else: node.next = None

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None