class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        left, right = 1, 1_000_000_000
        while left < right:
            mid = left + (right-left)//2
            hourTaken = 0
            for pile in piles: hourTaken += (pile+mid-1) // mid     # add hours taken for each pile
            
            if hourTaken > h: left = mid+1     # eating too slow
            else: right = mid                   # this will fit, but lets see if we can go slower

        return left