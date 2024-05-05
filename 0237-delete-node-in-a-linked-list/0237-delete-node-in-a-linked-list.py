class Solution:
    def deleteNode(self, node):
        temp = node.next
        node.val = temp.val
        node.next = temp.next
        temp = None

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None