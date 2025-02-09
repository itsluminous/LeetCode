class Solution:
    def maxScore(self, points: List[int], m: int) -> int:
        n = len(points)
        if m < n: return 0  # at least one index will be untouched, hence 0

        def possible(bound):
            # find out how many moves are needed for each point
            req = [(bound + p - 1) // p for p in points]  # (bound + p - 1) // p   is same as   math.ceil(bound / p)
            moves = 0   # track how many moves are done till now
            
            for i, required in enumerate(req):
                # if there are moves required
                if required:  
                    moves += 2 * required - 1   # we will have to do to-and-fro, hence double moves
                    if i < n - 1:
                        req[i + 1] = max(0, req[i + 1] - (req[i] - 1))  # update moves needed for next point
                elif i < n - 1:
                    moves += 1  # for points with no extra moves needed, we add 1 if it's not the last element
            
            return moves <= m
        
        lo, hi = 0, int(10**6 * m / n) + 1
        while lo < hi:
            mi = lo + (hi - lo + 1) // 2
            if possible(mi):
                lo = mi
            else:
                hi = mi - 1
        return lo