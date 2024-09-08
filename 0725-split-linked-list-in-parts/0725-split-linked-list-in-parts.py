class Solution:
    def splitListToParts(self, head: Optional[ListNode], k: int) -> List[Optional[ListNode]]:
        if not head: return [None] * k
        ans = [None] * k

        # count length of linked list
        length = 0
        curr = head
        while curr:
            curr = curr.next
            length += 1
        
        minSize = length // k
        extraCount = length % k

        def addNodes(start: int, end: int, listSize: int):
            nonlocal head
            for ansIdx in range(start, end):
                if not head: break
                ans[ansIdx] = head
                prev = head
                for _ in range(listSize):
                    prev = head
                    head = head.next
                prev.next = None

        addNodes(0, extraCount, minSize+1)  # lists with extra nodes
        addNodes(extraCount, k, minSize)    # lists with min nodes

        return ans

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next