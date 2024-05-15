class Solution:
    def insertGreatestCommonDivisors(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head == None or head.next == None: return head
        
        curr = head
        while curr.next:
            nextNode = curr.next
            gcdVal = self.gcd(curr.val, nextNode.val)
            gcdNode = ListNode(gcdVal, nextNode)
            curr.next = gcdNode
            curr = nextNode
        return head

    def gcd(self, a: int, b: int) -> int:
        # ensure that b is always smaller
        if b > a: return gcd(b, a)

        while b:
            temp = b
            b = a % b
            a = temp
        return a

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next