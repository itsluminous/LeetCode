class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        l = maxLen = zero = 0
        for r in range(len(nums)):
            zero += 1-nums[r]  # if curr nums[r] == 0, increment count
            while zero > 1:
                zero -= 1 - nums[l]
                l += 1
            maxLen = max(maxLen, r-l)
        return maxLen