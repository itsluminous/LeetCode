class Solution:
    def reverseBetween(self, head: Optional[ListNode], left: int, right: int) -> Optional[ListNode]:
        if left == right: return head
        right -= left - 1

        newHead = ListNode(-1, head)
        curr = newHead

        # find out the left node
        while left > 1:
            left -= 1
            curr = curr.next
        leftPrev, leftNode = curr, curr.next
        
        # reverse uptill we find right node
        prev = curr
        curr = curr.next
        while right > 0:
            right -= 1
            nextPtr = curr.next
            curr.next = prev
            prev = curr
            curr = nextPtr

        # fix missing links
        leftPrev.next = prev
        leftNode.next = curr

        return newHead.next

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next