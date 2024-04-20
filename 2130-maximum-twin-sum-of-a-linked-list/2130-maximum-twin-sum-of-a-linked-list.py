class Solution:
    def pairSum(self, head: Optional[ListNode]) -> int:
        # find mid
        slow, fast = head, head.next
        while fast != None and fast.next != None:
            fast = fast.next.next
            slow = slow.next

        mid = slow.next
        
        # save all numbers till mid in stack
        stack = []
        curr = head
        while curr != mid:
            stack.append(curr.val)
            curr = curr.next
        

        # get twin sum for all numbers and update max
        max_sum = 0
        while curr != None:
            curr_sum = curr.val + stack.pop()
            max_sum = max(max_sum, curr_sum)
            curr = curr.next

        return max_sum