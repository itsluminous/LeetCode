class Solution:
    def modifiedList(self, nums: List[int], head: Optional[ListNode]) -> Optional[ListNode]:
        uniq = set(nums)
        newHead = ListNode(-1, head)
        curr = newHead
        while curr.next:
            if curr.next.val in uniq:
                curr.next = curr.next.next
            else:
                curr = curr.next
        return newHead.next

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next