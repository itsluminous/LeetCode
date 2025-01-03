class Solution:
    def waysToSplitArray(self, nums: List[int]) -> int:
        left, right = nums[0], sum(nums[1:])
        count = 0

        if left >= right: count += 1
        for i in range(1, len(nums)-1):
            left += nums[i]
            right -= nums[i]
            if left >= right: count += 1

        return count