class Solution:
    def passThePillow(self, n: int, time: int) -> int:
        # remove full cycles
        roundTrip = (n-1) * 2
        time %= roundTrip

        # left to right
        if time < n: return time + 1
        
        # right to left
        time -= n
        return n - time - 1