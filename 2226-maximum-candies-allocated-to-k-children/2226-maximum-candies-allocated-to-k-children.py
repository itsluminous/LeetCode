class Solution:
    def maximumCandies(self, candies: List[int], k: int) -> int:
        low, high = 0, max(candies)

        while low < high:
            mid = low + (high - low + 1) // 2
            if self.canGive(candies, k, mid):
                low = mid
            else:
                high = mid - 1
        return low

    def canGive(self, candies: List[int], k: int, count: int) -> bool:
        if count == 0: return True

        for candy in candies:
            k -= candy // count
            if k <= 0: return True

        return False