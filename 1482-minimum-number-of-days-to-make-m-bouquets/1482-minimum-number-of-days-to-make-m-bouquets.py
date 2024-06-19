class Solution:
    def minDays(self, bloomDay: List[int], m: int, k: int) -> int:
        flowersNeeded = m * k
        totalFlowers = len(bloomDay)
        if totalFlowers < flowersNeeded: return -1

        # find the earliest we can start harvesting, and also last date
        minDay, maxDay = float('inf'), 0
        for bd in bloomDay:
            minDay = min(minDay, bd)
            maxDay = max(maxDay, bd)
        if flowersNeeded == totalFlowers: return maxDay
        
        # now, try to find optimal day between minDay & maxDay
        while minDay < maxDay:
            mid = minDay + (maxDay - minDay) // 2
            if self.canHarvest(bloomDay, m, k, mid):
                maxDay = mid
            else:
                minDay = mid + 1

        return minDay

    def canHarvest(self, bloomDay: List[int], m: int, k: int, harvestDay: int) -> bool:
        adjacent = 0
        for bd in bloomDay:
            if bd <= harvestDay: adjacent += 1
            else: adjacent = 0  # reset count

            if adjacent == k:
                adjacent = 0
                m -= 1
        return m <= 0