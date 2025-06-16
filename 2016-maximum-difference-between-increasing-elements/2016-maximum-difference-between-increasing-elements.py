class Solution:
    def maximumDifference(self, nums: List[int]) -> int:
        smallest, ans = nums[0], -1
        for i in range(1, len(nums)):
            if nums[i] > smallest:
                ans = max(ans, nums[i] - smallest)
            else:
                smallest = nums[i]

        return ans