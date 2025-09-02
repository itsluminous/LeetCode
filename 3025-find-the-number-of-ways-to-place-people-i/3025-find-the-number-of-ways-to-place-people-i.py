# O(n^2)
class Solution:
    def numberOfPairs(self, points: list[list[int]]) -> int:
        SMALLEST = -51  # smallest possible y
        n = len(points)
        ans = 0

        # Sort by x ascending, then by y descending
        points.sort(key=lambda p: (p[0], -p[1]))

        for i in range(n):
            x1, y1 = points[i]
            ymax = SMALLEST
            for j in range(i + 1, n):
                x2, y2 = points[j]

                if y2 > y1: continue  # point 2 is above point 1. We want reverse
                # we cannot go lower than already visited y, else it will include more points in rectangle
                if y2 > ymax:
                    ans += 1
                    ymax = y2

        return ans