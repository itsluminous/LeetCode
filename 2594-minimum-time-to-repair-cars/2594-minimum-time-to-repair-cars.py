class Solution:
    def repairCars(self, ranks: List[int], cars: int) -> int:
        low, high = 1, ranks[0] * cars * cars   # high = let rank[0] repair all cars
        while low < high:
            mid = low + (high - low) // 2
            if self.canRepair(ranks, cars, mid):
                high = mid
            else:
                low = mid + 1
        return low

    def canRepair(self, ranks: List[int], cars: int, maxTime: int) -> bool:
        for rank in ranks:
            repairedCarsSq = maxTime / rank
            cars -= int(repairedCarsSq ** 0.5)
            if cars <= 0: break
        return cars <= 0