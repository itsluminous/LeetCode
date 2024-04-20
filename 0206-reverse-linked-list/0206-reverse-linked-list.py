class Solution:
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head == None or head.next == None: return head

        prev, curr = head, head.next
        prev.next = None
        while curr != None:
            nxt = curr.next
            curr.next = prev
            prev = curr
            curr = nxt
        return prev