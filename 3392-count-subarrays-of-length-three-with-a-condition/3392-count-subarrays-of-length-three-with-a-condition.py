class Solution:
    def countSubarrays(self, nums: List[int]) -> int:
        count = 0
        for m in range(1, len(nums) - 1):
            if nums[m] / 2 == nums[m-1] + nums[m+1]:
                count += 1
        return count