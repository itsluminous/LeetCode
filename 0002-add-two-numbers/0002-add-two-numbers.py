class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        ans = ListNode(-1)
        curr = ans
        carry = 0

        while l1 or l2:
            (num, carry) = self.sum(l1, l2, carry)
            curr.next = ListNode(num)

            curr = curr.next
            if l1: l1 = l1.next
            if l2: l2 = l2.next
        
        if carry == 1: curr.next = ListNode(1)
        return ans.next

    def sum(self, l1: Optional[ListNode], l2: Optional[ListNode], carry: int) -> (int, int):
        num1 = l1.val if l1 else 0
        num2 = l2.val if l2 else 0

        num = num1 + num2 + carry
        if num <= 9: carry = 0
        else:
            carry = 1
            num -= 10
        return num, carry

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next