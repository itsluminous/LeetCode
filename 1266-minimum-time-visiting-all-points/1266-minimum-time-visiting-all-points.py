class Solution:
    def minTimeToVisitAllPoints(self, points: List[List[int]]) -> int:
        time = 0
        x0, y0 = points[0]

        for x1, y1 in points:
            time += max(abs(x1 - x0), abs(y1 - y0))
            x0, y0 = x1, y1

        return time