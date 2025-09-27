class Solution:
    def largestTriangleArea(self, points: List[List[int]]) -> float:
        # Shoelace formula to find area of a triangle from 3 points
        def area(p, q, r):
            return .5 * abs(p[0]*q[1]+q[0]*r[1]+r[0]*p[1]
                           -p[1]*q[0]-q[1]*r[0]-r[1]*p[0])

        return max(area(*triangle)
            for triangle in itertools.combinations(points, 3))