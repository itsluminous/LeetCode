class Solution:
    def oddEvenList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head == None or head.next == None: return head
        odd_tail, even_head, even_tail = head, head.next, head.next

        while even_tail != None and even_tail.next != None:
            odd_tail.next = odd_tail.next.next
            even_tail.next = even_tail.next.next
            odd_tail = odd_tail.next
            even_tail = even_tail.next

        odd_tail.next = even_head
        return head

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next