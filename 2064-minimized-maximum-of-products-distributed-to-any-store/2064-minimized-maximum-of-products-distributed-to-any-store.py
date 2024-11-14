# let k be max any store can hold.
# We try k between 1, 10^5 and find the min value which allows us to distribute all products
class Solution:
    def minimizedMaximum(self, n: int, quantities: List[int]) -> int:
        low, high = 1, 100000
        while low < high:
            mid = low + (high - low) // 2
            if self.canDistribute(n, quantities, mid):
                high = mid
            else:
                low = mid+1
        return high
    
    def canDistribute(self, n: int, quantities: List[int], k: int) -> bool:
        for q in quantities:
            parts = math.ceil(q / k)    # ceil because if any remainder is left, that goes to a new store
            if n < parts: return False
            n -= parts
        return True

