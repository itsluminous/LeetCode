# water level for any index will be equal to smaller one of largest block on left and right
# now, subtract height[i] from that to get actual water at that index
class Solution:
    def trap(self, height: List[int]) -> int:
        n = len(height)

        # find the maximum height on either side of an index
        lmax, rmax = [0]*n, [0]*n
        for i in range(1, n):
            lmax[i] = max(lmax[i-1], height[i-1])
            rmax[n-i-1] = max(rmax[n-i], height[n-i])
        
        # now calculated water at an index, using intution
        trapped = 0
        for i in range(1, n-1):
            water = min(lmax[i], rmax[i])
            curr = max(water-height[i], 0)
            trapped += curr
        
        return trapped