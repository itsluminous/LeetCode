class Solution:
    def hasIncreasingSubarrays(self, nums: List[int], k: int) -> bool:
        n = len(nums)

        for i in range(1 + n-2*k):
            if self.isIncreasingSubarray(nums, i, k) and self.isIncreasingSubarray(nums, i+k, k):
                return True
        return False

    def isIncreasingSubarray(self, nums, start, k):
        for i in range(1, k):
            if nums[start + i] <= nums[start + i - 1]:
                return False
        return True