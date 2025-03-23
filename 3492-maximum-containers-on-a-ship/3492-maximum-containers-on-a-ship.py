class Solution:
    def maxContainers(self, n: int, w: int, maxWeight: int) -> int:
        maxCellAllowed = maxWeight // w
        cellGiven = n * n
        return min(maxCellAllowed, cellGiven)