class Solution:
    def findMaxAverage(self, nums: List[int], k: int) -> float:
        curr_sum = max_sum = sum(nums[:k])

        for r in range(k, len(nums)):
            curr_sum += nums[r] - nums[r-k]
            max_sum = max(max_sum, curr_sum)
        
        return max_sum/k