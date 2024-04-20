class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        min_val, profit = prices[0], 0
        for p in prices:
            profit = max(profit, p - min_val)
            min_val = min(min_val, p)
        return profit