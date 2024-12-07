class Solution:
    def minimumSize(self, nums: List[int], maxOperations: int) -> int:
        low, high = 1 , max(nums)

        while(low < high):
            mid = low + (high - low) // 2
            possible = self.distribute(nums, maxOperations, mid)
            if not possible: low = mid + 1
            else: high = mid
        
        return low
    
    def distribute(self, nums, maxOperations, mid):
        for i, num in enumerate(nums):
            # num-1 to avoid count when it is exactly divisble by mid
            # same as Math.ceil(num / mid) - 1
            maxOperations -= (num - 1) // mid 
            if maxOperations < 0: return False
        return True