class Solution:
    def getDescentPeriods(self, prices: List[int]) -> int:
        descents, curr = 0, 1
        for i in range(1, len(prices)):
            if prices[i - 1] - prices[i] == 1:
                curr += 1
            else:
                descents += self.ap_sum(curr)
                curr = 1

        return descents + self.ap_sum(curr)

    def ap_sum(self, n):
        return n * (n + 1) // 2   