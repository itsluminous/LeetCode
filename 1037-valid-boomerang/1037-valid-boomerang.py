class Solution:
    def isBoomerang(self, points: List[List[int]]) -> bool:
        # check if any two points are same (can be done using hashset also)
        if points[1][1] == points[0][1] and points[1][0] == points[0][0]: return False
        if points[2][1] == points[0][1] and points[2][0] == points[0][0]: return False
        if points[2][1] == points[1][1] and points[2][0] == points[1][0]: return False

        # check if slope is same
        slope1 = float(inf) if points[1][0] - points[0][0] == 0 else (points[1][1] - points[0][1]) / (points[1][0] - points[0][0])
        slope2 = float(inf) if points[2][0] - points[0][0] == 0 else (points[2][1] - points[0][1]) / (points[2][0] - points[0][0])
        slope3 = float(inf) if points[2][0] - points[1][0] == 0 else (points[2][1] - points[1][1]) / (points[2][0] - points[1][0])
        if abs(slope1) == abs(slope2) and abs(slope2) == abs(slope3): return False

        return True