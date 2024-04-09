class Solution:
    def timeRequiredToBuy(self, tickets: List[int], k: int) -> int:
        ans = tickets[k]
        for i,tkt in enumerate(tickets):
            if i == k:
                continue
            if tkt < tickets[k]:
                ans += tkt
            elif i < k:
                ans += tickets[k]
            elif i >= k:
                ans += tickets[k]-1
        return ans