class Solution:
    def minCapability(self, nums: List[int], k: int) -> int:
        # function to count how many houses can be robbed without exceeding a per house limit
        def robCount(limit: int) -> int:
            count = i = 0
            while i < len(nums):
                if nums[i] <= limit:
                    count += 1
                    i += 2  # skip next house
                else:
                    i += 1
        
            return count

        left, right = min(nums), max(nums)
        while left < right:
            mid = left + (right - left) // 2
            count = robCount(mid)
            if count >= k:
                right = mid
            else:
                left = mid + 1
        
        return left