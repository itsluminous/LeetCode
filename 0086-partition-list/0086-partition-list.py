class Solution:
    def partition(self, head: Optional[ListNode], x: int) -> Optional[ListNode]:
        smallPtr = newHeadSmall = ListNode(-1)
        largePtr = newHeadLarge = ListNode(-1)

        while head:
            if head.val < x:
                smallPtr.next = head
                smallPtr = smallPtr.next
            else:
                largePtr.next = head
                largePtr = largePtr.next
            head = head.next

        largePtr.next = None   # end the list
        smallPtr.next = newHeadLarge.next  # join the two lists

        return newHeadSmall.next

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next