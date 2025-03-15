class Solution:
    def minCapability(self, nums: List[int], k: int) -> int:
        low, high = 1, max(nums)
        while low < high:
            mid = low + (high - low) // 2
            if self.canRob(nums, k, mid):
                high = mid
            else:
                low = mid + 1

        return low

    # check if we can rob k houses without exceeding a per house limit
    def canRob(self, nums: List[int], k: int, maxRob: int) -> int:
        i = 0   
        while i < len(nums):
            if nums[i] <= maxRob:
                k -= 1
                i += 2  # skip next house
            else:
                i += 1
        
        return k <= 0