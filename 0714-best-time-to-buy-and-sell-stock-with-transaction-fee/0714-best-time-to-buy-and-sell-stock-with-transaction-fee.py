class Solution:
    def maxProfit(self, prices: List[int], fee: int) -> int:
        earning, holding = 0, -prices[0]
        for i in range(1, len(prices)):
            earning = max(earning, holding + prices[i] - fee)
            holding = max(holding, earning - prices[i])
        return earning