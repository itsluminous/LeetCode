class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        max_val = curr_val = nums[0]
        for i in range(1, len(nums)):
            curr_val = max(curr_val + nums[i], nums[i])
            max_val = max(max_val, curr_val)
        return max_val