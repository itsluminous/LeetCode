class Solution:
    def maxDistance(self, side: int, points: List[List[int]], k: int) -> int:
        # imagine opening up entire square into a flat line
        posList = []
        for p in points:
            posList.append(self.normalizePos(side, p))
        
        pos = sorted(posList)

        # binary search to find max of min manhattan distance we can get
        perimeter = 4 * side
        lo, hi, ans = 0, perimeter, 0
        
        while lo <= hi:
            mid = lo + (hi - lo) // 2
            if self.canDo(pos, mid, k, perimeter):
                ans = mid
                lo = mid + 1
            else:
                hi = mid - 1
        
        return ans
    
    def canDo(self, pos: list[int], dist: int, k: int, perimeter: int) -> bool:
        n = len(pos)
        if k == 1: return True

        # try to fetch k points starting from each index
        for i in range(n):
            curr, count = i, 1

            # check if we can get k points with distance >= dist
            for j in range(1, k):
                target = pos[curr] + dist
                idx = bisect_left(pos, target)
                if idx >= n: break
                curr = idx
                count += 1

            # we represent pos as single line, but it wraps around as a circle
            # so need to ensure that distance between last point picked and first point is "dist"
            if count >= k:
                span = pos[curr] - pos[i]
                if span <= perimeter - dist: return True
        return False
    
    def normalizePos(self, side: int, p: list[int]) -> int:
        x, y = p
        if y == 0: return x                         # bottom edge
        if x == side: return side + y               # right edge
        if y == side: return 2 * side + (side - x)  # top edge
        return 3 * side + (side - y)                # left edge