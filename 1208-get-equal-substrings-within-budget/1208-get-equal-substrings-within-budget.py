class Solution:
    def equalSubstring(self, s: str, t: str, maxCost: int) -> int:
        n = len(s)

        # calculate cost at each index
        cost = [0] * n
        for i in range(n):
            cost[i] = abs(ord(s[i]) - ord(t[i]))
        
        # sliding window to find maxCost
        currCost = count = left = right = 0
        while right < n:
            currCost += cost[right]
            while currCost > maxCost and left <= right:
                currCost -= cost[left]
                left += 1
            count = max(count, right-left+1)
            right += 1

        return count