class Solution:
    def maxDistance(self, position: List[int], m: int) -> int:
        n = len(position)
        position.sort()

        minGap, maxGap, optimal = 0, (position[n-1] - position[0]), 0
        while minGap <= maxGap:
            mid = minGap + (maxGap - minGap) // 2
            if self.ball_count(position, mid) >= m:   # if more balls are fitting, then we should give more gap
                optimal = mid
                minGap = mid + 1
            else: maxGap = mid - 1

        return optimal

    # count number of balls that can be placed with given min gap
    def ball_count(self, position: List[int], gap: int) -> int:
        balls, curr = 1, position[0]
        for i in range(1, len(position)):
            if position[i] - curr >= gap:
                balls += 1
                curr = position[i]
        return balls